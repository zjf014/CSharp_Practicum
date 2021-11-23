using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace 课程管理系统
{
    class Courses
    {
        public static string[] getAllCourse()
        {
            string[] all;

            DBAccess.initConnection();

            string sql = "select count(*) from course";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            int c = int.Parse(DBAccess.cmd.ExecuteScalar().ToString());
            all = new string[c];

            sql = "select cno,cname from course";
            DBAccess.cmd.CommandText = sql;
            SqlDataReader dr = DBAccess.cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                all[i++] = dr["cno"].ToString() + dr["cname"].ToString();
            }
            dr.Close();
            return all;
        }

        public static string[] getSomeOneCourse(string sno)
        {
            string[] someone;

            DBAccess.initConnection();

            string sql = "select count(*) from score where sno = '" + sno + "'";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            int c = int.Parse(DBAccess.cmd.ExecuteScalar().ToString());
            someone = new string[c];

            sql = "select score.cno,cname from score,course where score.cno = course.cno and sno = '" + sno + "'";
            DBAccess.cmd.CommandText = sql;
            SqlDataReader dr = DBAccess.cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                someone[i++] = dr["cno"].ToString() + dr["cname"].ToString();
            }
            dr.Close();
            return someone;
        }

        public static int insertCourse(string sno, string cno)
        {
            DBAccess.initConnection();

            string sql = "insert into score(sno,cno) values('" + sno + "','" + cno + "')";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            return DBAccess.cmd.ExecuteNonQuery();
        }

        public static int removeCourse(string sno, string cno)
        {
            DBAccess.initConnection();

            string sql = "delete from score where sno = '" + sno + "' and cno = '" + cno + "'";
            DBAccess.cmd = new SqlCommand(sql, DBAccess.conn);
            return DBAccess.cmd.ExecuteNonQuery();
        }
    }
}
