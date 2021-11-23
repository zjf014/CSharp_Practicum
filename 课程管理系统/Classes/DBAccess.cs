using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace 课程管理系统
{
    class DBAccess
    {
        static string connStr = "Data Source=localhost;Initial Catalog=CourseManagement;User ID=sa;Password=arcgis";
        public static SqlConnection conn = null;
        public static SqlCommand cmd = null;

        public static void initConnection()
        {
            if (conn == null)
                conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public static string getUserType(string username, string password)
        {
            try
            {
                string type = null;

                initConnection();

                //判断登录类型
                string sql = "select type from Users where username = '" + username + "' and password = '" + password + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                type = cmd.ExecuteScalar().ToString();

                return type;
            }
            catch
            {
                return null;
            }
        }
    }
}
