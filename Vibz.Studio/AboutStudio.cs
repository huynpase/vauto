using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Vibz.Studio
{
    public partial class AboutStudio : Form
    {
        public AboutStudio()
        {
            InitializeComponent();
            lblVersion.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}