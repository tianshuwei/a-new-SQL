namespace aWorkbench
{
	partial class workbench
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("TableA");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tables", new System.Windows.Forms.TreeNode[] {
            treeNode1});
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "233",
            "12"}, -1);
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusMsg = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.mainContainer = new System.Windows.Forms.SplitContainer();
			this.viewContainer = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblDatabase = new System.Windows.Forms.Label();
			this.lblDatabaseName = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.editContainer = new System.Windows.Forms.SplitContainer();
			this.tabs = new System.Windows.Forms.TabControl();
			this.consoleTab = new System.Windows.Forms.TabPage();
			this.lstConsoleMsg = new System.Windows.Forms.ListView();
			this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.viewTab = new System.Windows.Forms.TabPage();
			this.dataGridResult = new System.Windows.Forms.DataGridView();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripEditTable = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editorTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripbtnRun = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripbtnCpy = new System.Windows.Forms.ToolStripButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.statusStrip.SuspendLayout();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
			this.mainContainer.Panel1.SuspendLayout();
			this.mainContainer.Panel2.SuspendLayout();
			this.mainContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewContainer)).BeginInit();
			this.viewContainer.Panel1.SuspendLayout();
			this.viewContainer.Panel2.SuspendLayout();
			this.viewContainer.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.editContainer)).BeginInit();
			this.editContainer.Panel1.SuspendLayout();
			this.editContainer.Panel2.SuspendLayout();
			this.editContainer.SuspendLayout();
			this.tabs.SuspendLayout();
			this.consoleTab.SuspendLayout();
			this.viewTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.menuStripEditTable.SuspendLayout();
			this.editorTableLayout.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMsg});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusStrip.Size = new System.Drawing.Size(1132, 25);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// statusMsg
			// 
			this.statusMsg.Name = "statusMsg";
			this.statusMsg.Size = new System.Drawing.Size(29, 20);
			this.statusMsg.Text = "     ";
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.mainContainer);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1132, 532);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(1132, 585);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
			// 
			// mainContainer
			// 
			this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainContainer.Location = new System.Drawing.Point(0, 0);
			this.mainContainer.Name = "mainContainer";
			// 
			// mainContainer.Panel1
			// 
			this.mainContainer.Panel1.Controls.Add(this.viewContainer);
			this.mainContainer.Panel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			// 
			// mainContainer.Panel2
			// 
			this.mainContainer.Panel2.Controls.Add(this.editContainer);
			this.mainContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.mainContainer.Size = new System.Drawing.Size(1132, 532);
			this.mainContainer.SplitterDistance = 262;
			this.mainContainer.TabIndex = 1;
			// 
			// viewContainer
			// 
			this.viewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewContainer.Location = new System.Drawing.Point(5, 0);
			this.viewContainer.Name = "viewContainer";
			this.viewContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// viewContainer.Panel1
			// 
			this.viewContainer.Panel1.Controls.Add(this.panel1);
			// 
			// viewContainer.Panel2
			// 
			this.viewContainer.Panel2.Controls.Add(this.treeView1);
			this.viewContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.viewContainer.Size = new System.Drawing.Size(257, 532);
			this.viewContainer.SplitterDistance = 192;
			this.viewContainer.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblDatabase);
			this.panel1.Controls.Add(this.lblDatabaseName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 172);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(257, 20);
			this.panel1.TabIndex = 3;
			// 
			// lblDatabase
			// 
			this.lblDatabase.AutoSize = true;
			this.lblDatabase.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDatabase.Location = new System.Drawing.Point(3, 0);
			this.lblDatabase.Name = "lblDatabase";
			this.lblDatabase.Size = new System.Drawing.Size(61, 15);
			this.lblDatabase.TabIndex = 1;
			this.lblDatabase.Text = "Name: ";
			// 
			// lblDatabaseName
			// 
			this.lblDatabaseName.AutoSize = true;
			this.lblDatabaseName.Location = new System.Drawing.Point(70, 0);
			this.lblDatabaseName.Name = "lblDatabaseName";
			this.lblDatabaseName.Size = new System.Drawing.Size(55, 15);
			this.lblDatabaseName.TabIndex = 2;
			this.lblDatabaseName.Text = "hahaDB";
			// 
			// treeView1
			// 
			this.treeView1.ContextMenuStrip = this.menuStripEditTable;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "TableA";
			treeNode1.Text = "TableA";
			treeNode2.Name = "ndeTable";
			treeNode2.Text = "Tables";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
			this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.treeView1.Size = new System.Drawing.Size(257, 331);
			this.treeView1.TabIndex = 0;
			// 
			// editContainer
			// 
			this.editContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editContainer.Location = new System.Drawing.Point(0, 0);
			this.editContainer.Name = "editContainer";
			this.editContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// editContainer.Panel1
			// 
			this.editContainer.Panel1.Controls.Add(this.editorTableLayout);
			// 
			// editContainer.Panel2
			// 
			this.editContainer.Panel2.Controls.Add(this.tabs);
			this.editContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.editContainer.Size = new System.Drawing.Size(861, 532);
			this.editContainer.SplitterDistance = 265;
			this.editContainer.TabIndex = 0;
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.consoleTab);
			this.tabs.Controls.Add(this.viewTab);
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.Location = new System.Drawing.Point(0, 10);
			this.tabs.Name = "tabs";
			this.tabs.Padding = new System.Drawing.Point(10, 5);
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(861, 253);
			this.tabs.TabIndex = 1;
			// 
			// consoleTab
			// 
			this.consoleTab.Controls.Add(this.lstConsoleMsg);
			this.consoleTab.Location = new System.Drawing.Point(4, 29);
			this.consoleTab.Name = "consoleTab";
			this.consoleTab.Padding = new System.Windows.Forms.Padding(3);
			this.consoleTab.Size = new System.Drawing.Size(853, 220);
			this.consoleTab.TabIndex = 0;
			this.consoleTab.Text = "console";
			this.consoleTab.UseVisualStyleBackColor = true;
			// 
			// lstConsoleMsg
			// 
			this.lstConsoleMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colMsg});
			this.lstConsoleMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstConsoleMsg.FullRowSelect = true;
			this.lstConsoleMsg.GridLines = true;
			this.lstConsoleMsg.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
			this.lstConsoleMsg.Location = new System.Drawing.Point(3, 3);
			this.lstConsoleMsg.Name = "lstConsoleMsg";
			this.lstConsoleMsg.Size = new System.Drawing.Size(847, 214);
			this.lstConsoleMsg.TabIndex = 0;
			this.lstConsoleMsg.UseCompatibleStateImageBehavior = false;
			this.lstConsoleMsg.View = System.Windows.Forms.View.Details;
			// 
			// colType
			// 
			this.colType.Text = "Type";
			this.colType.Width = 100;
			// 
			// colMsg
			// 
			this.colMsg.Text = "message";
			this.colMsg.Width = 664;
			// 
			// viewTab
			// 
			this.viewTab.Controls.Add(this.dataGridResult);
			this.viewTab.Location = new System.Drawing.Point(4, 29);
			this.viewTab.Name = "viewTab";
			this.viewTab.Padding = new System.Windows.Forms.Padding(3);
			this.viewTab.Size = new System.Drawing.Size(853, 220);
			this.viewTab.TabIndex = 1;
			this.viewTab.Text = "views";
			this.viewTab.UseVisualStyleBackColor = true;
			// 
			// dataGridResult
			// 
			this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridResult.Location = new System.Drawing.Point(3, 3);
			this.dataGridResult.Name = "dataGridResult";
			this.dataGridResult.RowTemplate.Height = 27;
			this.dataGridResult.Size = new System.Drawing.Size(847, 214);
			this.dataGridResult.TabIndex = 0;
			// 
			// menuStrip
			// 
			this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1132, 28);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// filesToolStripMenuItem
			// 
			this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
			this.filesToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.filesToolStripMenuItem.Text = "Files";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// menuStripEditTable
			// 
			this.menuStripEditTable.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStripEditTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTableToolStripMenuItem,
            this.refreshToolStripMenuItem});
			this.menuStripEditTable.Name = "menuStripEditTable";
			this.menuStripEditTable.Size = new System.Drawing.Size(167, 52);
			// 
			// addTableToolStripMenuItem
			// 
			this.addTableToolStripMenuItem.Name = "addTableToolStripMenuItem";
			this.addTableToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
			this.addTableToolStripMenuItem.Text = "Add table ...";
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
			this.refreshToolStripMenuItem.Text = "Refresh";
			// 
			// editorTableLayout
			// 
			this.editorTableLayout.ColumnCount = 1;
			this.editorTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.editorTableLayout.Controls.Add(this.toolStrip1, 0, 0);
			this.editorTableLayout.Controls.Add(this.textBox1, 0, 1);
			this.editorTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editorTableLayout.Location = new System.Drawing.Point(0, 0);
			this.editorTableLayout.Margin = new System.Windows.Forms.Padding(0);
			this.editorTableLayout.Name = "editorTableLayout";
			this.editorTableLayout.RowCount = 2;
			this.editorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editorTableLayout.Size = new System.Drawing.Size(861, 265);
			this.editorTableLayout.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtnRun,
            this.toolStripSeparator1,
            this.toolStripbtnCpy});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(861, 27);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripbtnRun
			// 
			this.toolStripbtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripbtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripbtnRun.Name = "toolStripbtnRun";
			this.toolStripbtnRun.Size = new System.Drawing.Size(37, 24);
			this.toolStripbtnRun.Text = "run";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// toolStripbtnCpy
			// 
			this.toolStripbtnCpy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripbtnCpy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripbtnCpy.Name = "toolStripbtnCpy";
			this.toolStripbtnCpy.Size = new System.Drawing.Size(49, 24);
			this.toolStripbtnCpy.Text = "copy";
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(0, 27);
			this.textBox1.Margin = new System.Windows.Forms.Padding(0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBox1.Size = new System.Drawing.Size(861, 238);
			this.textBox1.TabIndex = 2;
			// 
			// workbench
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1132, 585);
			this.Controls.Add(this.toolStripContainer1);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "workbench";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "aWorkBench";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.mainContainer.Panel1.ResumeLayout(false);
			this.mainContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
			this.mainContainer.ResumeLayout(false);
			this.viewContainer.Panel1.ResumeLayout(false);
			this.viewContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.viewContainer)).EndInit();
			this.viewContainer.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.editContainer.Panel1.ResumeLayout(false);
			this.editContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.editContainer)).EndInit();
			this.editContainer.ResumeLayout(false);
			this.tabs.ResumeLayout(false);
			this.consoleTab.ResumeLayout(false);
			this.viewTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.menuStripEditTable.ResumeLayout(false);
			this.editorTableLayout.ResumeLayout(false);
			this.editorTableLayout.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusMsg;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.SplitContainer mainContainer;
		private System.Windows.Forms.SplitContainer editContainer;
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage consoleTab;
		private System.Windows.Forms.TabPage viewTab;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ListView lstConsoleMsg;
		private System.Windows.Forms.ColumnHeader colType;
		private System.Windows.Forms.ColumnHeader colMsg;
		private System.Windows.Forms.SplitContainer viewContainer;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblDatabase;
		private System.Windows.Forms.Label lblDatabaseName;
		private System.Windows.Forms.DataGridView dataGridResult;
		private System.Windows.Forms.ContextMenuStrip menuStripEditTable;
		private System.Windows.Forms.ToolStripMenuItem addTableToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel editorTableLayout;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripbtnRun;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripbtnCpy;
		private System.Windows.Forms.TextBox textBox1;
	}
}

