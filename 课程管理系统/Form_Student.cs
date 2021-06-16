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
        string sno;

        public Form_Student(string username)
        {
            InitializeComponent();
            this.sno = username;
        }

        //界面在加载后查询学号、姓名、专业和成绩
        private void Form_Student_Load(object sender, EventArgs e)
        {
            //建立数据库连接
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
            conn.Open();

            //利用command直接查询学号、姓名、专业
            string sql = "select student.sno , sname, ssubject from Student where sno = '" + sno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sreader = cmd.ExecuteReader();
            
            //利用reader结果填充label
            if (sreader.Read())
            {
                label1.Text = "学号：" + sreader.GetValue(0);
                label2.Text = "姓名：" + sreader.GetValue(1);
                label3.Text = "专业：" + sreader.GetValue(2);
            }
            sreader.Close();


            //利用dataadapter和command查询成绩
            sql = "select cname,score from Student,Score,Course where student.sno = score.sno and Course.cno = score.cno and student.sno = @sno";                    
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = new SqlCommand(sql, conn);
            sda.SelectCommand.Parameters.AddWithValue("@sno",sno);  //查询参数是sno

            //建立datatable并填充
            DataTable dt = new DataTable("Score");
            sda.Fill(dt);
            //将datatable设置为datagridview的数据源
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void Form_Student_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
