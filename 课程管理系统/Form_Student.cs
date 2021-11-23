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
    public partial class Form_Student : Form
    {
        Student st;

        public Form_Student(string sno)
        {
            InitializeComponent();
            st = new Student(sno);
        }

        //界面在加载后查询学号、姓名、专业和成绩
        private void Form_Student_Load(object sender, EventArgs e)
        {

            label1.Text = "学号：" + st.Sno;
            label2.Text = "姓名：" + st.Sname;
            label3.Text = "专业：" + st.Subject;

            //将datatable设置为datagridview的数据源
            dataGridView1.DataSource = st.getScoreTable();

        }

        private void Form_Student_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Course frm = new Form_Course(st);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = st.getScoreTable();
            }
        }
    }
}
