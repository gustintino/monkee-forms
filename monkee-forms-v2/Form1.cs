using Microsoft.EntityFrameworkCore;
using monkee_forms_v2.Api.TypeRacerApi;
using monkee_forms_v2.Data;
using monkee_forms_v2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monkee_forms_v2
{
    public partial class Form1 : Form
    {
        // TODO:
        // - handle index out of range --> i think i did it? need to doublecheck
        // - get some texts and/or ids in cache 
        // - sqlite everyting (scores + timestamp + wpm, users + total races + avg wpm, texts + ids) and connect everything
        // - add ui and logic for wpm
        // - username input
        // - add accuracy and logic for it

        private readonly TypeRacerApi _api;

        // ELEMENTS
        private RichTextBox _referenceBox;
        private TextBox _inputBox; // for actually capturing the input from user 

        private bool _startedTyping = false;
        private DateTime _startTime;
        private DateTime _endTime;
        private int _correctCharsTyped;
        private int _wrongCharsTyped;
        private int _index = 0;
        private Text _referenceText = new();

        private BindingList<User> _userList = null!;
        private User _currentUser = null!;

        public Form1(TypeRacerApi api)
        {
            InitializeComponent();

            _api = api;
            InitialSetup();
            HandleEvents();
        }

        private async void InitialSetup()
        {
            _referenceBox = new RichTextBox();
            mainPanel.Controls.Add(_referenceBox);

            _inputBox = new TextBox();
            Controls.Add(_inputBox);


            _referenceBox.Dock = DockStyle.Fill;
            _referenceBox.ReadOnly = true;
            //_referenceBox.BorderStyle = BorderStyle.None;
            _referenceBox.ScrollBars = RichTextBoxScrollBars.None;
            _referenceBox.TabStop = false;
            _referenceBox.HideSelection = true;
            _referenceBox.Font = new Font("Microsoft Sans Serif", 20f);

            _inputBox.Size = new Size(1, 1);
            _inputBox.Location = new Point(-200, -200);

            using var db = MonkeeFormsDbContextFactory.Create();

            List<User> dbItems = await db.Users.AsNoTracking().OrderBy(u => u.Name).ToListAsync();
            _userList = new BindingList<User>(dbItems);
            

            userSelect.DataSource = _userList;
            _userList.Add(new User { ID = -1, Name = "Create new user..."});
            userSelect.DisplayMember = "Name";
            userSelect.ValueMember = "ID";
        }


        // the inputbox is not on screen, and is therefore not clickable, so focus should be manual. 
        // maybe i'll wanna do it some other way? dunno yet
        // if i'm doing it like this, i'll need to add any other elements as well
        private void HandleEvents()
        {
            this.Click += (_, __) => _inputBox.Focus();
            this.Shown += (_, __) => _inputBox.Focus();
            rootPanel.Click += (_, __) => _inputBox.Focus();
            mainPanel.Click += (_, __) => _inputBox.Focus();
            _referenceBox.Click += (_, __) => _inputBox.Focus();

            _inputBox.KeyPress += InputBox_KeyPress;
            _inputBox.KeyDown += InputBox_KeyDown;
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_index >= _referenceText.Length)
            {
                e.Handled = true;
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                // we WILL be handling this in the KeyDown
                e.Handled = true;
                return;
            }

            if (!_startedTyping)
            {
                _startedTyping = true;
                _startTime = DateTime.Now;
            }

            HighlightClear();

            _referenceBox.Select(_index, 1);
            if (e.KeyChar == _referenceText.TextContent[_index])
            {
                _referenceBox.SelectionColor = Color.Green;
                _referenceBox.SelectionBackColor = mainPanel.BackColor;
                _correctCharsTyped++;
            }
            else
            {
                _referenceBox.SelectionColor = Color.Red;
                _referenceBox.SelectionBackColor = Color.PaleVioletRed;
                _wrongCharsTyped++;
            }
            _referenceBox.DeselectAll();

            _index++;
            e.Handled = true;

            if (_index == _referenceText.Length)
            {
                EndRound();
                return;
            }

            HighlightChar();
        }
        private void HighlightChar()
        {
            _referenceBox.Select(_index, 1);
            _referenceBox.SelectionBackColor = Color.SlateGray;
            _referenceBox.DeselectAll();
        }

        private void HighlightClear()
        {
            _referenceBox.Select(_index, 1);
            _referenceBox.SelectionBackColor = mainPanel.BackColor;
            _referenceBox.DeselectAll();
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            // add ctrl + backspace support? like a normal person?
            if (e.KeyCode == Keys.Back)
            {
                if (_index > 0)
                {
                    HighlightClear();
                    _index--;

                    _referenceBox.Select(_index, 1);

                    _referenceBox.SelectionColor = Color.Black;
                    _referenceBox.SelectionBackColor = mainPanel.BackColor;
                    _referenceBox.DeselectAll();

                    HighlightChar();
                }
            }

            e.Handled = true;
        }

        // called when clicking on the button
        private async void StartNewRound(object sender, EventArgs e)
        {
            if (textIdInput.Text == string.Empty)
            {
                // this should get a random text from the db, just calls default for now
                _referenceText = await _api.GetTextAsync();
            }
            else
            {
                try
                {
                    _referenceText = await _api.GetTextAsync(Int32.Parse(textIdInput.Text));
                } 
                catch
                {
                    MessageBox.Show("Id should be numbers only.");
                    textIdInput.Text = ""; 
                    return;
                }
            }

            _referenceBox.Text = _referenceText.TextContent;
            textIdInput.Text = ""; 
            _index = 0;
            _correctCharsTyped = 0;
            _wrongCharsTyped = 0;
            HighlightChar();
            _inputBox.Enabled = true;
            _inputBox.Focus(); 
        }

        private async void EndRound()
        {
            _inputBox.Enabled = false;
            _endTime = DateTime.Now;

            var acc = ((float)_correctCharsTyped / (_correctCharsTyped + _wrongCharsTyped));
            var length = _endTime - _startTime;
            var rawWpm = _referenceText.Length / length.TotalMinutes / 5;
            var wpm = rawWpm * acc;
 
            using var db = MonkeeFormsDbContextFactory.Create();

            var run = new Run
            {
                Accuracy = acc * 100,
                Wpm = (float)wpm,
                CompletedAt = _startTime,
                UserID = _currentUser.ID,
                TextID = _referenceText.ID 
            };
            var currentuser = await db.Users.SingleAsync(u => u.ID == _currentUser.ID);
            currentuser.CompletedRuns++;
            currentuser.BestWpm = (wpm > currentuser.BestWpm) ? (float)wpm : currentuser.BestWpm;
            var last10wpm = await db.Runs
                .Where(r => r.UserID == currentuser.ID)
                .OrderByDescending(r => r.CompletedAt)
                .Select(r => r.Wpm)
                .Take(10)
                .ToListAsync();
            currentuser.AvgWpm_Last10Runs = (float)last10wpm.Average();
            var last10acc = await db.Runs
                .Where(r => r.UserID == currentuser.ID)
                .OrderByDescending(r => r.CompletedAt)
                .Select(r => r.Accuracy)
                .Take(10)
                .ToListAsync();
            currentuser.AvgAcc_Last10Runs = (float)last10acc.Average();

            db.Add<Run>(run);
            await db.SaveChangesAsync(); 
        }

        private async void userSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(userSelect.SelectedValue is int id && id == -1)
            {
                using var modal = new CreateNewUserForm();
                if(modal.ShowDialog() == DialogResult.OK)
                {
                    var newName = modal.NewName;

                    var newUser = new User
                    {
                        Name = newName,
                        CreatedAt = DateTime.Now
                    };
                    _userList.Insert(_userList.Count - 1, newUser);
                    userSelect.SelectedItem = newUser;
                    await AddUserAsync(newUser);
                }
            }
            else
            {
                _currentUser = (User)userSelect.SelectedItem; 
            }
        }
        private async Task AddUserAsync(User newUser)
        {
            using var db = MonkeeFormsDbContextFactory.Create();
            db.Add<User>(newUser);
            await db.SaveChangesAsync();
        }

        private async void AddRun(Run newRun)
        {
            using var db = MonkeeFormsDbContextFactory.Create();
            db.Add<Run>(newRun);
            await db.SaveChangesAsync();
        }

    }
}
