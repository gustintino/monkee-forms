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

namespace monkee_forms
{
    public partial class Form1 : Form
    { 
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


        // maybe i'll wanna do it some other way? dunno yet
        // if i'm doing it like this, i'll need to add any other elements as well
        // the inputbox is not on screen, and is therefore not clickable, so focus should be manual
        private void HandleEvents()
        {
            this.Click += (_, __) => _inputBox.Focus();
            this.Shown += (_, __) => _inputBox.Focus();
            rootPanel.Click += (_, __) => _inputBox.Focus();
            mainPanel.Click += (_, __) => _inputBox.Focus();

            _inputBox.KeyPress += InputBox_KeyPress;
            _inputBox.KeyDown += InputBox_KeyDown;

            // is this even needed?
            //button1.Click += (_, __) => _inputBox.Focus();
        }

        // TODO: handle index out of range
        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                // we Will be handling this in the KeyDown
                e.Handled = true;
                return;
            }

            HighlightClear();

            _referenceBox.Select(_index, 1);
            _referenceBox.SelectionColor = (e.KeyChar == _referenceText[_index]) ? Color.Green : Color.Red;
            _referenceBox.DeselectAll();

            _index++;
            HighlightChar();
            e.Handled = true; 
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

        }

        // called when clicking on the button
        private async void StartNewRound(object sender, EventArgs e)
        {
            var httpResponse = await _api.GetTextAsync();
            _referenceText = JsonSerializer.Deserialize<TextResponse>(httpResponse).data.text;

            _referenceBox.Text = _referenceText;
            _index = 0;
            HighlightChar();
            _inputBox.Focus();
        }
    }
}
