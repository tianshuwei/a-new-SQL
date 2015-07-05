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
	public partial class frmConfirmScript : Form
	{
		private aSQLConnector con;
		public frmConfirmScript(string script) {
            textBox1.Text = script;
		}
		public frmConfirmScript()
		{
			InitializeComponent();
			con = aSQLConnector.getInstance(cfg.ip, cfg.port);
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel_btn
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //confirm_btn
            con.send(textBox1.Text, true);
        }
	}
}
