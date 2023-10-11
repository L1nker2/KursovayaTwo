namespace Adelina
{
    partial class DealForm
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button6 = new Button();
            panel1 = new Panel();
            button7 = new Button();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            button8 = new Button();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox6 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 13);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(982, 482);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(13, 679);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(118, 37);
            button1.TabIndex = 1;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Location = new Point(138, 679);
            button2.Name = "button2";
            button2.Size = new Size(105, 37);
            button2.TabIndex = 2;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Location = new Point(249, 679);
            button3.Name = "button3";
            button3.Size = new Size(121, 37);
            button3.TabIndex = 3;
            button3.Text = "Изменить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button6
            // 
            button6.AutoSize = true;
            button6.Location = new Point(376, 680);
            button6.Name = "button6";
            button6.Size = new Size(121, 37);
            button6.TabIndex = 8;
            button6.Text = "В меню";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button7);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 502);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 170);
            panel1.TabIndex = 9;
            // 
            // button7
            // 
            button7.AutoSize = true;
            button7.Location = new Point(99, 126);
            button7.Name = "button7";
            button7.Size = new Size(118, 37);
            button7.TabIndex = 6;
            button7.Text = "Добавить";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(99, 85);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(247, 35);
            comboBox3.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(99, 44);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(247, 35);
            comboBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(99, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(247, 35);
            comboBox1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 88);
            label4.Name = "label4";
            label4.Size = new Size(87, 27);
            label4.TabIndex = 2;
            label4.Text = "Клиент";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 47);
            label3.Name = "label3";
            label3.Size = new Size(84, 27);
            label3.TabIndex = 1;
            label3.Text = "Курьер";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 6);
            label2.Name = "label2";
            label2.Size = new Size(70, 27);
            label2.TabIndex = 0;
            label2.Text = "Товар";
            // 
            // panel2
            // 
            panel2.Controls.Add(button8);
            panel2.Controls.Add(comboBox4);
            panel2.Controls.Add(comboBox5);
            panel2.Controls.Add(comboBox6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(383, 502);
            panel2.Name = "panel2";
            panel2.Size = new Size(354, 170);
            panel2.TabIndex = 10;
            // 
            // button8
            // 
            button8.AutoSize = true;
            button8.Location = new Point(99, 126);
            button8.Name = "button8";
            button8.Size = new Size(121, 37);
            button8.TabIndex = 6;
            button8.Text = "Изменить";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(99, 85);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(247, 35);
            comboBox4.TabIndex = 5;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(99, 44);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(247, 35);
            comboBox5.TabIndex = 4;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(99, 3);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(247, 35);
            comboBox6.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 88);
            label5.Name = "label5";
            label5.Size = new Size(87, 27);
            label5.TabIndex = 2;
            label5.Text = "Клиент";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 47);
            label6.Name = "label6";
            label6.Size = new Size(84, 27);
            label6.TabIndex = 1;
            label6.Text = "Курьер";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 6);
            label7.Name = "label7";
            label7.Size = new Size(70, 27);
            label7.TabIndex = 0;
            label7.Text = "Товар";
            // 
            // DealForm
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "DealForm";
            Text = "Сделки";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button6;
        private Panel panel1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button7;
        private Panel panel2;
        private Button button8;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}