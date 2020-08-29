namespace SZMK.Desktop.Views.Admin.MainSettings
{
    partial class Settings_Program
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
            this.SaveArchive_B = new System.Windows.Forms.Button();
            this.OK_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ColorN2_NUD = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CheckMarks_CB = new System.Windows.Forms.CheckBox();
            this.N1_NUD = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ColorN1_NUD = new System.Windows.Forms.PictureBox();
            this.N2_NUD = new System.Windows.Forms.NumericUpDown();
            this.CheckProcess_CB = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorN2_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N1_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorN1_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N2_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveArchive_B
            // 
            this.SaveArchive_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.SaveArchive_B, 3);
            this.SaveArchive_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveArchive_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.SaveArchive_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.SaveArchive_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.SaveArchive_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveArchive_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveArchive_B.Location = new System.Drawing.Point(5, 213);
            this.SaveArchive_B.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.SaveArchive_B.Name = "SaveArchive_B";
            this.SaveArchive_B.Size = new System.Drawing.Size(477, 33);
            this.SaveArchive_B.TabIndex = 90;
            this.SaveArchive_B.Text = "Проверить и сохранить";
            this.SaveArchive_B.UseVisualStyleBackColor = false;
            this.SaveArchive_B.Click += new System.EventHandler(this.SaveArchive_B_Click);
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.OK_B, 3);
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.OK_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.OK_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.OK_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK_B.Location = new System.Drawing.Point(5, 253);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5, 0, 5, 14);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(477, 33);
            this.OK_B.TabIndex = 91;
            this.OK_B.Text = "Завершить редактирование";
            this.OK_B.UseVisualStyleBackColor = false;
            this.OK_B.Click += new System.EventHandler(this.OK_B_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CheckMarks_CB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.N2_NUD, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ColorN2_NUD, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.N1_NUD, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ColorN1_NUD, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CheckProcess_CB, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SaveArchive_B, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.OK_B, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 292);
            this.tableLayoutPanel1.TabIndex = 96;
            // 
            // ColorN2_NUD
            // 
            this.ColorN2_NUD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.ColorN2_NUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorN2_NUD.Location = new System.Drawing.Point(357, 184);
            this.ColorN2_NUD.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.ColorN2_NUD.Name = "ColorN2_NUD";
            this.ColorN2_NUD.Size = new System.Drawing.Size(125, 20);
            this.ColorN2_NUD.TabIndex = 104;
            this.ColorN2_NUD.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 3);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.Location = new System.Drawing.Point(5, 113);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(477, 35);
            this.label8.TabIndex = 98;
            this.label8.Text = "Визуализация просроченных чертежей";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 3);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(5, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(477, 35);
            this.label7.TabIndex = 96;
            this.label7.Text = "Общие настройки приложения";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckMarks_CB
            // 
            this.CheckMarks_CB.AutoSize = true;
            this.CheckMarks_CB.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.CheckMarks_CB, 3);
            this.CheckMarks_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckMarks_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckMarks_CB.ForeColor = System.Drawing.Color.Black;
            this.CheckMarks_CB.Location = new System.Drawing.Point(120, 57);
            this.CheckMarks_CB.Margin = new System.Windows.Forms.Padding(120, 2, 2, 2);
            this.CheckMarks_CB.Name = "CheckMarks_CB";
            this.CheckMarks_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckMarks_CB.Size = new System.Drawing.Size(365, 20);
            this.CheckMarks_CB.TabIndex = 97;
            this.CheckMarks_CB.Text = "&Проверка строчных букв в марке";
            this.CheckMarks_CB.UseVisualStyleBackColor = false;
            // 
            // N1_NUD
            // 
            this.N1_NUD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.N1_NUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.N1_NUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.N1_NUD.Location = new System.Drawing.Point(50, 160);
            this.N1_NUD.Margin = new System.Windows.Forms.Padding(2);
            this.N1_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.N1_NUD.Name = "N1_NUD";
            this.N1_NUD.Size = new System.Drawing.Size(303, 20);
            this.N1_NUD.TabIndex = 99;
            this.N1_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.Location = new System.Drawing.Point(5, 158);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 24);
            this.label9.TabIndex = 101;
            this.label9.Text = "Дней";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.Location = new System.Drawing.Point(5, 182);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 24);
            this.label10.TabIndex = 102;
            this.label10.Text = "Дней";
            // 
            // ColorN1_NUD
            // 
            this.ColorN1_NUD.BackColor = System.Drawing.Color.Yellow;
            this.ColorN1_NUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorN1_NUD.Location = new System.Drawing.Point(357, 160);
            this.ColorN1_NUD.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.ColorN1_NUD.Name = "ColorN1_NUD";
            this.ColorN1_NUD.Size = new System.Drawing.Size(125, 20);
            this.ColorN1_NUD.TabIndex = 103;
            this.ColorN1_NUD.TabStop = false;
            // 
            // N2_NUD
            // 
            this.N2_NUD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.N2_NUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.N2_NUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.N2_NUD.Location = new System.Drawing.Point(50, 184);
            this.N2_NUD.Margin = new System.Windows.Forms.Padding(2);
            this.N2_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.N2_NUD.Name = "N2_NUD";
            this.N2_NUD.Size = new System.Drawing.Size(303, 20);
            this.N2_NUD.TabIndex = 100;
            this.N2_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CheckProcess_CB
            // 
            this.CheckProcess_CB.AutoSize = true;
            this.CheckProcess_CB.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.CheckProcess_CB, 3);
            this.CheckProcess_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckProcess_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckProcess_CB.ForeColor = System.Drawing.Color.Black;
            this.CheckProcess_CB.Location = new System.Drawing.Point(120, 81);
            this.CheckProcess_CB.Margin = new System.Windows.Forms.Padding(120, 2, 2, 2);
            this.CheckProcess_CB.Name = "CheckProcess_CB";
            this.CheckProcess_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckProcess_CB.Size = new System.Drawing.Size(365, 20);
            this.CheckProcess_CB.TabIndex = 105;
            this.CheckProcess_CB.Text = "&Разрешить открытие нескольких копий";
            this.CheckProcess_CB.UseVisualStyleBackColor = false;
            // 
            // AD_SettingsProgram_F
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 292);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(503, 331);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(503, 331);
            this.Name = "AD_SettingsProgram_F";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурация программного обеспечения";
            this.Load += new System.EventHandler(this.AD_SettingsProgram_F_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorN2_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N1_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorN1_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N2_NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SaveArchive_B;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox ColorN2_NUD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox ColorN1_NUD;
        public System.Windows.Forms.CheckBox CheckMarks_CB;
        public System.Windows.Forms.NumericUpDown N1_NUD;
        public System.Windows.Forms.NumericUpDown N2_NUD;
        public System.Windows.Forms.CheckBox CheckProcess_CB;
    }
}