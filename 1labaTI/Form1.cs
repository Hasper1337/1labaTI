using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1labaTI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (A_P_btn.Checked == true)
            {
                Form2 newForm = new Form2();
                newForm.Show();
            }
            if (B_P_btn.Checked == true)
            {
                Form3 newForm = new Form3();
                newForm.Show();
            }
            if (P_btn.Checked == true)
            {
                Form4 newForm = new Form4();
                newForm.Show();
            }
        }

        private void A_P_btn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
