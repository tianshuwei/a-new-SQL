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
using System.IO;
namespace aWorkbench
{
	public partial class workbench : Form
	{
		private aSQLConnector con;
		Dictionary<string,Dictionary<string, Elem.VALTYPE>> tableInfos;
		public workbench()
		{
			InitializeComponent();
			con = aSQLConnector.getInstance(cfg.ip, cfg.port);
			//dataGridResult.Columns.Add("col2", "col2");
            //resultSet xx = new resultSet("{ok:1,result:[[],[],[]]}", "xx");
		}
        private void getResult(resultSet rs)
        {
            listViewResult.GridLines = true;//表格是否显示网格线
            listViewResult.FullRowSelect = true;//是否选中整行
            listViewResult.View = View.Details;//设置显示方式
            listViewResult.Scrollable = true;//是否自动显示滚动条
            listViewResult.MultiSelect = false;//是否可以选择多行

            //添加表头
            foreach (string str in rs.keys)
            {
                listViewResult.Columns.Add(str);
            }
            //添加表格内容
            foreach(List<Elem> xx in rs.values)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                foreach (Elem xxx in xx)
                {
                    item.SubItems.Add(xxx.ToString());
                }
                listViewResult.Items.Add(item);
            }
        }

		private void Form1_Load(object sender, EventArgs e)
		{
            con.send("list databases;");
			String js = con.receive();
			// cfg.databaseName 在返回的列表中，设置，否则报错
			lblDatabaseName.Text = cfg.databaseName ;
            this.refreshTree(null, null);//怎么传参数进去？
			//TODO refresh UIs
			//1.left top info 
			//2.table tree
			//  * use refreshTree(object sender, EventArgs e)
		}

		private void createTable(object sender, EventArgs e)
		{
			new frmCreateTable().Show();
		}

		private void nodeClick(object sender, TreeNodeMouseClickEventArgs e)
		{	
            if (e.Node == null) return;
			if (e.Button == MouseButtons.Right)
			{
                switch (e.Node.Level)
                {
					case 0://顶层 Tables
                        int xx = e.Node.TreeView.SelectedNode.GetNodeCount(true);
                        string[] tables = new string[20];
                        for (int i = 0; i < xx; i++)
                        {
                            tables[i] = "drop " + e.Node.TreeView.Nodes[i].Text;
                            ToolStripMenuItem tsmi = new ToolStripMenuItem(tables[i]);
                            tsmi.Click += new System.EventHandler(
                                (object _sender, EventArgs _e) =>
                                {
                                    con.send(tables[i]);
                                    //do something
                                }
                                );
                            menuStripEditTable.Items.RemoveAt(0);
                            menuStripEditTable.Items.Insert(0, tsmi);
                            break;
                        }
						break;
					case 1:// TableA
                        string tableA = "drop " + e.Node.Text;
                        ToolStripMenuItem tsmi1 = new ToolStripMenuItem(tableA);
                        tsmi1.Click += new System.EventHandler(
                            (object _sender, EventArgs _e) =>
                            {
                                con.send(tableA);

							}
							);
						menuStripEditTable.Items.RemoveAt(0);
                        menuStripEditTable.Items.Insert(0, tsmi1);
						break;
					case 2://col1
                        string rcol = "remove col " + e.Node.Text;
                        ToolStripMenuItem tsmi2 = new ToolStripMenuItem(rcol);
                        tsmi2.Click += new System.EventHandler(
                            (object _sender, EventArgs _e) =>
                            {
                                string ipString = aWorkbench.cfg.ip;
                                int port = aWorkbench.cfg.port;
                                con.send(rcol);
								//do something
							}
							);
						menuStripEditTable.Items.RemoveAt(0);
                        menuStripEditTable.Items.Insert(0, tsmi2);
						break;
				}
			}

		}


		private void refreshTree(object sender, EventArgs e)// get tables from server and create tree
		{
			//database_name
			con.send(String.Format("list tables in {0};", cfg.databaseName));
			TreeNode tn1 = treeTable.Nodes.Add(cfg.databaseName);
            //table_name&col_name
            //string sql = "list tables in" + cfg.databaseName + ";";
            //con.send(sql);
            string jsonString = con.receive();
			//jsonString = "{'ok':1,result:['table1','table2','table3']}";
            JObject jr = JSON.fromJson(jsonString);
            string ok = jr["ok"].ToString();
            string result = jr["result"].ToString();

			if ("0".Equals(ok)) { MessageBox.Show(result); return; }
            JArray jares = (JArray)JsonConvert.DeserializeObject(result);
            for (int i = 0; i < jares.Count; i++)
            {
                TreeNode tn2 = new TreeNode(jares[i].ToString());
                tn1.Nodes.Add(tn2);

                string sql_col = "list columns from " + jares[i].ToString() + " in " + cfg.databaseName;
                con.send(sql_col);
                string colname = con.receive();
                //colname = "{'ok':1,result:['col1','col2','col3']}";
                JObject jrcol = JSON.fromJson(colname);
                string result2 = jrcol["result"].ToString();
                JArray jacol = (JArray)JsonConvert.DeserializeObject(result2);
                for (int j = 0; j < jacol.Count; j++)
                {
                    TreeNode tn3 = new TreeNode(jacol[i].ToString());
                    tn2.Nodes.Add(tn3);
                }
            }
		}

		private void runCmds(object sender, EventArgs e)
		{
            string cmds = txtScripts.Text;
			//todo
			con.send(cmds);
		}

		private void cpyToClipboard(object sender, EventArgs e)
		{
            if (txtScripts.SelectedText != "")
                Clipboard.SetDataObject(txtScripts.SelectedText);
		}

		private void openScript(object sender, EventArgs e)
		{
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "(*.sql)|*.sql"; //过滤文件类型  TODO 只允许打开.sql文件
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = false; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                txtScripts.Text = string.Empty;
                StreamReader sr = new StreamReader(fd.FileName);
                txtScripts.Text = sr.ReadToEnd();
                sr.Close();
                //进行后续处理
				//DID  张徐前 把文件打开，然后把文件内容载入到输入框（txtScripts）
            }
		}

		private void setMsg(string type, string msg) { //TODO 把type，msg消息设置到消息框中

		}

	}
}
