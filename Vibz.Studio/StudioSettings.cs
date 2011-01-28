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

namespace Vibz.Studio
{
    public partial class StudioSettings : Form
    {
        public StudioSettings()
        {
            InitializeComponent();
            this.Text = LangResource.TextManager.GetString("Txt_StudioSettings");
            lblSpeed.Text = LangResource.TextManager.GetString("Txt_ExecutionSpeed");
            btnSave.Text = LangResource.TextManager.GetString("Txt_Save"); 
            tbExecutionSpeed.Value = App.Default.ExecutionSpeed;
            lblMin.Text = LangResource.TextManager.GetString("Txt_Min");
            lblMax.Text = LangResource.TextManager.GetString("Txt_Max"); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            App.Default.ExecutionSpeed = tbExecutionSpeed.Value;
            App.Default.Save();
        }
    }
}
