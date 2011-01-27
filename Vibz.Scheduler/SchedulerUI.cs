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
using System.IO;
using System.Windows.Forms;
using Vibz.Service;
using Vibz.Service.Config;
using Vibz.Service.Schedule;
using Vibz.Service.Schedule.Event;

namespace Vibz.Scheduler
{
    public partial class SchedulerUI : Form
    {
        EventType DefaultEventType = EventType.Command;
        ScheduleType DefaultScheduleType = ScheduleType.Periodic;

        public SchedulerUI()
            : this(null)
        {
        }
        public SchedulerUI(string[] args)
        {
            InitializeComponent();
            if (args != null && args.Length != 0)
            {
                AddEvent(args.GetValue(0).ToString());
            }
            LoadHistory();
            LoadConfigSetting();
            serviceController1.ServiceName = Automate.VibzServiceName;
            SetServiceControl();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            Reload();
        }
        void SetServiceControl()
        {
            tsbStart.Enabled = false;
            tsbStop.Enabled = false;
            tsbRestart.Enabled = false;
            switch (serviceController1.Status)
            { 
                case System.ServiceProcess.ServiceControllerStatus.Stopped:
                    tsbStart.Enabled = true;
                    lblServiceStatus.ForeColor = Color.Red;
                    break;
                case System.ServiceProcess.ServiceControllerStatus.Running:
                    tsbStop.Enabled = true;
                    tsbRestart.Enabled = true;
                    lblServiceStatus.ForeColor = Color.Green;
                    break;
            }
            lblServiceStatus.Text = serviceController1.Status.ToString();
        }
        void LoadConfigSetting()
        {
            txtThreadCount.Text = ConfigManager.Configuration.MaxThreadCount.ToString();
            LoadLoagLevel();
            cbLogLevel.SelectedItem = HistoryManager.History.LogLevel;
            tBarTick.Value = (int)ConfigManager.Configuration.TickInterval;
            UpdateTickValue();
            LoadScheduleSetting(0);
            LoadScheduleTypes();
        }
        void LoadScheduleSetting(int selectIndex)
        {
            tvRunningTask.Nodes.Clear();
            tvRunningTask.ImageList = imageList1;
            foreach (ISchedule sch in ConfigManager.Configuration.ScheduleList)
            {
                TreeNode tn = new TreeNode();
                tn.Text = sch.Name;
                switch (sch.Type)
                {
                    case ScheduleType.Periodic:
                        tn.ImageIndex = 5;
                        break;
                    case ScheduleType.OneTime:
                        tn.ImageIndex = 6;
                        break;
                    case ScheduleType.PeriodicMask:
                        tn.ImageIndex = 7;
                        break;
                }
                tn.Tag = sch;
                foreach (Vibz.Service.Schedule.Event.IEvent evt in sch.EventList)
                {
                    TreeNode tEvent = new TreeNode();
                    tEvent.Text = evt.Name;
                    switch (evt.Type)
                    {
                        case Vibz.Service.Schedule.Event.EventType.Command:
                            tEvent.ImageIndex = 4;
                            break;
                    }
                    tEvent.Tag = evt;
                    tEvent.SelectedImageIndex = tEvent.ImageIndex;
                    tEvent.Collapse();
                    tn.Nodes.Add(tEvent);
                }
                tn.SelectedImageIndex = tn.ImageIndex;
                tn.Collapse();
                tvRunningTask.Nodes.Add(tn);
            }
            if (tvRunningTask.Nodes.Count <= 0)
                return;
            if (selectIndex == -1)
            {
                tvRunningTask.SelectedNode = tvRunningTask.Nodes[tvRunningTask.Nodes.Count - 1];
            }
            else if (selectIndex < tvRunningTask.Nodes.Count)
            {
                tvRunningTask.SelectedNode = tvRunningTask.Nodes[selectIndex];
            }
        }
        void LoadScheduleTypes()
        {
            ddlElementType.Items.Clear();
            foreach (ScheduleType type in Enum.GetValues(typeof(ScheduleType)))
            {
                ddlElementType.Items.Add(type);
            }
        }
        void LoadEventTypes()
        {
            ddlElementType.Items.Clear();
            foreach (EventType type in Enum.GetValues(typeof(EventType)))
            {
                ddlElementType.Items.Add(type);
            }
        }
        void LoadLoagLevel()
        { 
            foreach (LogLevel level in Enum.GetValues(typeof(LogLevel))) 
            {
                cbLogLevel.Items.Add(level);
            }
        }
        void LoadHistory()
        {
            tvHistory.Nodes.Clear();
            tvHistory.ImageList = imageList1;
            foreach (Vibz.Service.History.IHistory hs in Vibz.Service.Config.HistoryManager.History.HistoryList)
            {
                TreeNode tn = new TreeNode();
                switch (hs.Type)
                { 
                    case Vibz.Service.History.HistoryType.Error:
                        tn.Text = hs.LogTime.ToString() + ": " + hs.Message;
                        tn.ImageIndex = 2;
                        break;
                    case Vibz.Service.History.HistoryType.Event:
                        Vibz.Service.History.HistoryEvent hse = (Vibz.Service.History.HistoryEvent)hs;
                        tn.Text = hs.LogTime.ToString() + ": " + hse.Name + " [Result: " + hse.Result.Status.ToString() + "]";
                        tn.Nodes.Add("Name", "Name: " + hse.Name, 3, 3);
                        tn.Nodes.Add("Result", "Result: " + hse.Result.Status.ToString(), 3, 3);
                        tn.Nodes.Add("StartTime", "Start Time: " + hse.Result.StartTime.ToString(), 3, 3);
                        tn.Nodes.Add("Duration", "Duration: "
                            + (hse.Result.Duration.Hours == 0 ? "" : hse.Result.Duration.Hours.ToString() + " hours ")
                            + (hse.Result.Duration.Minutes == 0 ? "" : hse.Result.Duration.Hours.ToString() + " minutes ")
                            + (hse.Result.Duration.Seconds == 0 ? "" : hse.Result.Duration.Hours.ToString() + " seconds ")
                            + (hse.Result.Duration.Milliseconds == 0 ? "" : hse.Result.Duration.Hours.ToString() + " ms")
                            , 3, 3);
                        tn.Nodes.Add("Information", "Information: " + hse.Result.Message, 3, 3);
                        tn.Nodes.Add("LogTime", "Log time: " + hse.LogTime.ToString(), 3, 3);
                        tn.ImageIndex = 1;
                        break;
                    default:
                    case Vibz.Service.History.HistoryType.Info:
                        tn.Text = hs.LogTime.ToString() + ": " + hs.Message;
                        tn.ImageIndex = 0;
                        break;
                }
                tn.SelectedImageIndex = tn.ImageIndex;
                tn.Collapse();
                tvHistory.Nodes.Add(tn);
            }
        }

