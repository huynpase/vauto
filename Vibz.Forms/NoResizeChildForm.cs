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
	public partial class NoResizeChildForm : Form
	{
		#region Construction

		/// <summary>
		/// Creates a new NoResizeChildForm.
		/// </summary>
		public NoResizeChildForm()
		{
			InitializeComponent();
		}
		#endregion //--Construction


		#region Overrides

		/// <summary>
		/// Overridden. Sets WindowState to maximized if it is the first
		/// Mdi child added to its MdiParent.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			WindowState = FormWindowState.Maximized;
		}
		#endregion //--Overrides
	}
}
