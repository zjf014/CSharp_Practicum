using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace 课程管理系统
{
    public partial class Form_Teacher : Form
    {
        Teacher t;
        string cno;

        public Form_Teacher(string tno)
        {
            InitializeComponent();
            t = new Teacher(tno);
        }

        private void Form_Teacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //界面载入后在treeview里显示教师姓名和课程
        private void Form_Teacher_Load(object sender, EventArgs e)
        {

            treeView1.Nodes.Add(t.Tname);

            string[] cnames = t.getCnamesByTno();

            for (int i = 0; i < cnames.Length; i++)
            {
                treeView1.Nodes[0].Nodes.Add(cnames[i]);
            }
            treeView1.Nodes[0].Expand();
        }

        //在treeview点击课程名后，在datagridview显示选了该课程的学号、姓名、成绩
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null) //判断点击的是课程节点而不是教师名称
            {
                this.cno = e.Node.Text.Substring(0, 4);
                dataGridView1.DataSource = t.getStudentTableByCno(this.cno);

                dataGridView1.Columns["sno"].ReadOnly = true;
                dataGridView1.Columns["sname"].ReadOnly = true;
                dataGridView1.Columns["score"].ReadOnly = false;
            }
        }

        //保存按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            //提交时dt，由datagridview1获取
            DataTable dt_now = new DataTable("now");        
            for (int i = 0; i < dataGridView1.Columns.Count; i++)  //填充列
            {
                DataColumn dc = new DataColumn(dataGridView1.Columns[i].Name.ToString());
                dt_now.Columns.Add(dc);
            }            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)  //循环行
            {
                DataRow dr = dt_now.NewRow();
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dr[j] = dataGridView1.Rows[i].Cells[j].Value;
                }
                dt_now.Rows.Add(dr);
            }
            dt_now.Columns.Remove("sname");

            t.updateStudentTableByCno(this.cno, dt_now);
        }

    }
}
