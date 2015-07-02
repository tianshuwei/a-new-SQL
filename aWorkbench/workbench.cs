using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aWorkbench
{
	public partial class workbench : Form
	{
		public workbench()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//TODO refresh UIs
			//1.left top info 
			//2.table tree
			//  * use refreshTree(object sender, EventArgs e)
			//


		}

		private void createTable(object sender, EventArgs e)
		{

		}

		private void nodeClick(object sender, TreeNodeMouseClickEventArgs e)
		{	
            if (e.Node == null) return;
			if (e.Button == MouseButtons.Right)
			{
				switch (e.Node.Level) {
					case 0://顶层 Tables
						break;
					case 1:// TableA
						break;
					case 2://col1
						ToolStripMenuItem tsmi = new ToolStripMenuItem("remove col " + e.Node.Text);
						tsmi.Click += new System.EventHandler(
							(object _sender, EventArgs _e) => {
								//do something
							}
							);
						menuStripEditTable.Items.RemoveAt(0);
						menuStripEditTable.Items.Insert(0, tsmi);
						break;
				}
			}

		}

		private void refreshTree(object sender, EventArgs e)// get tables from server and create tree
		{

		}

		private void runCmds(object sender, EventArgs e)
		{

		}

		private void cpyToClipboard(object sender, EventArgs e)
		{

		}

		private void openScript(object sender, EventArgs e)
		{

		}


	}
}
