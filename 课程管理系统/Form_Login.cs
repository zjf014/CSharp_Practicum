using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using System.Data.SqlClient;

namespace 课程管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
                label1.Text = "学  号：";
            else
                label1.Text = "教工号：";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) //教工登录
            {
                //判断教工号
                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("请输入教工号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(this.textBox1.Text, @"^\d{6}$"))
                {
                    MessageBox.Show("教工号格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }
            else //学生登录
            {
                //判断学号
                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("请输入学号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(this.textBox1.Text, @"^\d{12}$"))
                {
                    MessageBox.Show("学号格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            //判断密码
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            
            //数据库判断
            try
            {
                //连接数据库
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
                conn.Open();

                //判断登录类型
                string sql = "select type from Users where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                object type = cmd.ExecuteScalar();

                if (type == null) //没查到登录类型
                {
                    MessageBox.Show("用户名或密码不正确!");
                    return;
                }
                
                if (cmd.ExecuteScalar().ToString() == "T")   //如果是教师登录
                {
                    MessageBox.Show("登录成功!");

                    //打开教师窗口
                    Form_Teacher frmT = new Form_Teacher(textBox1.Text);
                    frmT.Show();
                    this.Hide();
                }
                else //如果是学生登录
                {
                    MessageBox.Show("登录成功!");

                    //打开学生窗口
                    Form_Student frmS = new Form_Student(textBox1.Text);
                    frmS.Show();
                    this.Hide();
                }

                conn.Close();//关闭连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //记住用户名
            if (checkBox1.Checked)  //用户名写入user.abc文件
            {
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\user.abc", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(this.textBox1.Text);
                sw.Close();
            }
            else //删除user.abc文件
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\user.abc"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\user.abc");
            }

            if (checkBox2.Checked)  //密码写入pass.abc文件
            {
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\pass.abc", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(this.textBox2.Text);
                sw.Close();
            }
            else //删除pass.abc文件
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\pass.abc"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\pass.abc");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            if (File.Exists(Directory.GetCurrentDirectory() + "\\user.abc"))  //上次登录是记住用户名，则user.abc文件存在
            {
                this.checkBox1.Checked = true;
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\user.abc", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                this.textBox1.Text = sr.ReadLine();
                sr.Close();
            }
            if (File.Exists(Directory.GetCurrentDirectory() + "\\pass.abc"))  //上次登录记住密码，则pass.abc文件存在
            {
                this.checkBox2.Checked = true;
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\pass.abc", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                this.textBox2.Text = sr.ReadLine();
                sr.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //切换时删除文件
            if (!this.checkBox1.Checked)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\user.abc"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\user.abc");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //切换时删除文件
            if (!this.checkBox2.Checked)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\pass.abc"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\pass.abc");
            }
        }

    }
}
