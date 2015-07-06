using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace aWorkbench
{
	public partial class frmConfirmScript : Form
	{
		private aSQLConnector con;
		public frmConfirmScript(string script) {
            InitializeComponent();
            textBox1.Text = script;
			con = aSQLConnector.getInstance(cfg.ip, cfg.port);
		}
		private frmConfirmScript()
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
            con.send(textBox1.Text);
            string res=con.receive();
            JObject jr = JSON.fromJson(res);
            string ok = jr["ok"].ToString();
            string result = jr["result"].ToString();
            if ("0".Equals(ok)) { MessageBox.Show(result); return; }
            else { MessageBox.Show("success"); }
            this.Close();
        }
	}
}
