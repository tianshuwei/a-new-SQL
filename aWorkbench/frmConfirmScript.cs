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
		public frmConfirmScript(string script) {
            textBox1.Text = script;
		}
		public frmConfirmScript()
		{
			InitializeComponent();
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
            string ipString = aWorkbench.cfg.ip;
            int port = aWorkbench.cfg.port;
            aWorkbench.aSQLConnector sendtxt = new aWorkbench.aSQLConnector(ipString,port);
            sendtxt.send(textBox1.Text, true);
        }
	}
}
