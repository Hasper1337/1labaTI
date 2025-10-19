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
            try
            {
                if (A_P_btn.Checked)
                {
                    Form2 newForm = new Form2();
                    newForm.Show();
                }
                else if (B_P_btn.Checked)
                {
                    Form3 newForm = new Form3();
                    newForm.Show();
                }
                else if (P_btn.Checked)
                {
                    Form4 newForm = new Form4();
                    newForm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите случай!");
            }

        }

        private void A_P_btn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