        private void tsbClearAll_Click(object sender, EventArgs e)
        {
            StopService();
            Vibz.Service.Config.HistoryManager.History.ClearHistory();
            StartService();
            LoadHistory();
        }

        private void tsbReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            StartService();
        }
        private void tsbStop_Click(object sender, EventArgs e)
        {
            StopService();
        }
        private void tsbRestart_Click(object sender, EventArgs e)
        {
            RestartService();
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                StopService();
                if (!Vibz.Helper.Math.IsNumber(txtThreadCount.Text))
                    throw new Exception("Invalid 'Maximum parallel execution' value. It must be a positive integer.");

                ConfigManager.Configuration.UpdateScheduleService(tBarTick.Value, Vibz.Helper.Math.TryGetInteger(txtThreadCount.Text), (LogLevel)cbLogLevel.SelectedItem);
                StartService();
                MessageBox.Show("Settings saved successfully.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tvRunningTask_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (tvRunningTask.SelectedNode == null)
                return;
            tvRunningTask.SelectedNode.BackColor = Color.White;
            tvRunningTask.SelectedNode.ForeColor = Color.Black;
        }
        private void tvRunningTask_AfterSelect(object sender, TreeViewEventArgs e)
        {
            IElementNode ele = (IElementNode)e.Node.Tag;
            ShowConfigurations(ele.GetParameters());
            if (e.Node.Tag.GetType().GetInterface(typeof(ISchedule).FullName) != null)
            {
                LoadScheduleTypes();
                ddlElementType.SelectedItem = ((ISchedule)ele).Type;
                lblElementType.Text = "Schedule Type";
            }
            else if (e.Node.Tag.GetType().GetInterface(typeof(IEvent).FullName) != null)
            {
                LoadEventTypes();
                ddlElementType.SelectedItem = ((IEvent)ele).Type;
                lblElementType.Text = "Event Type";
            }
            tvRunningTask.SelectedNode.BackColor = Color.FromKnownColor(KnownColor.Highlight);
            tvRunningTask.SelectedNode.ForeColor = Color.White;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                IElementNode newEle = ElementFactory.GetElement(ddlElementType.SelectedItem, tvRunningTask.SelectedNode.Tag);
                newEle.SetParameters(GetConfigurations());
                ConfigManager.Configuration.UpdateElement(newEle);

                if (MessageBox.Show("Settings have been saved successfully. However any changes to scheduled configurations will show effects only after service is restarted. Do you want the service to restart now?", "Allert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    RestartService();

                LoadScheduleSetting(tvRunningTask.SelectedNode.Index);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tBarTick_Scroll(object sender, EventArgs e)
        {
            UpdateTickValue();
        }

        private void ddlElementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlElementType.Focused)
            {
                TreeNode eNode = tvRunningTask.SelectedNode;
                IElementNode ele = (IElementNode)eNode.Tag;

                IElementNode mapEle = ElementFactory.GetElement(ddlElementType.SelectedItem, ele);

                ShowConfigurations(mapEle.MapParameters(ele.GetParameters()));
            }
        }

        void Reload()
        {
            Vibz.Service.Config.HistoryManager.History.Reload();
            LoadHistory();
        }
        void StopService()
        {
            if (serviceController1.Status != System.ServiceProcess.ServiceControllerStatus.Stopped)
                serviceController1.Stop();
            WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
            SetServiceControl();
        }
        void StartService()
        {
            if (serviceController1.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                serviceController1.Start();
            WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
            SetServiceControl();
        }
        void RestartService()
        {
            StopService();
            StartService();
        }
        void WaitForStatus(System.ServiceProcess.ServiceControllerStatus status)
        {
            while (serviceController1.Status != status)
            {
                pBar.Visible = true;
                pBar.MarqueeAnimationSpeed = 100;
                pBar.Value = 0;
                serviceController1.Refresh();
            }
            pBar.Value = 0;
            pBar.Visible = false;
        }

        
        void UpdateTickValue()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, tBarTick.Value);
            lblTickValue.Text = (ts.ToString().Length > 8 ? ts.ToString().Substring(3, 5) : ts.ToString().Substring(3)) + " {minute:second}";
        }

        void ShowConfigurations(Dictionary<string, string> param)
        {
            dgConfiguration.Rows.Clear();
            if (param == null)
                return;
            foreach (string key in param.Keys)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();

                DataGridViewCell dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = key;
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = (param[key] == null ? "" : param[key].ToString());
                dgvRow.Cells.Add(dgvCell);

                dgConfiguration.Rows.Add(dgvRow);
            }
        }
        Dictionary<string, string> GetConfigurations()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            foreach (DataGridViewRow dgvRow in dgConfiguration.Rows)
            {
                param.Add(dgvRow.Cells[0].Value.ToString(), dgvRow.Cells[1].Value.ToString());
            }
            return param;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Automation Compiled Script files(*." + Vibz.FileType.CompiledScropt + ")|*." + Vibz.FileType.CompiledScropt +
                "|Batch files(*.bat)|*.bat" +
                "|All supported files (*." + Vibz.FileType.CompiledScropt + ", *.bat)|*." + Vibz.FileType.CompiledScropt + ";*.bat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent(txtPath.Text);
        }
        void AddEvent(string filePath)
        {
            if (!File.Exists(filePath))
                MessageBox.Show("Invalid file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ISchedule sch = (ISchedule)ElementFactory.GetScheduleElement(DefaultScheduleType);
            sch.Name = "S" + Vibz.Helper.Time.TimeStamp;
            CommandEvent evt = (CommandEvent)ElementFactory.GetEventElement(EventType.Command);
            evt.Name = "E" + Vibz.Helper.Time.TimeStamp;
            FileInfo fi = new FileInfo(filePath);
            switch (fi.Extension.ToLower())
            { 
                case ".bat":
                    evt.Arguments = "\'" + fi.FullName + "\'";
                    break;
                case "." + Vibz.FileType.CompiledScropt:
                    evt.Arguments = "/c vauto -r -f='" + fi.FullName + "'";
                    break;
            }
            sch.EventList.Add(evt);

            ConfigManager.Configuration.UpdateSchedule(sch);

            LoadScheduleSetting(-1);

            txtPath.Text = "";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvRunningTask.SelectedNode.Tag == null)
                return;
            if (MessageBox.Show("Are your sure you want to delete the selected Scheduled task?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IElementNode ele = (IElementNode)tvRunningTask.SelectedNode.Tag;
                ConfigManager.Configuration.DeleteElement(ele);
            }
            LoadScheduleSetting(0);
        }
        private void tvRunningTask_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvRunningTask.SelectedNode = e.Node;
                cmsScheduleTask.Show(this.tvRunningTask, e.Location);
            }
        }
    }
}
