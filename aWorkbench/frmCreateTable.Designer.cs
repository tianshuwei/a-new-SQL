namespace aWorkbench
{
	partial class frmCreateTable
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView2 = new System.Windows.Forms.ListView();
            this.table_name = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.value = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.attribute = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.empty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(142, 45);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(229, 79);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(16, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.empty);
            this.splitContainer1.Panel1.Controls.Add(this.cancel);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel1.Controls.Add(this.type);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.attribute);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.submit);
            this.splitContainer1.Panel1.Controls.Add(this.value);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.table_name);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(780, 417);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 1;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(42, 54);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(249, 137);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // table_name
            // 
            this.table_name.AutoSize = true;
            this.table_name.Location = new System.Drawing.Point(39, 16);
            this.table_name.Name = "table_name";
            this.table_name.Size = new System.Drawing.Size(87, 15);
            this.table_name.TabIndex = 0;
            this.table_name.Text = "table_name";
            this.table_name.Click += new System.EventHandler(this.table_name_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "int",
            "float",
            "string",
            "bool",
            "date"});
            this.comboBox1.Location = new System.Drawing.Point(126, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.Location = new System.Drawing.Point(47, 90);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(47, 15);
            this.value.TabIndex = 2;
            this.value.Text = "value";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(62, 211);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(78, 37);
            this.submit.TabIndex = 3;
            this.submit.Text = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(126, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "NULL";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // attribute
            // 
            this.attribute.AutoSize = true;
            this.attribute.Location = new System.Drawing.Point(39, 57);
            this.attribute.Name = "attribute";
            this.attribute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.attribute.Size = new System.Drawing.Size(79, 15);
            this.attribute.TabIndex = 5;
            this.attribute.Text = "attribute";
            this.attribute.Click += new System.EventHandler(this.attribute_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(126, 90);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 25);
            this.textBox2.TabIndex = 7;
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Location = new System.Drawing.Point(47, 125);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(39, 15);
            this.type.TabIndex = 8;
            this.type.Text = "type";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "int",
            "float",
            "string",
            "bool",
            "date"});
            this.comboBox2.Location = new System.Drawing.Point(126, 54);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(117, 23);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(126, 283);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(78, 37);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // empty
            // 
            this.empty.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.empty.Location = new System.Drawing.Point(178, 211);
            this.empty.Name = "empty";
            this.empty.Size = new System.Drawing.Size(78, 37);
            this.empty.TabIndex = 11;
            this.empty.Text = "empty";
            this.empty.UseVisualStyleBackColor = true;
            this.empty.Click += new System.EventHandler(this.empty_Click);
            // 
            // frmCreateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 518);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.listView1);
            this.Name = "frmCreateTable";
            this.Text = "frmCreateTable";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label attribute;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label value;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label table_name;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button empty;
        private System.Windows.Forms.Button cancel;
	}
}