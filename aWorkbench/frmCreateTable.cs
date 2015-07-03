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
	public partial class frmCreateTable : Form
	{
        frmCreateTable(string tablename) {
            table_name.Text = tablename;//表名
            //attribute
            string[] att=new string[]{};
            
            this.comboBox2.Items.Add(att);
            //type
            string[] typ = new string[] { };

            this.comboBox1.Items.Add(att);
        }
		public frmCreateTable()
		{
			InitializeComponent();
		}

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void attribute_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void table_name_Click(object sender, EventArgs e)
        {

        }

        private void empty_Click(object sender, EventArgs e)
        {
            value.Text = null;
            checkBox1.Checked = false;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            bool n = checkBox1.Checked;
            string val = textBox2.Text;
            string attr = comboBox2.Text;
            string typ = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}
