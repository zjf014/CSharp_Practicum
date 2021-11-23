using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 课程管理系统
{
    public partial class Form_Course : Form
    {
        Student st;

        public Form_Course(Student s)
        {
            InitializeComponent();
            this.st = s;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] before = Courses.getSomeOneCourse(st.Sno);
            string[] now = new string[listBox2.Items.Count];
            for (int i = 0; i < now.Length; i++)
                now[i] = listBox2.Items[i].ToString();

            for (int i = 0; i < now.Length; i++)
            {
                if (Array.IndexOf(before, now[i]) == -1)
                    Courses.insertCourse(st.Sno, now[i].Substring(0, 4));                
            }
            for (int i = 0; i < before.Length; i++)
            {
                if (Array.IndexOf(now, before[i]) == -1)
                    Courses.removeCourse(st.Sno, before[i].Substring(0, 4));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void Form_Course_Load(object sender, EventArgs e)
        {
            string[] all = Courses.getAllCourse();
            string[] someone = Courses.getSomeOneCourse(st.Sno);

            for (int i = 0; i < all.Length; i++)
            {
                if (Array.IndexOf(someone, all[i]) == -1)
                    listBox1.Items.Add(all[i]);
                else
                    listBox2.Items.Add(all[i]);
            }
        }

        
    }
}
