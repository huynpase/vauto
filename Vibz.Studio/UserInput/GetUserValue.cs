/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vibz.Studio.UserInput
{
    public partial class GetUserValue : Form
    {
        public string Value = "";
        public GetUserValue(string formTitle, string addTitle, string btnText)
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
