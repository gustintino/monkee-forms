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
        public Form1(TypeRacerApi api)
        {
            InitializeComponent();
            _api = api;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await _api.GetTextAsync();
            var result = JsonSerializer.Deserialize<TextResponse>(response).data.text;

            richTextBox1.Text = result;
        }
    }
}
