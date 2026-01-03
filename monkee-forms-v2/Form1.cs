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
        private string _referenceText = "";

        public Form1(TypeRacerApi api)
        {
            InitializeComponent();

            _api = api;
            InitialSetup();
            HandleEvents();
        }

        private void InitialSetup()
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

            userSelect.Items.Add("Create new user...");


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
            if (e.KeyChar == _referenceText[_index])
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
            var httpResponse = await _api.GetTextAsync();
            _referenceText = JsonSerializer.Deserialize<TextResponse>(httpResponse)!.data.text;

            _referenceBox.Text = _referenceText;
            _index = 0;
            _correctCharsTyped = 0;
            _wrongCharsTyped = 0;
            HighlightChar();
            _inputBox.Enabled = true;
            _inputBox.Focus();
        }

        private void EndRound()
        {
            _inputBox.Enabled = false;
            _endTime = DateTime.Now;

            float acc = ((float)_correctCharsTyped / (_correctCharsTyped + _wrongCharsTyped));
            var length = _endTime - _startTime;
            var rawWpm = _referenceText.Length / length.TotalMinutes / 5;
            var wpm = rawWpm * acc;



            //using var db = MonkeeFormsDbContext.Create();
            var run = new Run
            {
                Accuracy = acc * 100,
                Wpm = Convert.ToInt32(wpm),
                CompletedAt = _startTime,
            };

        }

        private async void userSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(userSelect.SelectedItem?.ToString() == "Create new user...")
            {
                using var modal = new CreateNewUserForm();
                if(modal.ShowDialog() == DialogResult.OK)
                {
                    var newItem = modal.NewName;
                    userSelect.Items.Insert(0, newItem);
                    userSelect.SelectedItem = newItem;

                    var newUser = new User
                    {
                        Name = newItem,
                        CreatedAt = DateTime.Now
                    };
                    await AddUser(newUser);
                }
            }
        }
        private async Task AddUser(User newUser)
        {
            using var db = MonkeeFormsDbContext.Create();
            db.Add<User>(newUser);
            await db.SaveChangesAsync();
        }

        private async void AddRun(Run newRun)
        {
            using var db = MonkeeFormsDbContext.Create();
            db.Add<Run>(newRun);
            await db.SaveChangesAsync();
        }

        private async void AddText(Text newText)
        {
            using var db = MonkeeFormsDbContext.Create();
            db.Add<Text>(newText);
            await db.SaveChangesAsync();
        }
    }
}
