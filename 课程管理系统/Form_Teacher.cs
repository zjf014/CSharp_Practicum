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
    public partial class Form_Teacher : Form
    {

        public Form_Teacher()
        {
            InitializeComponent();
        }

        private void Form_Teacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
