namespace Vibz.Studio.Document
{
    partial class XDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XDocument));
            this.rtbTextArea = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // rtbTextArea
            // 
            this.rtbTextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTextArea.Location = new System.Drawing.Point(0, 0);
            this.rtbTextArea.Name = "rtbTextArea";
            this.rtbTextArea.Size = new System.Drawing.Size(531, 375);
            this.rtbTextArea.TabIndex = 0;
            this.rtbTextArea.Text = "";
            this.rtbTextArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbTextArea_KeyPress);
            this.rtbTextArea.TextChanged += new System.EventHandler(this.rtbTextArea_TextChanged);
            // 
            // XDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 375);
            this.Controls.Add(this.rtbTextArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XDocument";
            this.Text = "XML Document";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbTextArea;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}