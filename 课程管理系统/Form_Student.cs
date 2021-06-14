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

        private void Form_Student_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
            conn.Open();

            string sql = "select student.sno , sname, ssubject from Student where sno = '" + sno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sreader = cmd.ExecuteReader();
            
            if (sreader.Read())
            {
                label1.Text = "学号：" + sreader.GetValue(0);
                label2.Text = "姓名：" + sreader.GetValue(1);
                label3.Text = "学院：" + sreader.GetValue(2);
            }
            sreader.Close();

            sql = "select cname,score from Student,Score,Course where student.sno = score.sno and Course.cno = score.cno and student.sno = @sno";
            cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@sno",sno);

            DataTable dt = new DataTable("Score");
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void Form_Student_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
