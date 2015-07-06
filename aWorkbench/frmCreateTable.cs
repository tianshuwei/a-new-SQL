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
       // private aSQLConnector con;
        public frmCreateTable()
        {
            InitializeComponent();
            //con = aSQLConnector.getInstance();
            //dataGridResult.Columns.Add("col2", "col2");
            //resultSet xx = new resultSet("{ok:1,result:[[],[],[]]}", "xx");
        }

        ListViewItem TheListview;                     //选中项的集合对象
        ImageList imgList = new ImageList();   //图片集合

        //窗体加载事件
        private void ComboBoxForm_Load(object sender, EventArgs e)
        {
            imgList.ImageSize = new Size(1, 20);//分别是宽和高
            listView1.SmallImageList = imgList;   //这里设置listView的SmallImageList ,用imgList将其撑大

            LoadData();        //初始化ListView数据
        }
        //数据初始化
        public void LoadData()
        {
           
        }


        //下拉框的改变选项事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TheListview != null)
            {
                TheListview.SubItems[2].Text = this.comboBox1.Text.ToString();//类型
            }
            if (TheListview != null)
            {
                TheListview.SubItems[1].Text = this.comboBox2.Text.ToString();//是否为空
                if (TheListview.SubItems[3].Text.Equals("primary key") && TheListview.SubItems[1].Text.Equals("y"))
                {
                    MessageBox.Show("The primary key cannot be NULL");
                    TheListview.SubItems[1].Text = "n";
                }
            }
            if (TheListview != null)
            {
                TheListview.SubItems[3].Text = this.comboBox3.Text.ToString();//primary key
            }
        }


        //鼠标按下的事件
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                this.comboBox1.Visible = false;                                                   //控件初始化
                this.comboBox2.Visible = false;
                this.comboBox3.Visible = false;
            }
        }
        //鼠标单击控件的事件
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            this.comboBox1.Visible = false;                                                   //控件初始化
            this.comboBox2.Visible = false;
            this.comboBox3.Visible = false;
            //判断是否选中某项
            if (this.listView1.SelectedItems.Count > 0)
            {
                TheListview = this.listView1.SelectedItems[0];                                    //获得选中项

                int x = TheListview.SubItems[2].Bounds.Left;    //获得指定区域的首坐标
                int y = TheListview.SubItems[2].Bounds.Right; //获得指定区域的末坐标

                if (e.X > x && e.X < y)
                {

                    this.comboBox1.Visible = true;		//显示下拉框
                    this.comboBox1.SelectedIndex = 0;

                    this.comboBox1.Location = new Point(TheListview.SubItems[2].Bounds.Location.X + this.listView1.Bounds.Left, TheListview.SubItems[2].Bounds.Location.Y + this.listView1.Bounds.Top);
                    this.comboBox1.Width = TheListview.GetSubItemAt(e.X, e.Y).Bounds.Width;  //单元格宽度
                    this.comboBox1.BringToFront();   //在最上层显示该空间
                }
                else
                {
                    x = TheListview.SubItems[1].Bounds.Left;    //获得指定区域的首坐标
                    y = TheListview.SubItems[1].Bounds.Right; //获得指定区域的末坐标

                    if (e.X > x && e.X < y)
                    {

                        this.comboBox2.Visible = true;		//显示下拉框
                        this.comboBox2.SelectedIndex = 0;

                        this.comboBox2.Location = new Point(TheListview.SubItems[1].Bounds.Location.X + this.listView1.Bounds.Left, TheListview.SubItems[1].Bounds.Location.Y + this.listView1.Bounds.Top);
                        this.comboBox2.Width = TheListview.GetSubItemAt(e.X, e.Y).Bounds.Width;  //单元格宽度
                        this.comboBox2.BringToFront();   //在最上层显示该空间
                    }
                    else
                    {
                        x = TheListview.SubItems[3].Bounds.Left;    //获得指定区域的首坐标
                        y = TheListview.SubItems[3].Bounds.Right; //获得指定区域的末坐标

                        if (e.X > x && e.X < y)
                        {
                            this.comboBox3.Visible = true;		//显示下拉框
                            this.comboBox3.SelectedIndex = 0;

                            this.comboBox3.Location = new Point(TheListview.SubItems[3].Bounds.Location.X + this.listView1.Bounds.Left, TheListview.SubItems[3].Bounds.Location.Y + this.listView1.Bounds.Top);
                            this.comboBox3.Width = TheListview.GetSubItemAt(e.X, e.Y).Bounds.Width;  //单元格宽度
                            this.comboBox3.BringToFront();   //在最上层显示该空间
                        }
                    }

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                MessageBox.Show("Please Input attribute name");
            string add = textBox1.Text;
            int c = this.listView1.Columns.Count;
            ListViewItem lvi = new ListViewItem(add);    //ListView的首项
            this.listView1.Items.Add(lvi);
            lvi.SubItems.AddRange(new string[] { "y", "int", "n" });
            textBox1.Text = "";
        }

        private void submit_Click(object sender, EventArgs e)
        {
            int judge = 0;
            int c = this.listView1.Items.Count;
            if(textBox2.Text.Equals(""))
            {
                MessageBox.Show("Please set table name");
                return;
            }
            string add = "creat table " + textBox2.Text + "(";
            for (int i = 0; i < c; i++)
            {
                add = add + listView1.Items[i].SubItems[0].Text + " " + listView1.Items[i].SubItems[2].Text;

                if (listView1.Items[i].SubItems[3].Text.Equals("primary key"))
                {
                    add = add + " primary key";
                    judge = 1;
                }
                if (listView1.Items[i].SubItems[1].Text.Equals("n"))
                    add = add + " not null ";
                if (i != c - 1)
                    add = add + ",";
            }
            add = add + ")"+"into"+cfg.databaseName+";";
            
            if (judge.Equals(0))
            {
                MessageBox.Show("Please set primary key");
                return;
            }
			new frmConfirmScript(add).Show();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox3.Text);
            int c=listView1.Items.Count;
            if (i > c)
            {
                MessageBox.Show("out of range");
                return;
            }
            listView1.Items.RemoveAt(i);
        }
    }
}

