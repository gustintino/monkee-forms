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

            // is this even needed?
            //button1.Click += (_, __) => _inputBox.Focus();
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

            HighlightClear();

            _referenceBox.Select(_index, 1);
            _referenceBox.SelectionColor = (e.KeyChar == _referenceText[_index]) ? Color.Green : Color.DarkRed;
            _referenceBox.SelectionBackColor = (e.KeyChar == _referenceText[_index]) ? mainPanel.BackColor : Color.PaleVioletRed;
            _referenceBox.DeselectAll();

            _index++;
            e.Handled = true; 

            if (_index == _referenceText.Length)
            {
                _inputBox.Enabled = false;
                // some other logic here when the user is done with the text
                return;
            }

            HighlightChar();
        }
        private void HighlightChar()
        {
            _referenceBox.Select(_index, 1);
            _referenceBox.SelectionBackColor = Color.LightGray;
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
            HighlightChar();
            _inputBox.Enabled = true;
            _inputBox.Focus();
        }
    }
}
