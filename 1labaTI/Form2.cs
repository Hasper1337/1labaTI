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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void stolbs_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void stroki_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void variant_ValueChanged(object sender, EventArgs e)
        {

        }

        private void matrix1_btn_Click(object sender, EventArgs e)
        {
            int rows = (int)stroki.Value;
            int columns = (int)stolbs.Value;

            SetDataGridViewSize(rows, columns);
            calculate_btn_Click(rows, columns);
        }

        private void SetDataGridViewSize(int rows, int columns)
        {
            // Очищаем существующие колонки

            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();

            // Создаем новые колонки

            for (int i = 0; i < rows; i++)
            {
                dataGridView2.Columns.Add($"Column{i}", "");
            }

            // Устанавливаем количество строк
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            if (rows == 1)
            {
                for (int i = 0; i < columns; i++)
                {
                    dataGridView1.Columns.Add($"Column{i}", "");
                }
            }
            else
            {
                for (int i = 0; i < columns; i++)
                {
                    dataGridView1.Columns.Add($"Column{i}", "");
                }
                dataGridView1.Rows.Add(rows - 1);
            }

        }

        private void calculate_btn_Click(int rows, int columns)
        {
            
        }
    }
}
