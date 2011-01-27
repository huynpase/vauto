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
namespace Vibz.Studio.Controls
{
    partial class Toolbox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toolbox));
            this.tvContainer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvContainer
            // 
            this.tvContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContainer.FullRowSelect = true;
            this.tvContainer.ImageIndex = 4;
            this.tvContainer.ImageList = this.imageList1;
            this.tvContainer.Location = new System.Drawing.Point(2, 2);
            this.tvContainer.Name = "tvContainer";
            this.tvContainer.SelectedImageIndex = 0;
            this.tvContainer.ShowLines = false;
            this.tvContainer.ShowRootLines = false;
            this.tvContainer.Size = new System.Drawing.Size(176, 433);
            this.tvContainer.TabIndex = 0;
            this.tvContainer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvContainer_ItemDrag);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fetch.ico");
            this.imageList1.Images.SetKeyName(1, "Comments.png");
            this.imageList1.Images.SetKeyName(2, "assert.ico");
            this.imageList1.Images.SetKeyName(3, "macro.ico");
            this.imageList1.Images.SetKeyName(4, "instruction.ico");
            this.imageList1.Images.SetKeyName(5, "macrovar.png");
            this.imageList1.Images.SetKeyName(6, "macrofunc.ico");
            this.imageList1.Images.SetKeyName(7, "action.ico");
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvContainer);
            this.Name = "Toolbox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(180, 437);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvContainer;
        private System.Windows.Forms.ImageList imageList1;
    }
}
