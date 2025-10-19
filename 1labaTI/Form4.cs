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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void SetMatrixSize(int rows, int cols)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int j = 0; j < cols; j++)
                dataGridView1.Columns.Add($"{j + 1}", "");

            for (int i = 0; i < rows; i++)
                dataGridView1.Rows.Add();
        }

        private void calculate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = dataGridView1.Rows.Count;
                int cols = dataGridView1.Columns.Count;

                if (rows == 0 || cols == 0)
                {
                    MessageBox.Show("Сначала задайте размер матрицы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double[,] joint = new double[rows, cols];
                double totalSum = 0;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        var cell = dataGridView1.Rows[i].Cells[j].Value;
                        if (cell == null || !double.TryParse(cell.ToString(), out joint[i, j]))
                            throw new Exception($"Ошибка в ячейке ({i + 1}, {j + 1}): значение не число");

                        if (joint[i, j] < 0)
                            throw new Exception($"Вероятность не может быть отрицательной: ({i + 1}, {j + 1})");

                        totalSum += joint[i, j];
                    }
                }


                if (Math.Abs(totalSum - 1.0) != 0)
                    throw new Exception($"Сумма всех вероятностей = {totalSum:F6}, должна быть 1.0");


                double[] ensembleA = new double[rows]; // P(a_i)
                double[] ensembleB = new double[cols]; // P(b_j)

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        ensembleA[i] += joint[i, j];

                for (int j = 0; j < cols; j++)
                    for (int i = 0; i < rows; i++)
                        ensembleB[j] += joint[i, j];


                double[,] pBA = new double[rows, cols]; // P(b_j | a_i)
                double[,] pAB = new double[rows, cols]; // P(a_i | b_j)

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (ensembleA[i] > 0)
                            pBA[i, j] = joint[i, j] / ensembleA[i];
                        else
                            pBA[i, j] = 0;

                        if (ensembleB[j] > 0)
                            pAB[i, j] = joint[i, j] / ensembleB[j];
                        else
                            pAB[i, j] = 0;
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

                sb.AppendLine("Условные вероятности P(b|a):");
                for (int i = 0; i < rows; i++)
                {
                    sb.AppendLine($"  {string.Join("  ", Enumerable.Range(0, cols).Select(j => pBA[i, j].ToString("F4")))}");
                }
                sb.AppendLine();

                sb.AppendLine("Условные вероятности P(a|b):");
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

        private void matrix1_btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(stroki.Text, out int rows) && int.TryParse(stolbs.Text, out int cols))
            {
                if (rows < 1 || cols < 1)
                {
                    MessageBox.Show("Количество строк и столбцов должно быть >= 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SetMatrixSize(rows, cols);
            }
            else
            {
                MessageBox.Show("Введите корректные числа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
