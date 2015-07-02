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
	public partial class workbench : Form
	{
		private aSQLConnector con;
		Dictionary<string,Dictionary<string, Elem.VALTYPE>> tableInfos;
		public workbench()
		{
			InitializeComponent();
			con = new aSQLConnector("localhost", 3306);
			dataGridResult.Columns.Add("col2", "col2");
			
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
                        int xx=e.Node.TreeView.SelectedNode.GetNodeCount(true);
                        string[] tables=new string[20];
                        for (int i = 0; i < xx; i++)
                        {
                            tables[i] = "drop " + e.Node.TreeView.Nodes[i].Text;
                            ToolStripMenuItem tsmi1 = new ToolStripMenuItem(tables[i]);
                            tsmi1.Click += new System.EventHandler(
                                (object _sender, EventArgs _e) =>
                                {
                                    //do something
                                }
                                );
                            menuStripEditTable.Items.RemoveAt(0);
                            menuStripEditTable.Items.Insert(0, tsmi1);
                            break;
                        }
						break;
					case 1:// TableA
                        string tableA = "drop " + e.Node.Text;
                        ToolStripMenuItem tsmi2 = new ToolStripMenuItem(tableA);
						tsmi2.Click += new System.EventHandler(
							(object _sender, EventArgs _e) => {
								//do something
							}
							);
						menuStripEditTable.Items.RemoveAt(0);
						menuStripEditTable.Items.Insert(0, tsmi2);
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
			//string jsonString = con.send("list tables;");
			// return {ok:0/1,result:...}
            //aSQLConnector.jsonResult

			string jsonString = "{'ok':1,result:['table1','table2','table3']}";//ok,result类型是string还是char？
            JObject jr = JSON.fromJson(jsonString);
            string ok = jr["ok"].ToString();
            string result = jr["result"].ToString();

			if (ok == "0") { MessageBox.Show(result); return; }
            string[] tables = result.Split(new char[] { ',' });
            foreach (string tablename in tables)
            {
                TreeNode nodeChild = new TreeNode();
                nodeChild.Text = tablename;
                treeTable.Nodes.Add(nodeChild);

                string colname = "{'ok':1,result:['table1','table2','table3']}";
                JObject cn = JSON.fromJson(colname);
                string ok2 = jr["ok"].ToString();
                string result2 = jr["result"].ToString();

                if (ok2 == "0") { MessageBox.Show(result); return; }
                string[] coltables = result2.Split(new char[] { ',' });
                foreach (string name in coltables) { }
            }
		}
		

		private void runCmds(object sender, EventArgs e)
		{
            string cmds = txtScripts.Text;

            //todo
		}

		private void cpyToClipboard(object sender, EventArgs e)
		{
            if (txtScripts.SelectedText != "")
                Clipboard.SetDataObject(txtScripts.SelectedText);
		}

		private void openScript(object sender, EventArgs e)
		{
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "*.sql"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = false; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                //进行后续处理
            }

		}

        private void txtScripts_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

		}

        private void treeTable_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


	}
}
