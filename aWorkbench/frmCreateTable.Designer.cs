namespace aWorkbench
{
    partial class ComboBoxForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnull = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "int",
            "string"});
            this.comboBox1.Location = new System.Drawing.Point(556, 337);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 23);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "n",
            "y"});
            this.comboBox2.Location = new System.Drawing.Point(556, 344);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(132, 23);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Visible = false;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "primary key",
            "n"});
            this.comboBox3.Location = new System.Drawing.Point(556, 344);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(132, 23);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.Visible = false;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.cnull,
            this.typ,
            this.clhTime});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(23, 13);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(692, 380);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // name
            // 
            this.name.Tag = "";
            this.name.Text = "name";
            this.name.Width = 130;
            // 
            // cnull
            // 
            this.cnull.Tag = "";
            this.cnull.Text = "cnull";
            this.cnull.Width = 280;
            // 
            // typ
            // 
            this.typ.Tag = "";
            this.typ.Text = "type";
            this.typ.Width = 100;
            // 
            // clhTime
            // 
            this.clhTime.Tag = "";
            this.clhTime.Text = "primary key";
            this.clhTime.Width = 200;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(289, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 25);
            this.textBox1.TabIndex = 4;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(59, 32);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(78, 28);
            this.submit.TabIndex = 5;
            this.submit.Text = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(109, 25);
            this.textBox2.TabIndex = 6;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 490);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(23, 411);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.submit);
            this.splitContainer1.Size = new System.Drawing.Size(708, 78);
            this.splitContainer1.SplitterDistance = 524;
            this.splitContainer1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "attribute name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "tablename";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "delete row";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(289, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(136, 25);
            this.textBox3.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(447, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 31);
            this.button2.TabIndex = 11;
            this.button2.Text = "delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComboBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 490);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ComboBoxForm";
            this.Text = "creat_table";
            this.Load += new System.EventHandler(this.ComboBoxForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader cnull;
        private System.Windows.Forms.ColumnHeader typ;
        private System.Windows.Forms.ColumnHeader clhTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
    }
}