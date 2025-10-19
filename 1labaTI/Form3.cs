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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void SetMatrixSize(int rowsA, int colsB)
        {
            dataGridView2.Columns.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();

            for (int j = 0; j < colsB; j++)
                dataGridView2.Columns.Add($"B{j + 1}", "");
            dataGridView2.Rows.Add();


            for (int j = 0; j < colsB; j++)
                dataGridView1.Columns.Add($"B{j + 1}", "");
            for (int i = 0; i < rowsA; i++)
                dataGridView1.Rows.Add();
        }

        private void matrix1_btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(stroki.Text, out int rowsA) &&
                int.TryParse(stolbs.Text, out int colsB))
            {
                if (rowsA < 1 || colsB < 1)
                {
                    MessageBox.Show("Число исходов должно быть >= 1", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SetMatrixSize(rowsA, colsB);
            }
            else
            {
                MessageBox.Show("Введите корректные целые числа!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calculate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsA = dataGridView1.Rows.Count;   // число a_i
                int colsB = dataGridView1.Columns.Count; // число b_j

                if (rowsA == 0 || colsB == 0)
                {
                    MessageBox.Show("Сначала задайте размеры!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                double[] ensembleB = new double[colsB];
                double sumB = 0;
                for (int j = 0; j < colsB; j++)
                {
                    var cell = dataGridView2.Rows[0].Cells[j].Value;
                    if (cell == null || !double.TryParse(cell?.ToString(), out ensembleB[j]))
                        throw new Exception($"Некорректное значение в ансамбле B, столбец {j + 1}");
                    if (ensembleB[j] < 0)
                        throw new Exception($"Вероятность не может быть отрицательной в B[{j + 1}]");
                    sumB += ensembleB[j];
                }

                if (Math.Abs(sumB - 1.0) != 0)
                    throw new Exception($"Сумма P(b_j) = {sumB:F6}, должна быть 1");


                double[,] pAB = new double[rowsA, colsB]; // P(a_i | b_j)
                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsB; j++)
                    {
                        var cell = dataGridView1.Rows[i].Cells[j].Value;
                        if (cell == null || !double.TryParse(cell?.ToString(), out pAB[i, j]))
                            throw new Exception($"Ошибка в P(a|b), строка {i + 1}, столбец {j + 1}");
                        if (pAB[i, j] < 0 || pAB[i, j] > 1)
                            throw new Exception($"P(a|b) должна быть в [0,1], ячейка ({i + 1},{j + 1})");
                    }
                }


                for (int j = 0; j < colsB; j++)
                {
                    double colSum = 0;
                    for (int i = 0; i < rowsA; i++)
                        colSum += pAB[i, j];
                    if (Math.Abs(colSum - 1.0) != 0)
                        throw new Exception($"Сумма P(a_i|b_{j + 1}) = {colSum:F4}, должна быть 1");
                }


                double[,] joint = new double[rowsA, colsB];
                for (int i = 0; i < rowsA; i++)
                    for (int j = 0; j < colsB; j++)
                        joint[i, j] = pAB[i, j] * ensembleB[j];


                double[] ensembleA = new double[rowsA];
                for (int i = 0; i < rowsA; i++)
                    for (int j = 0; j < colsB; j++)
                        ensembleA[i] += joint[i, j];

                double[,] pBA = new double[rowsA, colsB];
                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsB; j++)
                    {
                        if (ensembleA[i] > 0)
                            pBA[i, j] = joint[i, j] / ensembleA[i];
                        else
                            pBA[i, j] = 0;
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
                for (int i = 0; i < rowsA; i++)
                {
                    sb.AppendLine($"  {string.Join("  ", Enumerable.Range(0, colsB).Select(j => joint[i, j].ToString("F4")))}");
                }
                sb.AppendLine();
                sb.AppendLine("Матрица условных вероятностей p(a|b):");
                for (int i = 0; i < rowsA; i++)
                {
                    sb.AppendLine($"  {string.Join("  ", Enumerable.Range(0, colsB).Select(j => pAB[i, j].ToString("F4")))}");
                }

                MessageBox.Show(sb.ToString(), "Результаты расчёта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
