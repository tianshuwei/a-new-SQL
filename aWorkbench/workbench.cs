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
			con = aSQLConnector.getInstance("127.0.0.1", 3306);
			//dataGridResult.Columns.Add("col2", "col2");
            resultSet xx = new resultSet("{ok:1,result:[[],[],[]]}", "xx");
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
                                    string ipString = aWorkbench.cfg.ip;
                                    int port = aWorkbench.cfg.port;
                                    aWorkbench.aSQLConnector senddrop = new aWorkbench.aSQLConnector(ipString, port);
                                    senddrop.send(tables[i], true);
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
                                string ipString = aWorkbench.cfg.ip;
                                int port = aWorkbench.cfg.port;
                                aWorkbench.aSQLConnector senddrop = new aWorkbench.aSQLConnector(ipString, port);
                                senddrop.send(tableA, true);

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
                                aWorkbench.aSQLConnector senddrop = new aWorkbench.aSQLConnector(ipString, port);
                                senddrop.send(rcol, true);
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
			string jsonString = "{'ok':1,result:['table1','table2','table3']}";
            JObject jr = JSON.fromJson(jsonString);
            string ok = jr["ok"].ToString();
            string result = jr["result"].ToString();

			if ("0".Equals(ok)) { MessageBox.Show(result); return; }
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
            fd.Filter = "(*.*)|*.*"; //过滤文件类型  TODO 张徐前 只允许打开.sql文件
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = false; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                //进行后续处理
				//TODO  张徐前 把文件打开，然后把文件内容载入到输入框（txtScripts）
            }
		}

		private void setMsg(string type, string msg) { //TODO 把type，msg消息设置到消息框中

		}

	}
}
