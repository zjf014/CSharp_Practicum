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
                if (textBox1.Text == "") MessageBox.Show("请输入教工号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (!Regex.IsMatch(textBox1.Text, @"^\d{6}$")) MessageBox.Show("教工号格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //判断密码
                if (textBox2.Text == "") MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
            }
            else //学生登录
            {
                //判断学号
                if (textBox1.Text == "") MessageBox.Show("请输入学号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (!Regex.IsMatch(textBox1.Text, @"^\d{12}$")) MessageBox.Show("学号格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //判断密码
                if (textBox2.Text == "") MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\user.abc", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(textBox1.Text);
            sw.Close();         
        }

    }
}
