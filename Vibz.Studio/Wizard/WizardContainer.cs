using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vibz.Studio.Wizard
{
    public enum NavigationDirection { First, Previous, Next, Last }
    public partial class WizardContainer : Form
    {
        const string Finish = "Finish";
        const string Next = "Next";
        List<Wizard> _wizList;
        Dictionary<int, WizardParams> _wixParams = null;
        public Dictionary<int, WizardParams> WizardParameterList
        {
            get {
                if (_wixParams == null)
                    _wixParams = new Dictionary<int, WizardParams>();
                return _wixParams;
            }
        }
        int _currentWizardIndex = -1;
        bool _dispose = false;
        public WizardContainer(List<Wizard> wizList)
        {
            InitializeComponent();
            _wizList = wizList;
            _currentWizardIndex = 0;

            LoadWizard();
        }
       
        void LoadWizard()
        {
            pnlBody.Controls.Clear();

            btnPrevious.Enabled = !(_currentWizardIndex <= 0);

            // btnNext.Enabled = !(_currentWizardIndex >= _wizList.Count - 1);
            btnNext.Text = (_currentWizardIndex >= _wizList.Count - 1) ? WizardContainer.Finish : WizardContainer.Next;
            Wizard wiz = _wizList[_currentWizardIndex];
            if (WizardParameterList.ContainsKey(_currentWizardIndex))
            {
                WizardParams parameters = WizardParameterList[_currentWizardIndex];
                if (parameters != null)
                    wiz.Init(parameters);
            }
            
            wiz.Dock = DockStyle.Fill;

            pnlBody.Controls.Add(wiz);

            lblHeader.Text = wiz.Title;
        }
        
        void NavigateWizard(NavigationDirection direction)
        {
            if ((_currentWizardIndex <= 0 && direction == NavigationDirection.Previous)
                || (_currentWizardIndex >= _wizList.Count && direction == NavigationDirection.Next))
                return;

            if (pnlBody.Controls.Count == 0)
                throw new Exception("Invalid navigation.");

            Wizard curWiz = (Wizard)pnlBody.Controls[0];
            bool doLoad = false;
            int prevWizardIndex = _currentWizardIndex;
            switch (direction)
            { 
                case NavigationDirection.First:
                    _currentWizardIndex = 0;
                    doLoad = true;
                    break;
                case NavigationDirection.Previous:
                    _currentWizardIndex--;
                    doLoad = true;
                    break;
                case NavigationDirection.Last:
                    throw new Exception("Not supported.");
                case NavigationDirection.Next:
                default:
                    List<string> errs = new List<string>();
                    if (!curWiz.CanNavigate(ref errs))
                    {
                        string message = "You must follow these steps before navigating to next screen.";
                        foreach (string err in errs)
                        {
                            message += "\r\n\t" + err;
                        }
                        MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    _currentWizardIndex++;
                    doLoad = true;
                    break;
            }
            if (doLoad)
            {
                if (!WizardParameterList.ContainsKey(prevWizardIndex))
                    WizardParameterList.Add(prevWizardIndex, curWiz.Parameters);
                else
                    WizardParameterList[prevWizardIndex] = curWiz.Parameters;

                if (direction == NavigationDirection.Next && btnNext.Text == WizardContainer.Finish)
                {
                    this.DialogResult = DialogResult.OK;
                    _dispose = true;
                    this.Close();
                    return;
                }

                LoadWizard();
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            NavigateWizard(NavigationDirection.Previous);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NavigateWizard(NavigationDirection.Next);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(ConfirmClose())
                this.Close();
        }

        private void WizardContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_dispose)
            {
                if (!ConfirmClose())
                    e.Cancel = true;
            }
        }

        bool ConfirmClose()
        {
            if (MessageBox.Show("Are you sure you want to quit current process.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                _dispose = true;
                return true;
            }
            else
                return false;
        }
    }
}