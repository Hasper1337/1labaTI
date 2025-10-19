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

        private void matrix1_btn_Click(object sender, EventArgs e)
        {
            int rows = (int)stroki.Value;
            int columns = (int)stolbs.Value;

            SetDataGridViewSize(rows, columns);
        }

        private void SetDataGridViewSize(int rows, int columns)
        {
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();

            for (int i = 0; i < rows; i++)
            {
                dataGridView2.Columns.Add($"Column{i}", "");
            }

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add(1);

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
                for (int j = 0; j < rows; j++)
                {
                    dataGridView1.Rows.Add();
                }
            }
        }

        private void calculate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // получение данных об ансамбле А
                int colsA = dataGridView2.Columns.Count;
                double[] ensembleA = new double[colsA];
                for (int j = 0; j < colsA; j++)
                {
                    var cell = dataGridView2.Rows[0].Cells[j].Value;
                    if (cell == null || !double.TryParse(cell.ToString(), out ensembleA[j]))
                        throw new Exception($"Некорректное значение в ансамбле A, столбец {j + 1}");
                }

                double sumA = ensembleA.Sum();
                if (Math.Abs(sumA - 1.0) != 0)
                    throw new Exception($"Сумма вероятностей ансамбля A = {sumA:F4}, должна быть 1");

                // получение данных о усл вероятн
                int rows = dataGridView1.Rows.Count;
                int cols = dataGridView1.Columns.Count;

                if (rows != colsA)
                    throw new Exception("Количество строк в матрице p(b|a) должно совпадать с длиной ансамбля A");

                double[,] pBA = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        var cell = dataGridView1.Rows[i].Cells[j].Value;
                        if (cell == null || !double.TryParse(cell.ToString(), out pBA[i, j]))
                            throw new Exception($"Некорректное значение в p(b|a), строка {i + 1}, столбец {j + 1}");
                    }
                }

                double[] ensembleB = new double[cols];
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        ensembleB[j] += ensembleA[i] * pBA[i, j];
                    }
                }

                double[,] joint = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        joint[i, j] = ensembleA[i] * pBA[i, j];
                    }
                }


                double[,] pAB = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        pAB[i, j] = ensembleB[j] > 0 ? joint[i, j] / ensembleB[j] : 0;
                    }
                }

                double Entropy(double[] p)
                {
                    double h = 0;
                    foreach (double x in p)
                        if (x > 0) h -= x * Math.Log(x, 2);
                    return h;
                }

                double JointEntropy(double[,] p)
                {
                    double h = 0;
                    int r = p.GetLength(0), c = p.GetLength(1);
                    for (int i = 0; i < r; i++)
                        for (int j = 0; j < c; j++)
                            if (p[i, j] > 0) h -= p[i, j] * Math.Log(p[i, j], 2);
                    return h;
                }

                double HA = Entropy(ensembleA);
                double HB = Entropy(ensembleB);
                double HAB = JointEntropy(joint);
                double H_B_given_A = HAB - HA;
                double H_A_given_B = HAB - HB;
                double I_AB = HA - H_A_given_B;


                var sb = new StringBuilder();
                sb.AppendLine($"Ансамбль A: [{string.Join(", ", ensembleA.Select(x => x.ToString()))}]");
                sb.AppendLine($"Ансамбль B: [{string.Join(", ", ensembleB.Select(x => x.ToString()))}]");

                sb.AppendLine();
                sb.AppendLine($"Энтропия H(A): {HA}");
                sb.AppendLine($"Энтропия H(B): {HB}");
                sb.AppendLine($"Условная энтропия H(B|A): {H_B_given_A:F10}");
                sb.AppendLine($"Условная энтропия H(A|B): {H_A_given_B:F10}");
                sb.AppendLine($"Совместная энтропия H(AB): {HAB:F10}");
                sb.AppendLine($"Взаимная информация I(A;B): {I_AB:F10}");
                sb.AppendLine();

                sb.AppendLine("Матрица совместных вероятностей p(a,b):");
                for (int i = 0; i < rows; i++)
                {
                    sb.AppendLine($"  {string.Join("  ", Enumerable.Range(0, cols).Select(j => joint[i, j].ToString("F4")))}");
                }
                sb.AppendLine();
                sb.AppendLine("Матрица условных вероятностей p(a|b):");
                for (int i = 0; i < rows; i++)
                {
                    sb.AppendLine($"  {string.Join("  ", Enumerable.Range(0, cols).Select(j => pAB[i, j].ToString("F4")))}");
                }

                MessageBox.Show(sb.ToString(), "Результаты расчёта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void stolbs_ValueChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void stroki_ValueChanged(object sender, EventArgs e) { }
    }
}
