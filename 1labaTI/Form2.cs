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
                InformationTheoryCalculator calculator = new InformationTheoryCalculator();
                var results = calculator.CalculateFromDataGrids(dataGridView2, dataGridView1);

                DisplayResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayResults(CalculationResults results)
        {
            txtResults.Clear();

            txtResults.AppendText("=== РЕЗУЛЬТАТЫ РАСЧЕТА ===\n\n");
            txtResults.AppendText($"Вариант: {variant.Text}\n\n");

            txtResults.AppendText("Введенные данные:\n");
            txtResults.AppendText($"Ансамбль A: {string.Join(", ", results.EnsembleA.Select(x => x.ToString("F4")))}\n");

            txtResults.AppendText("Условные вероятности p(b|a):\n");
            for (int i = 0; i < results.ConditionalProbabilities.GetLength(0); i++)
            {
                var row = Enumerable.Range(0, results.ConditionalProbabilities.GetLength(1))
                                   .Select(j => results.ConditionalProbabilities[i, j].ToString("F4"));
                txtResults.AppendText($"  {string.Join(", ", row)}\n");
            }

            txtResults.AppendText("\n---\n\n");

            txtResults.AppendText("Результаты:\n");
            txtResults.AppendText($"Ансамбль B: {string.Join(", ", results.EnsembleB.Select(x => x.ToString("F4")))}\n");
            txtResults.AppendText($"Энтропия H(A): {results.EntropyA:F4}\n");
            txtResults.AppendText($"Энтропия H(B): {results.EntropyB:F4}\n");
            txtResults.AppendText($"Условная энтропия H(B|A): {results.ConditionalEntropyBA:F4}\n");
            txtResults.AppendText($"Условная энтропия H(A|B): {results.ConditionalEntropyAB:F4}\n");
            txtResults.AppendText($"Совместная энтропия H(AB): {results.JointEntropy:F4}\n");
            txtResults.AppendText($"Взаимная информация I(A;B): {results.MutualInformation:F4}\n");

            txtResults.AppendText("\nМатрица совместных вероятностей p(a,b):\n");
            for (int i = 0; i < results.JointProbabilities.GetLength(0); i++)
            {
                var row = Enumerable.Range(0, results.JointProbabilities.GetLength(1))
                                   .Select(j => results.JointProbabilities[i, j].ToString("F4"));
                txtResults.AppendText($"  {string.Join(", ", row)}\n");
            }

            txtResults.AppendText("\nУсловные вероятности p(a|b):\n");
            for (int i = 0; i < results.ConditionalProbabilitiesAB.GetLength(0); i++)
            {
                var row = Enumerable.Range(0, results.ConditionalProbabilitiesAB.GetLength(1))
                                   .Select(j => results.ConditionalProbabilitiesAB[i, j].ToString("F4"));
                txtResults.AppendText($"  {string.Join(", ", row)}\n");
            }
        }
        public class CalculationResults
        {
            public double[] EnsembleA { get; set; }
            public double[] EnsembleB { get; set; }
            public double[,] ConditionalProbabilities { get; set; }
            public double[,] JointProbabilities { get; set; }
            public double[,] ConditionalProbabilitiesAB { get; set; }
            public double EntropyA { get; set; }
            public double EntropyB { get; set; }
            public double ConditionalEntropyBA { get; set; }
            public double ConditionalEntropyAB { get; set; }
            public double JointEntropy { get; set; }
            public double MutualInformation { get; set; }
        }

        public class InformationTheoryCalculator
        {
            public CalculationResults CalculateFromDataGrids(DataGridView dgvA, DataGridView dgvP)
            {
                // Получаем данные из DataGridView
                double[] ensembleA = GetEnsembleA(dgvA);
                double[,] conditionalProbabilities = GetConditionalProbabilities(dgvP);

                return Calculate(ensembleA, conditionalProbabilities);
            }

            private double[] GetEnsembleA(DataGridView dgv)
            {
                int cols = dgv.Columns.Count;
                double[] ensemble = new double[cols];

                for (int i = 0; i < cols; i++)
                {
                    if (dgv.Rows[0].Cells[i].Value != null &&
                        double.TryParse(dgv.Rows[0].Cells[i].Value.ToString(), out double value))
                    {
                        ensemble[i] = value;
                    }
                    else
                    {
                        throw new Exception($"Неверное значение в ансамбле A, столбец {i + 1}");
                    }
                }

                return ensemble;
            }

            private double[,] GetConditionalProbabilities(DataGridView dgv)
            {
                int rows = dgv.Rows.Count;
                int cols = dgv.Columns.Count;
                double[,] probabilities = new double[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value != null &&
                            double.TryParse(dgv.Rows[i].Cells[j].Value.ToString(), out double value))
                        {
                            probabilities[i, j] = value;
                        }
                        else
                        {
                            throw new Exception($"Неверное значение в условных вероятностях, строка {i + 1}, столбец {j + 1}");
                        }
                    }
                }

                return probabilities;
            }

            public CalculationResults Calculate(double[] ensembleA, double[,] pBA)
            {
                int rows = pBA.GetLength(0);
                int cols = pBA.GetLength(1);

                // Проверка суммы вероятностей ансамбля A
                double sumA = ensembleA.Sum();
                if (Math.Abs(sumA - 1.0) > 0.001)
                    throw new Exception($"Сумма вероятностей ансамбля A должна быть равна 1. Текущая сумма: {sumA}");

                // Расчет ансамбля B
                double[] ensembleB = new double[cols];
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        ensembleB[j] += ensembleA[i] * pBA[i, j];
                    }
                }

                // Совместные вероятности p(a,b)
                double[,] jointProbabilities = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        jointProbabilities[i, j] = ensembleA[i] * pBA[i, j];
                    }
                }

                // Условные вероятности p(a|b)
                double[,] pAB = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (ensembleB[j] > 0)
                            pAB[i, j] = jointProbabilities[i, j] / ensembleB[j];
                        else
                            pAB[i, j] = 0;
                    }
                }

                // Энтропии
                double entropyA = CalculateEntropy(ensembleA);
                double entropyB = CalculateEntropy(ensembleB);
                double jointEntropy = CalculateJointEntropy(jointProbabilities);
                double conditionalEntropyBA = jointEntropy - entropyA;
                double conditionalEntropyAB = jointEntropy - entropyB;
                double mutualInformation = entropyA - conditionalEntropyAB;

                return new CalculationResults
                {
                    EnsembleA = ensembleA,
                    EnsembleB = ensembleB,
                    ConditionalProbabilities = pBA,
                    JointProbabilities = jointProbabilities,
                    ConditionalProbabilitiesAB = pAB,
                    EntropyA = entropyA,
                    EntropyB = entropyB,
                    ConditionalEntropyBA = conditionalEntropyBA,
                    ConditionalEntropyAB = conditionalEntropyAB,
                    JointEntropy = jointEntropy,
                    MutualInformation = mutualInformation
                };
            }

            private double CalculateEntropy(double[] probabilities)
            {
                double entropy = 0;
                foreach (double p in probabilities)
                {
                    if (p > 0)
                        entropy -= p * Math.Log(p, 2);
                }
                return entropy;
            }

            private double CalculateJointEntropy(double[,] jointProbabilities)
            {
                double entropy = 0;
                int rows = jointProbabilities.GetLength(0);
                int cols = jointProbabilities.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        double p = jointProbabilities[i, j];
                        if (p > 0)
                            entropy -= p * Math.Log(p, 2);
                    }
                }
                return entropy;
            }
        }

    }
}
