using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vibz.Studio.UserInput
{
    public partial class New : Form
    {
        public string Value = "";
        public New(string formTitle, string addTitle, string btnText)
        {
            InitializeComponent();
            this.Text = formTitle;
            this.lblNew.Text = addTitle;
            this.btnSubmit.Text = btnText;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewElement.Text.Trim() == "")
                    throw new Exception("Please enter a valid " + this.lblNew.Text);

                this.DialogResult = DialogResult.OK;
                Value = txtNewElement.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}