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
using System.Windows.Forms;

namespace Vibz.Forms
{
	/// <summary>
	/// This form is takes care of maximizing itself if it is the first
	/// Mdi child added to its MdiParent form.
	/// </summary>
	public partial class MdiChildForm : Form
	{
		#region Construction

		/// <summary>
		/// Constructs a new MdiChildForm.
		/// </summary>
		public MdiChildForm()
		{
			InitializeComponent();
		}
		#endregion //--Construction


		#region Overrides

		/// <summary>
		/// Overridden. Eliminates the normal close box. This is not strictly
		/// necessary, but it looks more professional.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				const int CS_NOCLOSE = 0x200;
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= CS_NOCLOSE;
				return cp;
			}
		}

		/// <summary>
		/// Overridden. Sets WindowState to maximized if it is the first
		/// Mdi child added to its MdiParent.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (null != MdiParent && MdiParent.MdiChildren.Length <= 1)
				WindowState = FormWindowState.Maximized;
		}
		#endregion //--Overrides
	}
}
