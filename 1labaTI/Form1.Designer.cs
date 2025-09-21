namespace _1labaTI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.A_P_btn = new System.Windows.Forms.RadioButton();
            this.B_P_btn = new System.Windows.Forms.RadioButton();
            this.P_btn = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // A_P_btn
            // 
            this.A_P_btn.AutoSize = true;
            this.A_P_btn.Location = new System.Drawing.Point(26, 42);
            this.A_P_btn.Name = "A_P_btn";
            this.A_P_btn.Size = new System.Drawing.Size(183, 17);
            this.A_P_btn.TabIndex = 0;
            this.A_P_btn.TabStop = true;
            this.A_P_btn.Text = "Ввести для рассчета: A, p(bj/ai)";
            this.A_P_btn.UseVisualStyleBackColor = true;
            this.A_P_btn.CheckedChanged += new System.EventHandler(this.A_P_btn_CheckedChanged);
            // 
            // B_P_btn
            // 
            this.B_P_btn.AutoSize = true;
            this.B_P_btn.Location = new System.Drawing.Point(26, 79);
            this.B_P_btn.Name = "B_P_btn";
            this.B_P_btn.Size = new System.Drawing.Size(183, 17);
            this.B_P_btn.TabIndex = 1;
            this.B_P_btn.TabStop = true;
            this.B_P_btn.Text = "Ввести для рассчета: B, p(ai/bj)";
            this.B_P_btn.UseVisualStyleBackColor = true;
            // 
            // P_btn
            // 
            this.P_btn.AutoSize = true;
            this.P_btn.Location = new System.Drawing.Point(26, 119);
            this.P_btn.Name = "P_btn";
            this.P_btn.Size = new System.Drawing.Size(168, 17);
            this.P_btn.TabIndex = 2;
            this.P_btn.TabStop = true;
            this.P_btn.Text = "Ввести для рассчета: p(ai bj)";
            this.P_btn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 234);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.P_btn);
            this.Controls.Add(this.B_P_btn);
            this.Controls.Add(this.A_P_btn);
            this.Name = "Form1";
            this.Text = "Теория информации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton A_P_btn;
        private System.Windows.Forms.RadioButton B_P_btn;
        private System.Windows.Forms.RadioButton P_btn;
        private System.Windows.Forms.Button button1;
    }
}

