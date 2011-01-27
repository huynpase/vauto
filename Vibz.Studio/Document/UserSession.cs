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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Vibz.Studio.Document
{
    public partial class UserSession : UserControl
    {
        public UserSession()
        {
            InitializeComponent();
        }

        private void UserSession_Load(object sender, EventArgs e)
        {
            LoadSession();
        }
        private void LoadSession()
        {
            // TODO: Do Licence Check
            // if (App.Default.ProductKey == null || App.Default.ProductKey.Trim() == "")
            if(false)
            {
                pnlRegKey.Visible = true;
                txtUser.Text = Environment.UserName;
                pnlRegKey.Location = new Point(3, 10);
                pnlUserWelcome.Visible = false;
            }
            else
            {
                try
                {
                    pnlRegKey.Visible = false;
                    pnlUserWelcome.Visible = true;
                    lblUser.Text = (App.Default.RegisteredUser == "" ? "This is an evaluation version software. You are free to use it for unlimited time period." : "This product is licensed to " + App.Default.RegisteredUser);
                    //RegistryElement regEle = RegistryManager.GetDetailsForRegKey(App.Default.ProductKey);
                    //int used = (int)((TimeSpan)DateTime.Now.Subtract(DateTime.Parse(App.Default.ProductDate))).TotalDays;
                    //lblDate.Text = regEle.Description + "\r\nThe product will expire after " + Convert.ToString(regEle.Days - used) + " days.";

                    btnUpdate.Visible = false;
                    lblDate.Visible = false;
                    pnlUserWelcome.Location = new Point(3, 10);
                }
                catch (Exception exc)
                {
                    Reset();
                }
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string userKey = txtKey1.Text + txtKey2.Text + txtKey3.Text + txtKey4.Text + txtKey5.Text;
            bool keyValid = false;
            foreach (RegistryElement regEle in RegistryManager.List)
            {
                if (regEle.Value == userKey)
                {
                    keyValid = true;
                    break;
                }
            }
            if (keyValid)
            {
                App.Default.ProductDate = DateTime.Today.ToShortDateString();
                App.Default.RegisteredUser = txtUser.Text;
                App.Default.ProductKey = userKey;
                App.Default.Save();
                LoadSession();
            }
            else
                MessageBox.Show("Invalid Key. Please contact publishers to get your product key.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Reset();
        }
        void Reset()
        {
            App.Default.ProductKey = "";
            App.Default.Save();
            LoadSession();
        }
    }
}
