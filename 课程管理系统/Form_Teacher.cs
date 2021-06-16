﻿using System;
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
        string tno;
        string cno;

        public Form_Teacher(string username)
        {
            InitializeComponent();
            tno = username;
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
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
            conn.Open();

            string sql = "select tname from Teacher where tno = '" + tno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);

            treeView1.Nodes.Add(cmd.ExecuteScalar().ToString());

            sql = "select cname from Teacher,Course where Teacher.tno = Course.teacher and Teacher.tno = '" + tno + "'";
            cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                treeView1.Nodes[0].Nodes.Add(reader.GetValue(0).ToString());
            }
            treeView1.Nodes[0].Expand();

            conn.Close();
        }

        //在treeview点击课程名后，在datagridview显示选了该课程的
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null) //判断点击的是课程节点而不是教师名称
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
                conn.Open();

                string sql = "select student.sno,sname,Course.cno,score from Student,Score,Course where student.sno = score.sno and Course.cno = score.cno and cname = @cname";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.Parameters.AddWithValue("@cname", e.Node.Text);

                DataTable dt = new DataTable("Score");
                sda.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["sno"].ReadOnly = true;
                dataGridView1.Columns["sname"].ReadOnly = true;
                dataGridView1.Columns["score"].ReadOnly = false;

                dataGridView1.Columns["cno"].Visible = false;
                cno = dt.Rows[0]["cno"].ToString();

                conn.Close();
            }
        }

        //保存按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            //通过dataadapter填充dt_before
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select * from Score where cno = @cno",conn);
            sda.SelectCommand.Parameters.AddWithValue("@cno", cno);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            
            DataTable dt_before = new DataTable("before");            
            sda.Fill(dt_before);

            //通过datagridview填充dt_after
            DataTable dt_after = new DataTable("after");        
            for (int i = 0; i < dataGridView1.Columns.Count; i++)  //填充列
            {
                DataColumn dc = new DataColumn(dataGridView1.Columns[i].Name.ToString());
                dt_after.Columns.Add(dc);
            }            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)  //循环行
            {
                DataRow dr = dt_after.NewRow();
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dr[j] = dataGridView1.Rows[i].Cells[j].Value;
                }
                dt_after.Rows.Add(dr);
            }
            dt_after.Columns.Remove("sname");


            //用dt_after更新到dt_before
            for (int i = 0; i < dt_after.Rows.Count; i++)
            {
                dt_before.Rows[i]["cno"] = dt_after.Rows[i]["cno"].ToString();
                dt_before.Rows[i]["sno"] = dt_after.Rows[i]["sno"].ToString();
                if (!(dt_after.Rows[i]["score"] is System.DBNull))
                    dt_before.Rows[i]["score"] = int.Parse(dt_after.Rows[i]["score"].ToString());              
            }

            //把dt_before更新到数据库
            sda.Update(dt_before);

            conn.Close();
        }

    }
}
