using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monkee_forms_v2
{
    public partial class CreateNewUserForm : Form
    {
        public string NewName { get; private set; } = string.Empty;

        public CreateNewUserForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputField.Text))
            {
                NewName = inputField.Text;
                DialogResult = DialogResult.OK;
                Close(); 
            }
            else
            {
                MessageBox.Show("The input name is not valid"); 
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close(); 
        }
    }
}
