using Microsoft.EntityFrameworkCore;
using monkee_forms_v2.Api.TypeRacerApi;
using monkee_forms_v2.Data;
using monkee_forms_v2.Grid_data;
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
        // - handle index out of range --> it's fine 99.9% of the time, not sure what causes it

        private readonly TypeRacerApi _api;

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
            _userList.Add(new User { ID = -1, Name = "Create new user..." });
            userSelect.DisplayMember = "Name";
            userSelect.ValueMember = "ID";

            UpdateGrids(); 
        }


        // the inputbox is not on screen, and is therefore not clickable, so focus should be manual 
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
                //_referenceText = await _api.GetTextAsync();
                using var db = MonkeeFormsDbContextFactory.Create();
                var randomText = await db.Texts.OrderBy(x => EF.Functions.Random()).FirstOrDefaultAsync();
                _referenceText = randomText;

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
            typeTxt.Text = $"({_referenceText.Type.ToString()})";
            titleTxt.Text = _referenceText.Title.ToString();
            UpdateGrids();
            accTxt.Text = "";
            wpmTxt.Text = "";
        }

        private async void EndRound()
        {
            _startedTyping = false;
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
            db.Add<Run>(run);
            await db.SaveChangesAsync();

            var currentuser = await db.Users.SingleAsync(u => u.ID == _currentUser.ID);
            currentuser.CompletedRuns++;
            currentuser.BestWpm = (wpm > currentuser.BestWpm) ? (float)wpm : currentuser.BestWpm;
            var last10wpm = await db.Runs
                .Where(r => r.UserID == currentuser.ID)
                .OrderByDescending(r => r.CompletedAt)
                .Select(r => r.Wpm)
                .Take(10)
                .ToListAsync();
            currentuser.AvgWpm_Last10Runs = (last10wpm.Any()) ? (float)last10wpm.Average() : 0f;
            var last10acc = await db.Runs
                .Where(r => r.UserID == currentuser.ID)
                .OrderByDescending(r => r.CompletedAt)
                .Select(r => r.Accuracy)
                .Take(10)
                .ToListAsync();
            currentuser.AvgAcc_Last10Runs = (last10acc.Any()) ? (float)last10acc.Average() : 0f; 
            _currentUser = currentuser;

            await db.SaveChangesAsync();

            UpdateUIDynamic(); 
            // i need the run info
            accTxt.Text = $"{Math.Round(run.Accuracy, 2)}%";
            wpmTxt.Text = $"{Math.Round(run.Wpm, 2)}wpm";
            UpdateGrids();
        }

        private async void userSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userSelect.SelectedValue is int id && id == -1)
            {
                using var modal = new CreateNewUserForm();
                if (modal.ShowDialog() == DialogResult.OK)
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
            UpdateUIStatic();
            UpdateUIDynamic();
            UpdateGrids();
        }
        private async Task AddUserAsync(User newUser)
        {
            using var db = MonkeeFormsDbContextFactory.Create();
            db.Add<User>(newUser);
            await db.SaveChangesAsync();
        }
 
        private void UpdateUIStatic()
        {
            userIdTxt.Text = _currentUser.ID.ToString();
            CreationTimeTxt.Text = _currentUser.CreatedAt.ToString();
        }

        private void UpdateUIDynamic()
        {
            BestWPMTxt.Text = Math.Round(_currentUser.BestWpm, 2).ToString();
            AvgAccTxt.Text = Math.Round(_currentUser.AvgAcc_Last10Runs, 2).ToString();
            AvgWPMTxt.Text = Math.Round(_currentUser.AvgWpm_Last10Runs, 2).ToString();
            RacesDoneTxt.Text = _currentUser.CompletedRuns.ToString();
        }

        private void UpdateGrids()
        {
            using var db = MonkeeFormsDbContextFactory.Create();

            var overallRows =
                (from run in db.Runs.AsNoTracking()
                 join user in db.Users.AsNoTracking() on run.UserID equals user.ID
                 orderby run.Wpm descending
                 select new
                 {
                     Name = user.Name,
                     Wpm = run.Wpm,
                     Accuracy = run.Accuracy

                 })
                 .Take(5)
                 .AsEnumerable()
                 .Select((entry, index) => new LeaderboardRow
                 {
                     Rank = index + 1,
                     Name = entry.Name,
                     Wpm = (float)Math.Round(entry.Wpm, 2),
                     Accuracy = (float)Math.Round(entry.Accuracy, 2)
                 })
                 .ToList();

            var userRows = db.Runs
                .AsNoTracking()
                .Where(r => r.UserID == _currentUser.ID)
                .OrderByDescending(r => r.Wpm)
                .Take(5)
                .AsEnumerable()
                .Select((run, index) => new LeaderboardRow
                {
                    Rank = index + 1,
                    Name = _currentUser.Name,
                    Wpm = (float)Math.Round(run.Wpm, 2),
                    Accuracy = (float)Math.Round(run.Accuracy, 2),
                }).ToList();

            var textsRows =
                (from run in db.Runs.AsNoTracking()
                 join user in db.Users.AsNoTracking() on run.UserID equals user.ID
                 where run.TextID == _referenceText.ID
                 orderby run.Wpm descending
                 select new
                 {
                     Name = user.Name,
                     Wpm = run.Wpm,
                     Accuracy = run.Accuracy
                 })
                 .Take(5)
                 .AsEnumerable()
                 .Select((entry, index) => new LeaderboardRow
                 {
                     Rank = index + 1,
                     Name = entry.Name,
                     Wpm = (float)Math.Round(entry.Wpm, 2),
                     Accuracy = (float)Math.Round(entry.Accuracy, 2),
                 }).ToList();

            overallGrid.DataSource = overallRows;
            perUserGrid.DataSource = userRows;
            perTextGrid.DataSource = textsRows;

            overallGrid.Columns[nameof(LeaderboardRow.Rank)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            overallGrid.Columns[nameof(LeaderboardRow.Rank)].FillWeight = 30;
            overallGrid.Columns[nameof(LeaderboardRow.Rank)].HeaderText = "#";

            perUserGrid.Columns[nameof(LeaderboardRow.Rank)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            perUserGrid.Columns[nameof(LeaderboardRow.Rank)].FillWeight = 30;
            perUserGrid.Columns[nameof(LeaderboardRow.Rank)].HeaderText = "#";

            perTextGrid.Columns[nameof(LeaderboardRow.Rank)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            perTextGrid.Columns[nameof(LeaderboardRow.Rank)].FillWeight = 30;
            perTextGrid.Columns[nameof(LeaderboardRow.Rank)].HeaderText = "#";
        }
    }
}
