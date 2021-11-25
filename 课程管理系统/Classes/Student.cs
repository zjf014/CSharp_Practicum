using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace 课程管理系统
{
    public class Student
    {
        string sno;
        string sname;
        string subject;

        public string Sno { get { return sno; } }
        public string Sname { get { return sname; } }
        public string Subject { get { return subject; } }

        public Student(string sno)
        {
            this.sno = sno;
            getStdInfo();
        }

        private void getStdInfo()
        {
            //查询学生信息
            DBAccess.initConnection();

            string sql = "select sno, sname, ssubject from Student where sno = @sno";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            DBAccess.cmd.Parameters.AddWithValue("@sno", this.sno);
            SqlDataReader dr = DBAccess.cmd.ExecuteReader();

            if (dr.Read())
            {
                this.sname = dr["sname"].ToString();
                this.subject = dr["ssubject"].ToString();
            }
            dr.Close();
        }

        public DataTable getScoreTable()
        {
            DataTable dt = new DataTable("MyScore");

            //利用dataadapter和command查询成绩
            string sql = "select cname,score from Score,Course where Course.cno = score.cno and sno = @sno";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = new SqlCommand(sql, DBAccess.conn);
            sda.SelectCommand.Parameters.AddWithValue("@sno", sno);  //查询参数是sno

            sda.Fill(dt);
            return dt;
        }

    }
}
