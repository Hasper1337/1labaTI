namespace _1labaTI
{
    partial class Form2
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
            this.variant = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stroki = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.stolbs = new System.Windows.Forms.NumericUpDown();
            this.matrix1_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.calculate_btn = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.variant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stroki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stolbs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // variant
            // 
            this.variant.Location = new System.Drawing.Point(109, 14);
            this.variant.Name = "variant";
            this.variant.Size = new System.Drawing.Size(59, 20);
            this.variant.TabIndex = 0;
            this.variant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.variant.ValueChanged += new System.EventHandler(this.variant_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер варианта";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кол-во строк";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // stroki
            // 
            this.stroki.Location = new System.Drawing.Point(109, 47);
            this.stroki.Name = "stroki";
            this.stroki.Size = new System.Drawing.Size(59, 20);
            this.stroki.TabIndex = 2;
            this.stroki.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stroki.ValueChanged += new System.EventHandler(this.stroki_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кол-во столбцов";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // stolbs
            // 
            this.stolbs.Location = new System.Drawing.Point(109, 82);
            this.stolbs.Name = "stolbs";
            this.stolbs.Size = new System.Drawing.Size(59, 20);
            this.stolbs.TabIndex = 4;
            this.stolbs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stolbs.ValueChanged += new System.EventHandler(this.stolbs_ValueChanged);
            // 
            // matrix1_btn
            // 
            this.matrix1_btn.Location = new System.Drawing.Point(15, 121);
            this.matrix1_btn.Name = "matrix1_btn";
            this.matrix1_btn.Size = new System.Drawing.Size(153, 23);
            this.matrix1_btn.TabIndex = 6;
            this.matrix1_btn.Text = "Задать размеры матрицы";
            this.matrix1_btn.UseVisualStyleBackColor = true;
            this.matrix1_btn.Click += new System.EventHandler(this.matrix1_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ансамбль A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Условные вероятности p(bj/ai)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 334);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(339, 105);
            this.dataGridView1.TabIndex = 9;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 191);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(339, 105);
            this.dataGridView2.TabIndex = 10;
            // 
            // calculate_btn
            // 
            this.calculate_btn.Location = new System.Drawing.Point(15, 465);
            this.calculate_btn.Name = "calculate_btn";
            this.calculate_btn.Size = new System.Drawing.Size(153, 23);
            this.calculate_btn.TabIndex = 11;
            this.calculate_btn.Text = "Рассчитать";
            this.calculate_btn.UseVisualStyleBackColor = true;
            this.calculate_btn.Click += new System.EventHandler(this.calculate_btn_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(57, -1);
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(342, 489);
            this.txtResults.TabIndex = 12;
            this.txtResults.Text = "";
            this.txtResults.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 515);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.calculate_btn);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.matrix1_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stolbs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stroki);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.variant);
            this.Name = "Form2";
            this.Text = "Случай 1: Ввести A и p(bj/ai)";
            ((System.ComponentModel.ISupportInitialize)(this.variant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stroki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stolbs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown variant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown stroki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown stolbs;
        private System.Windows.Forms.Button matrix1_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button calculate_btn;
        private System.Windows.Forms.RichTextBox txtResults;
    }
}