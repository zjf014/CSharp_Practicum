using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace 课程管理系统
{
    class Teacher
    {
        string tno;
        string tname;

        public string Tno { get { return tno; } }
        public string Tname { get { return tname; } }

        public Teacher(string tno)
        {
            this.tno = tno;
            getTchrInfo();
        }

        private void getTchrInfo()
        {
            //查询教师信息
            DBAccess.initConnection();

            string sql = "select tname from teacher where tno = '" + this.tno + "'";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            SqlDataReader dr = DBAccess.cmd.ExecuteReader();

            if (dr.Read())
            {
                this.tname = dr["tname"].ToString();
            }
            dr.Close();
        }

        public string[] getCnamesByTno()
        {
            string[] cnames;

            DBAccess.initConnection();

            string sql = "select count(*) from course where teacher = '" + this.tno + "'";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            int c = int.Parse(DBAccess.cmd.ExecuteScalar().ToString());
            cnames = new string[c];

            sql = "select cno,cname from course where teacher = '" + this.tno + "'";
            DBAccess.cmd.CommandText = sql;
            SqlDataReader dr = DBAccess.cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                cnames[i++] = dr["cno"].ToString() + dr["cname"].ToString();
            }
            dr.Close();
            return cnames; 
        }

        public DataTable getStudentTableByCno(string cno)
        {
            DataTable dt = new DataTable("Score");

            string sql = "select student.sno,sname,score from Student,Score where student.sno = score.sno and cno = @cno order by sno";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            SqlDataAdapter sda = new SqlDataAdapter(DBAccess.cmd);
            sda.SelectCommand.Parameters.AddWithValue("@cno", cno);
            sda.Fill(dt);

            return dt;
        }

        public void updateStudentTableByCno(string cno,DataTable dt_now)
        {
            DataTable dt_before = new DataTable("Score");

            string sql = "select sno,cno,score from Score where cno = @cno order by sno";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            SqlDataAdapter sda = new SqlDataAdapter(DBAccess.cmd);
            sda.SelectCommand.Parameters.AddWithValue("@cno", cno);
            sda.Fill(dt_before);

            //用dt_now的成绩更新到dt_before
            for (int i = 0; i < dt_now.Rows.Count; i++)
            {
                if (!(dt_now.Rows[i]["score"] is System.DBNull))
                    dt_before.Rows[i]["score"] = int.Parse(dt_now.Rows[i]["score"].ToString());
            }

            //把dt_before更新到数据库

            sql = "update score set score = @score where sno = @sno and cno = @cno";
            sda.UpdateCommand = new SqlCommand(sql, DBAccess.conn);
            sda.UpdateCommand.Parameters.Add("@score", SqlDbType.Int, 4, "score");
            sda.UpdateCommand.Parameters.Add("@sno", SqlDbType.VarChar, 12, "sno");
            sda.UpdateCommand.Parameters.Add("@cno", SqlDbType.VarChar, 8, "cno");
            //SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            sda.Update(dt_before);

        }
    }
}
