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
using Vibz.Solution;
using Vibz.Solution.Element;
using Vibz.Contract.Log;
using Vibz.Interpreter;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Vibz.Studio
{
    public partial class Studio : Form
    {
        #region Class Member
        Project _project;
        public Document.DocumentList _docList;
        Vibz.ITask _currentTask = new Compiler();
        delegate void TaskDelegate(object param);
        object _taskLock = new object();
        string _errorMessage = "";
        string _initialFilePath = "";
        #endregion;

        #region Constructor
        public Studio()
            : this(null)
        { }
        public Studio(string[] args)
        {
            InitializeComponent();
            timerStatus.Tick += new EventHandler(timerStatus_Tick);
            timerExecution.Tick += new EventHandler(timerExecution_Tick);
            lblStatus.Click += new EventHandler(lblStatus_Click);
            if (args != null && args.Length != 0)
            {
                _initialFilePath = args.GetValue(0).ToString();
            }
        }
        
        private void Studio_Load(object sender, EventArgs e)
        {
            SetLanguageText();
            
            //menuStrip1.Enabled = ValidateRegistration();
            this.MainMenuStrip = new MenuStrip();
            configurationToolStripMenuItem.Enabled = false;
            compileToolStripMenuItem.Enabled = false;
            runToolStripMenuItem.Enabled = false;
            btnRun.Enabled = false;
            btnCompile.Enabled = false;

            playSoundToolStripMenuItem.CheckState = (App.Default.PlaySound ? CheckState.Checked : CheckState.Unchecked);
            encodeBuildOutputToolStripMenuItem.CheckState = (App.Default.EncodeBuild ? CheckState.Checked : CheckState.Unchecked);
            loggerToolStripMenuItem.CheckState = (App.Default.LogEvents ? CheckState.Checked : CheckState.Unchecked);

            tvLeft.ImageList = ProjectElementIcons;

            Document.Welcome wel = new Vibz.Studio.Document.Welcome();
            wel.Dock = DockStyle.Fill;
            wel.MdiParent = this;
            wel.Show();

            if (_initialFilePath != null && _initialFilePath != "")
            {
                OpenDocument(_initialFilePath);
            }

            Controls.Toolbox tb = new Controls.Toolbox();
            tb.Dock = DockStyle.Fill;
            pnlTool.Controls.Add(tb);

            pnlToolHead.SendToBack();
        }

        void SetLanguageText()
        {
            this.Text = LangResource.TextManager.GetString("Txt_StudioTitle") + " : " + LangResource.TextManager.GetString("Txt_Copyright");
            this.Name = LangResource.TextManager.GetString("Txt_Studio");
            this.toolStripButton2.ToolTipText = LangResource.TextManager.GetString("Txt_Save");
            this.toolStripButton4.ToolTipText = LangResource.TextManager.GetString("Txt_Search");
            this.btnCompile.ToolTipText = LangResource.TextManager.GetString("Txt_Compile");
            this.btnRun.ToolTipText = LangResource.TextManager.GetString("Txt_Run");
            this.fileToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_File");
            this.newProjectToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_NewProject");
            this.openProjectToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_OpenProject");
            this.saveToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Save");
            this.saveAsToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_SaveAs");
            this.exitToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Exit");
            this.toolStripMenuItem1.Text = LangResource.TextManager.GetString("Txt_View");
            this.showToolbarToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_ShowToolbox");
            this.toolStripMenuItem2.Text = LangResource.TextManager.GetString("Txt_Edit");
            this.searchToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Search");
            this.buildToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Task");
            this.compileToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Compile");
            this.runToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Run");
            this.stopToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Stop");
            this.optionsToolStripMenuItem1.Text = LangResource.TextManager.GetString("Txt_Options");
            this.configurationToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Configuration");
            this.playSoundToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_PlaySound");
            this.helpToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Help");
            this.aboutVibzworldAutomationStudioToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_AboutStudio");
            this.encodeBuildOutputToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Encode");
            this.loggerToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_Logger");
            this.aPISupportToolStripMenuItem.Text = LangResource.TextManager.GetString("Txt_APISupport"); ;
            this.lblDictTitle.Text = LangResource.TextManager.GetString("Txt_InstructionDict");
            this.settingsStripMenuItem3.Text = LangResource.TextManager.GetString("Txt_StudioSettings");
        }
        public bool ValidateRegistration()
        {
            //if (((TimeSpan)DateTime.Now.Subtract(DateTime.Parse(App.Default.ProductDate))).TotalDays) ;
            return true;
        }
        #endregion

        #region Menu Event
        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (File.Exists(App.Default.ProjectLocation))
            {
                System.IO.FileInfo fInfo = new System.IO.FileInfo(App.Default.ProjectLocation);
                openFileDialog1.InitialDirectory = fInfo.Directory.FullName;
            }
            openFileDialog1.Filter = "Vibz Project files (*.vproj)|*.vproj";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!System.IO.File.Exists(openFileDialog1.FileName))
                    throw new Exception("Invalid Project path.");

                OpenProject(openFileDialog1.FileName);
            }
        }
        void OpenDocument(string path)
        {
            try
            {
                Document.DocumentType dType = Document.DocumentFactory.GetDocumentType(path);
                switch (dType)
                {
                    case Vibz.Studio.Document.DocumentType.XML:
                        _docList = new Document.DocumentList(this);
                        _docList.OpenDocument(dType, path);
                        break;
                    case Vibz.Studio.Document.DocumentType.Project:
                        Thread tProjectLoader = new Thread(new ParameterizedThreadStart(OpenProject));
                        tProjectLoader.Start(path);
                        //OpenProject(path);
                        break;
                }
            }
            catch (Exception exc)
            {
                ShowMessageBox(exc);
            }
        }
        public void OpenProject(object oPath)
        {
            try
            {
                string path = oPath.ToString();
                if (_docList != null)
                {
                    while (_docList.Count != 0)
                    {
                        _docList[0].Close();
                    }
                }
                ClearProjectNodes();
                System.IO.FileInfo fInfo = new System.IO.FileInfo(path);
                _project = Vibz.Solution.Loader.Load(path);
                TreeNode tn = new TreeNode(fInfo.Directory.FullName);
                tn.Tag = _project;
                tn.ImageIndex = 4;
                tn.SelectedImageIndex = 5;
                AddProjectNode(tn);
                AddNodesToProject(tn, _project.SubElements);
                ShowSolutionPanel();
                _docList = new Document.DocumentList(this, _project);
                configurationToolStripMenuItem.Enabled = true;

                App.Default.ProjectLocation = path;
                App.Default.Save();
            }
            catch (Exception exc)
            {
                ShowMessageBox(exc);
            }
        }
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                timerStatus.Start();
                List<Wizard.Wizard> wizList = new List<Vibz.Studio.Wizard.Wizard>();
                wizList.Add(new Vibz.Studio.Wizard.ProjectLocation());
                wizList.Add(new Vibz.Studio.Wizard.ProjectSettings());
                wizList.Add(new Vibz.Studio.Wizard.ProjectReport());
                Wizard.WizardContainer wCon = new Vibz.Studio.Wizard.WizardContainer(wizList);
                if (wCon.ShowDialog() != DialogResult.Cancel)
                {
                    string templatePath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName + "\\template\\newproject.zip";
                    if (!File.Exists(templatePath))
                        throw new Exception("New Project template not found.");
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("ProjectLocation", wCon.WizardParameterList[0][Vibz.Studio.Wizard.ProjectLocation.FolderPath].ToString());
                    param.Add("ProjectName", wCon.WizardParameterList[0][Vibz.Studio.Wizard.ProjectLocation.ProjectName].ToString());
                    param.Add("BuildPath", wCon.WizardParameterList[1][Vibz.Studio.Wizard.ProjectSettings.BuildPath].ToString());
                    param.Add("ReportPath", wCon.WizardParameterList[2][Vibz.Studio.Wizard.ProjectReport.FolderPath].ToString());
                    Vibz.Plugin.TemplateProcessor tProcessor = new Vibz.Plugin.TemplateProcessor(templatePath, param);
                    if (tProcessor.Execute())
                    {
                        string path = wCon.WizardParameterList[0][Vibz.Studio.Wizard.ProjectLocation.FolderPath] +
                        "/" + wCon.WizardParameterList[0][Vibz.Studio.Wizard.ProjectLocation.ProjectName] +
                        "/" + wCon.WizardParameterList[0][Vibz.Studio.Wizard.ProjectLocation.ProjectName] + ".vproj";

                        OpenProject(path);
                        
                    }
                }

            }
            catch (Exception exc)
            {
                ShowMessageBox(exc);
            }
            finally
            {
                timerStatus.Stop();            
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_docList != null && _docList.Current != null)
                _docList.Current.Save();
            lblStatus.Text = "Item Saved";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_docList != null && _docList.Current != null)
                _docList.Current.SaveAs();
            lblStatus.Text = "Item Saved";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddNodesToProject(TreeNode parentNode, List<IElement> elements)
        {
            foreach (IElement ele in elements)
            {
                TreeNode tn = new TreeNode(ele.Name);
                tn.Tag = ele;
                switch (ele.Type)
                {
                    case ElementType.Case:
                        tn.ToolTipText = "Case file\r\nFunction Count: " + ((CaseFile)ele).Functions.Count.ToString();
                        tn.ImageIndex = 2;
                        AddNodesToProject(tn, ((CaseFile)ele).Functions);
                        break;
                    case ElementType.Function:
                        tn.ToolTipText = "Function";
                        tn.ImageIndex = 0;
                        break;
                    case ElementType.Identifier:
                        tn.ToolTipText = "Identifier file";
                        tn.ImageIndex = 1;
                        break;
                    case ElementType.Space:
                        tn.ToolTipText = "NameSpace";
                        tn.ImageIndex = 4;
                        AddNodesToProject(tn, ((Space)ele).SubElements);
                        tn.SelectedImageIndex = 5;
                        break;
                    case ElementType.Suite:
                        tn.ToolTipText = "Suite file";
                        tn.ImageIndex = 3;
                        break;
                    case ElementType.ApplicationGlobal:
                        tn.ToolTipText = "Application Global";
                        tn.ImageIndex = 6;
                        AddNodesToProject(tn, ((ApplicationGlobalFile)ele).Functions);
                        break;
                    default:
                        break;
                }
                if (ele.HasError)
                {
                    tn.ToolTipText += "\r\n" + ele.Error;
                    tn.ImageIndex = 7;
                }
                tn.SelectedImageIndex = tn.ImageIndex;
                parentNode.Nodes.Add(tn);
                parentNode.ExpandAll();
            }
        }

        private void showToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlTool.Visible = showToolbarToolStripMenuItem.Checked;
        }
        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IElement ele = CurrentDocumentElement;
            if (ele == null)
                ShowMessageBox("To execute you must select a valid test suite file.");
            PerformAction(Vibz.TaskType.Compile, ele);
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IElement ele = CurrentDocumentElement;
            if (ele == null)
                ShowMessageBox("To execute you must select a valid test suite file.");
            PerformAction(Vibz.TaskType.Execute, ele);
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopTask();
        }
        private IElement CurrentDocumentElement
        {
            get
            {
                if (_docList.Current == null)
                {
                    ShowMessageBox("Please select a document.");
                    return null;
                }

                IElement element = null;
                switch (_docList.Current.Type)
                {
                    case Vibz.Studio.Document.DocumentType.TestSuite:
                        element = ((Document.TestSuite)_docList.Current).Suite;
                        break;
                    default:
                        break;
                }
                return element;
            }
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO : Do Search
            ShowMessageBox("This feature is not present in this version of tool.");
        }
        private void tvLeft_AfterExpand(object sender, TreeViewEventArgs e)
        {
            ExpandCollapseNode(e.Node, true);
        }

        private void tvLeft_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            ExpandCollapseNode(e.Node, false);
        }

        private void ExpandCollapseNode(TreeNode node, bool expand)
        {
            IElement ele = (IElement)node.Tag;
            if (ele.Type == ElementType.Space)
                node.ImageIndex = (expand ? 5 : 4);
        }

        private void aboutVibzworldAutomationStudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutStudio astudio = new AboutStudio();
            astudio.ShowDialog();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_project == null)
            {
                ShowMessageBox("Select a project to view the configurations.");
                return;
            }
            Configuration config = new Configuration(_project);
            config.ShowDialog();
        }
        private void settingsStripMenuItem3_Click(object sender, EventArgs e)
        {
            StudioSettings settings = new StudioSettings();
            settings.ShowDialog();
        }


        private void aPISupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApiDocument doc = new ApiDocument();
            doc.Show();
        }
        #endregion

        #region Context Menu Event
        public delegate void eventDelegate(object sender, EventArgs e);
        private void tvLeft_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            cmsTVLeft.Items.Clear();
            tvLeft.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                IElement ele = (IElement)e.Node.Tag;
                switch (ele.Type)
                {
                    case ElementType.Function:
                        AddMenuItem("Add to new Suite list.", ele, new eventDelegate(tsiNewTestSuite_Click));
                        if (_docList.Current != null && _docList.Current.Type == Document.DocumentType.TestSuite)
                            AddMenuItem("Add to current Suite list.", ele, new eventDelegate(tsiCurrentTestSuite_Click));
                        break;
                    case ElementType.Space:
                        AddMenuItem("Refresh", ele, new eventDelegate(tsiRefresh_Click));
                        AddMenuItem("New Folder", ele, new eventDelegate(tsiNewFolder_Click));
                        AddMenuItem("Add new case file", ele, new eventDelegate(tsiNewCase_Click));
                        break;
                    case ElementType.Suite:
                        AddMenuItem("Open", ele, new eventDelegate(tsiEditTestSuite_Click));
                        AddMenuItem("Add to new Suite list.", ele, new eventDelegate(tsiNewTestSuite_Click));
                        if (_docList.Current != null && _docList.Current.Type == Document.DocumentType.TestSuite)
                            AddMenuItem("Add to current Suite list.", ele, new eventDelegate(tsiCurrentTestSuite_Click));
                        AddMenuItem("Schedule", ele, new eventDelegate(tsiScheduleTestSuite_Click));
                        break;
                }
                AddMenuItem("Delete", ele, new eventDelegate(tsiDeleteTestSuite_Click));
                cmsTVLeft.Show(this.tvLeft, e.Location);
            }
        }
        private void tvLeft_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            if (e.Button == MouseButtons.Left)
            {
                IElement ele = (IElement)e.Node.Tag;
                switch (ele.Type)
                {
                    case ElementType.ApplicationGlobal:
                    case ElementType.Case:
                    case ElementType.Identifier:
                    case ElementType.Function:
                    case ElementType.Suite:
                        EditDocument((IElement)e.Node.Tag);
                        break;
                }
            }
        }
        public void AddMenuItem(string text, IElement tagElement, eventDelegate eDelegate)
        {
            ToolStripMenuItem tsi = new ToolStripMenuItem(text);
            tsi.Tag = tagElement;
            tsi.Click += new EventHandler(eDelegate);
            cmsTVLeft.Items.Add(tsi);
        }
        void tsiRefresh_Click(object sender, EventArgs e)
        {
            RefreshNode(tvLeft.SelectedNode);
        }
        void RefreshNode(TreeNode node)
        {
            switch (((IElement)node.Tag).Type)
            {
                case ElementType.Space:
                    Space spc = (Space)node.Tag;
                    spc.Load();
                    node.Nodes.Clear();
                    AddNodesToProject(node, spc.SubElements);
                    break;
                default:
                    break;
            }
            
        }
        void tsiEditTestSuite_Click(object sender, EventArgs e)
        {
            EditDocument((IElement)((ToolStripMenuItem)sender).Tag);
        }
        void EditDocument(IElement element)
        {
            try
            {
                string path = element.Path;
                Document.IDocument doc = _docList.Find(path);
                if (doc == null)
                {
                    Document.DocumentType type = Document.DocumentFactory.GetDocumentType(element);
                    if (type == Document.DocumentType.None)
                        return;
                    _docList.OpenDocument(type, path);
                    if (type == Document.DocumentType.TestSuite)
                    {
                        compileToolStripMenuItem.Enabled = true;
                        runToolStripMenuItem.Enabled = true;
                        btnRun.Enabled = true;
                        btnCompile.Enabled = true;
                    }
                }
                else
                    doc.Focus();
            }
            catch (Exception exc)
            {
                ShowMessageBox(exc);
            }
        }
        void tsiScheduleTestSuite_Click(object sender, EventArgs e)
        {
            ScheduleOutput((IElement)((ToolStripMenuItem)sender).Tag);
        }
        void ScheduleOutput(IElement element)
        {

            Process p = new Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%comspec%");
            p.StartInfo.Arguments = "/c vauto -s -f=\"" + GetBuildFileName(element) + "\"";

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WorkingDirectory = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName;
            p.Start();
        }
        void tsiNewTestSuite_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Testsuite files (*.ts)|*.ts";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _docList.CreateDocument(Vibz.Studio.Document.DocumentType.TestSuite, saveFileDialog1.FileName);
                
                SuiteElement se = (SuiteElement)((ToolStripMenuItem)sender).Tag;
                AddToCurrentSuite(se);

                RefreshNode(tvLeft.Nodes[0]);
                tvLeft.ExpandAll();
            }
        }
        void tsiCurrentTestSuite_Click(object sender, EventArgs e)
        {
            SuiteElement se = (SuiteElement)((ToolStripMenuItem)sender).Tag;
            AddToCurrentSuite(se);
        }
        void AddToCurrentSuite(SuiteElement se)
        {
            try
            {
                if (se.Type == ElementType.Suite && ((Document.TestSuite)_docList.Current).Suite.CheckRecursiveWith((SuiteFile)se))
                    ShowMessageBox("Recursive suite call is invalid.");
                else
                {
                    SuiteElement seClone = (SuiteElement)se.Clone;
                    if (se.Type != ElementType.Suite)
                        seClone.Load();
                    _docList.Current.Add(seClone);
                }
            }
            catch (Exception exc)
            {
                ShowMessageBox(exc);
            }
        }
        void tsiDeleteTestSuite_Click(object sender, EventArgs e)
        {
            DeleteNode(tvLeft.SelectedNode);
        }
        void DeleteNode(TreeNode node)
        {
            string userMessage = "Are you sure you want to delete this element.";
            switch (((IElement)node.Tag).Type)
            {
                case ElementType.Space:
                case ElementType.Project:
                    userMessage = "Are you sure you want to delete this folder and all its content.";
                    break;
            }
            if (MessageBox.Show(userMessage,"Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                switch (((IElement)node.Tag).Type)
                {
                    case ElementType.Project:
                        MessageBox.Show("Project can not be deleted.");
                        break;
                    case ElementType.Function:
                        MessageBox.Show("Function can not be deleted.");
                        break;
                    case ElementType.Case:
                    case ElementType.Identifier:
                    case ElementType.Suite:
                        File.Delete(((IElement)node.Tag).Path);
                        tvLeft.Nodes.Remove(node);
                        break;
                    case ElementType.Space:
                        Directory.Delete(((IElement)node.Tag).Path, true);
                        tvLeft.Nodes.Remove(node);
                        break;
                }
            }
        }
        void tsiNewCase_Click(object sender, EventArgs e)
        {
            CreateCaseFile(tvLeft.SelectedNode);
        }
        void tsiNewFolder_Click(object sender, EventArgs e)
        {
            CreateSpaceNode(tvLeft.SelectedNode);
        }
        void CreateSpaceNode(TreeNode node)
        {
            if (node.Tag == null)
                return;
            Space spc = (Space)node.Tag;
            UserInput.GetUserValue uNew = new Vibz.Studio.UserInput.GetUserValue("New folder", "Folder name", "Create");
            if (uNew.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo dInfo = Directory.CreateDirectory(Path.Combine(spc.Path, uNew.Value));
                Space newSpace = _project.CreateSpace(dInfo);
                List<IElement> lst = new List<IElement>();
                lst.Add(newSpace);
                AddNodesToProject(node, lst);
            }
            
        }
        void CreateCaseFile(TreeNode node)
        {
            if (node.Tag == null)
                return;
            Space spc = (Space)node.Tag;
            UserInput.GetUserValue uNew = new Vibz.Studio.UserInput.GetUserValue("New Case file", "Case file name", "Create");
            if (uNew.ShowDialog() == DialogResult.OK)
            {
                string casePath=Path.Combine(spc.Path, uNew.Value) + "." + Vibz.FileType.TestCase;
                string idPath=Path.Combine(spc.Path, uNew.Value) + "." + Vibz.FileType.Identifier;

                string baseFolder = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName;
                File.AppendAllText(casePath, File.ReadAllText(Path.Combine(baseFolder, "Template/NewProject/case1.tc")).Replace("case1", uNew.Value));
                File.AppendAllText(idPath, File.ReadAllText(Path.Combine(baseFolder, "Template/NewProject/case1.id")).Replace("case1", uNew.Value));

                CaseFile newCaseFile = _project.CreateCase(new FileInfo(casePath));
                IdentifierFile newIdFile = _project.CreateIdentifier(new FileInfo(idPath));
                
                List<IElement> lst = new List<IElement>();
                lst.Add(newCaseFile);
                lst.Add(newIdFile);

                AddNodesToProject(node, lst);
            }
        }
        #endregion

        #region Project Event
        private void tvLeft_ItemDrag(object sender, ItemDragEventArgs e)
        {
            tvLeft.SelectedNode = (TreeNode)e.Item;
            IElement element = ((IElement)((TreeNode)e.Item).Tag).Clone;
            if (element != null)
                ((TreeView)sender).DoDragDrop(element, DragDropEffects.Move);
        }
        private void tvLeft_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion

        #region Compile And Run
        Thread _taskThread = null;
        void StopTask()
        {
            if (_taskThread != null && _taskThread.IsAlive)
                _taskThread.Abort();
        }
        string GetBuildFileName(IElement element)
        {
            return _project.BuildLocation + "/" + element.Name + "." + Vibz.FileType.CompiledScript;
        }
        object PerformAction(Vibz.TaskType type, IElement element)
        {
            if (element == null)
                return null;
            object arg = null;
            rtbLogSummary.Clear();
            switch (type)
            {
                case Vibz.TaskType.Compile:
                    if (_docList != null && _docList.Current != null)
                    {
                        _project.Queue.Enqueue(new LogQueueElement("Saving the document.", LogSeverity.Trace));
                        _docList.Current.Save();
                    }

                    _currentTask = new Compiler(App.Default.EncodeBuild);
                    if (!Directory.Exists(_project.BuildLocation))
                        Vibz.Helper.IO.CreateFolderPath(new DirectoryInfo(_project.BuildLocation));

                    arg = new object[] { element, GetBuildFileName(element) };
                    _project.Queue.Enqueue(new LogQueueElement("Compiling document.", LogSeverity.Trace));
                    break;
                case Vibz.TaskType.Execute:
                    object cplArg = PerformAction(Vibz.TaskType.Compile, element);
                    arg = new object[] { ((object[])cplArg).GetValue(1).ToString(), Convert.ToInt32((20 - App.Default.ExecutionSpeed) * 250) };
                    _project.Queue.Enqueue(new LogQueueElement("Executing document.", LogSeverity.Trace));
                    _currentTask = new Executer();
                    break;
            }

            TaskDelegate tDelegate = new TaskDelegate(_currentTask.Process);
            _taskThread = new Thread(new ParameterizedThreadStart(ExecuteInThread));
            _taskThread.SetApartmentState(ApartmentState.STA);
            timerExecution.Start();
            _taskThread.Start(new object[] { tDelegate, arg, type });
            return arg;
        }
        
        public void ExecuteInThread(object param)
        {
            Vibz.TaskType type = Vibz.TaskType.Execute;
            try
            {
                System.Threading.Monitor.Enter(_taskLock);
                type = (Vibz.TaskType)((object[])param).GetValue(2);
                LogEvent(LogSeverity.Trace, Thread.CurrentThread.ManagedThreadId.ToString() + "\t******** " + type.ToString() + " begin *********");
                SetUserOptions(true);
                TaskDelegate del = (TaskDelegate)((object[])param).GetValue(0);
                object arg = ((object[])param).GetValue(1);
                del(arg);
            }
            finally
            {
                SetUserOptions(false);
                LogEvent(LogSeverity.Trace, Thread.CurrentThread.ManagedThreadId.ToString() + "\t******** " + type.ToString() + " end *********");
                System.Threading.Monitor.Exit(_taskLock);
            }
        }
        void SetUserOptions(bool setOnRun)
        {
            ChangeButtonStatus(btnStop, setOnRun);
            ChangeButtonStatus(btnRun, !setOnRun);
            ChangeButtonStatus(btnCompile, !setOnRun);
            ChangeMenuStatus(stopToolStripMenuItem, setOnRun);
            ChangeMenuStatus(runToolStripMenuItem, !setOnRun);
            ChangeMenuStatus(compileToolStripMenuItem, !setOnRun);
        }
        #endregion

        #region Log
        private void UpdateProgress()
        {
            switch (_currentTask.Type)
            {
                case Vibz.TaskType.Execute:
                case Vibz.TaskType.Compile:
                    while (Vibz.Contract.Log.LogQueue.Instance.Count > 0)
                    {
                        LogQueueElement ele = Vibz.Contract.Log.LogQueue.Instance.Dequeue();
                        if (_currentTask.State == Vibz.TaskState.Complete)
                        { 
                            // flush data to text file and break.
                            LogEvent(ele.Severity, ele.ThreadId + "\t" + ele.Message);
                            continue;
                        }
                        if (ele.Message == null)
                            return;
                        rtbLogSummary.SelectionFont = new Font("Arial", (float)8, FontStyle.Regular);
                        
                        LogEvent(ele.Severity, ele.ThreadId + "\t" + ele.Message);
                        
                        lblStatus.Text = ele.Message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                        switch (ele.Severity)
                        {
                            case LogSeverity.Info:
                                rtbLogSummary.SelectionColor = Color.Black;
                                rtbLogSummary.AppendText("\r\n " + ele.Message);
                                break;
                            case LogSeverity.Warn:
                                rtbLogSummary.SelectionColor = Color.Orange;
                                rtbLogSummary.AppendText("\r\n " + ele.Message);
                                break;
                            case LogSeverity.Error:
                                rtbLogSummary.SelectionColor = Color.Red;
                                rtbLogSummary.AppendText("\r\n " + ele.Message);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
            }
            rtbLogSummary.SelectionColor = Color.Black;
            switch (_currentTask.State)
            {
                case Vibz.TaskState.Complete:
                    rtbLogSummary.AppendText("\r\n_______________________________________");
                    string result = "with error.";
                    if (Vibz.Contract.Log.LogQueue.Instance.ErrorCount == 0)
                        result = "succesfuly.";
                    rtbLogSummary.AppendText("\r\n" + _currentTask.Message + result
                        + "\r\n Error:" + Vibz.Contract.Log.LogQueue.Instance.ErrorCount.ToString()
                        + "\t Warnings:" + Vibz.Contract.Log.LogQueue.Instance.WarnCount.ToString()
                        );
                    lblStatus.Text = _currentTask.Message + result;
                    rtbLogSummary.ScrollToCaret();
                    timerExecution.Stop();
                    _project.Queue.Reset();

                    PlaySound(@"wav\testcomplete.wav");
                    LogQueue.Instance.Enqueue(new LogQueueElement("Process complete.", LogSeverity.Trace));
                    SetUserOptions(false);
                    return;
                case Vibz.TaskState.Error:
                    rtbLogSummary.AppendText("\r\n" + _currentTask.Message);
                    lblStatus.Text = _currentTask.Type.ToString() + " failed.";
                    timerExecution.Stop();
                    PlaySound(@"wav\executionfailed.wav");
                    SetUserOptions(false);
                    return;
                case Vibz.TaskState.NotStarted:
                case Vibz.TaskState.Processing:
                    break;
            }
        }
        private void UpdateStatusBar()
        {
            while (LogQueue.Instance.Count > 0)
            {
                LogQueueElement ele = LogQueue.Instance.Dequeue();
                lblStatus.Text = ele.Message;
                switch (ele.Severity)
                {
                    case LogSeverity.Trace:
                    case LogSeverity.Warn:
                        break;
                    case LogSeverity.Error:
                        lblStatus.Text = "Done with error. Click here to see error message.";
                        _errorMessage = ele.Message + "\r\n" + _errorMessage;
                        break;
                    default:
                        break;
                }
            }
        }
        void lblStatus_Click(object sender, EventArgs e)
        {
            if (_errorMessage != "")
                MessageBox.Show(_errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        void timerExecution_Tick(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void rtbLogSummary_TextChanged(object sender, EventArgs e)
        {
            pnlLog.Visible = (rtbLogSummary.Text.Trim() != "");

        }
        #endregion
        
        #region Panel Sollution
        bool allowResize = false;
        private void pbSolPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            allowResize = false;
        }
        private void pbSolPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (allowResize)
            {
                this.pnlSol.Width -= e.X;
            }
        }
        private void pbSolPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            allowResize = true;
        }
        #endregion

        #region Panel Log
        bool allowLogResize = false;
        private void pbPnlLog_MouseDown(object sender, MouseEventArgs e)
        {
            allowLogResize = true;
        }

        private void pbPnlLog_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowLogResize)
                this.pnlLog.Height = this.pnlLog.Height + (pbPnlLog.Top - e.Y);
        }

        private void pbPnlLog_MouseUp(object sender, MouseEventArgs e)
        {
            allowLogResize = false;
        }
        #endregion

        #region Common Function
        void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
        void ShowMessageBox(Exception exc)
        {
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion


        #region Panel Toolbox
        bool allowToolDock = false;
        int delX = 0;
        int delY = 0;
        private void pnlToolHead_MouseDown(object sender, MouseEventArgs e)
        {
            allowToolDock = true;
            delX = e.X; 
            delY = e.Y;
            pnlTool.Dock = DockStyle.None;
        }

        private void pnlToolHead_MouseUp(object sender, MouseEventArgs e)
        {
            allowToolDock = false;
            if (pnlTool.Left < 20)
                pnlTool.Dock = DockStyle.Left;
            else
                pnlTool.Dock = DockStyle.None;
        }

        private void pnlToolHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowToolDock)
            {
                pnlTool.Left += e.X - delX;
                pnlTool.Top += e.Y - delY;
            }
        }


        bool allowToolResize = false;
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            allowToolResize = true;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowToolResize)
            {
                pnlTool.Width += e.X;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            allowToolResize = false;
        }
        #endregion

        #region User Selection Events
        private void loggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Default.LogEvents = ((System.Windows.Forms.ToolStripMenuItem)sender).Checked;
            App.Default.Save();
        }
        private void playSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Default.PlaySound = ((System.Windows.Forms.ToolStripMenuItem)sender).Checked;
            App.Default.Save();
        }

        private void encodeBuildOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Default.EncodeBuild = ((System.Windows.Forms.ToolStripMenuItem)sender).Checked;
            App.Default.Save();
        }
        private void PlaySound(string soundFile)
        {
            try
            {
                if (App.Default.PlaySound)
                {
                    System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                    myPlayer.SoundLocation = Path.Combine(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName, soundFile);
                    myPlayer.Play();
                }
            }
            catch (Exception exc)
            { }
        }

        #endregion

        #region Thread functions
        private delegate void ObjectDelegate(TreeNode node);
        public void AddProjectNode(TreeNode node)
        {
            if (tvLeft.InvokeRequired)
            {
                ObjectDelegate method = new ObjectDelegate(AddProjectNode);
                Invoke(method, node);
            }
            else
            {
                tvLeft.Nodes.Add(node);
                node.Expand();
            }
        }
        public void ClearProjectNodes()
        {
            if (tvLeft.InvokeRequired)
            {
                tvLeft.Invoke(new MethodInvoker(this.ClearProjectNodes));
            }
            else
            {
                tvLeft.Nodes.Clear();
            }
        }
        public void ShowSolutionPanel()
        {
            if (pnlSol.InvokeRequired)
            {
                pnlSol.Invoke(new MethodInvoker(this.ShowSolutionPanel));
            }
            else
            {
                pnlSol.Visible = true;
            }
        }
        private delegate void ButtonDelegate(ToolStripButton btn, bool status);
        public void ChangeButtonStatus(ToolStripButton btn, bool status)
        {
            if (toolStrip1.InvokeRequired)
            {
                ButtonDelegate d = new ButtonDelegate(ChangeButtonStatus);
                toolStrip1.Invoke(d, new object[] { btn, status });
            }
            else
            {
                btn.Enabled = status;
            }
        }
        private delegate void MenuDelegate(ToolStripMenuItem menu, bool status);
        public void ChangeMenuStatus(ToolStripMenuItem menu, bool status)
        {
            if (menuStrip1.InvokeRequired)
            {
                MenuDelegate d = new MenuDelegate(ChangeMenuStatus);
                menuStrip1.Invoke(d, new object[] { menu, status });
            }
            else
            {
                menu.Enabled = status;
            }
        }
        private void LogEvent(Vibz.Contract.Log.LogSeverity severity, string message)
        {
            try
            {
                if (App.Default.LogEvents && (int)severity >= (int)App.Default.LogSeverity)
                {
                    System.IO.File.AppendAllText(App.Default.LogPath, "\r\n" + DateTime.Now.ToLongTimeString() + "\t" + severity.ToString() + "\t" + message);
                }
            }
            catch (Exception exc)
            { }
        }
        

        #endregion


    }
}
