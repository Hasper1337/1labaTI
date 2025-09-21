namespace _1labaTI
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calculate_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.matrix1_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.stolbs = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.stroki = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.variant = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stolbs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stroki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variant)).BeginInit();
            this.SuspendLayout();
            // 
            // calculate_btn
            // 
            this.calculate_btn.Location = new System.Drawing.Point(15, 458);
            this.calculate_btn.Name = "calculate_btn";
            this.calculate_btn.Size = new System.Drawing.Size(153, 23);
            this.calculate_btn.TabIndex = 35;
            this.calculate_btn.Text = "Рассчитать";
            this.calculate_btn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 186);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(339, 238);
            this.dataGridView1.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Совместные вероятности P(ai, bj)";
            // 
            // matrix1_btn
            // 
            this.matrix1_btn.Location = new System.Drawing.Point(15, 114);
            this.matrix1_btn.Name = "matrix1_btn";
            this.matrix1_btn.Size = new System.Drawing.Size(153, 23);
            this.matrix1_btn.TabIndex = 30;
            this.matrix1_btn.Text = "Задать размеры матрицы";
            this.matrix1_btn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Кол-во столбцов";
            // 
            // stolbs
            // 
            this.stolbs.Location = new System.Drawing.Point(109, 75);
            this.stolbs.Name = "stolbs";
            this.stolbs.Size = new System.Drawing.Size(59, 20);
            this.stolbs.TabIndex = 28;
            this.stolbs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Кол-во строк";
            // 
            // stroki
            // 
            this.stroki.Location = new System.Drawing.Point(109, 40);
            this.stroki.Name = "stroki";
            this.stroki.Size = new System.Drawing.Size(59, 20);
            this.stroki.TabIndex = 26;
            this.stroki.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Номер варианта";
            // 
            // variant
            // 
            this.variant.Location = new System.Drawing.Point(109, 7);
            this.variant.Name = "variant";
            this.variant.Size = new System.Drawing.Size(59, 20);
            this.variant.TabIndex = 24;
            this.variant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 497);
            this.Controls.Add(this.calculate_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.matrix1_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stolbs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stroki);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.variant);
            this.Name = "Form4";
            this.Text = "Случай 3: Ввести матрицу совместных вероятностей P(ai, bj)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stolbs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stroki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculate_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button matrix1_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown stolbs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown stroki;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown variant;
    }
}