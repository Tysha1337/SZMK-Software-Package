namespace SZMK.Desktop.Views.Shared
{
    partial class Settings_MobileApp
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
            this.Generate_B = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.IP_TB = new System.Windows.Forms.TextBox();
            this.OK_B = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.QR_PB = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QR_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Generate_B
            // 
            this.Generate_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.Generate_B, 2);
            this.Generate_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Generate_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Generate_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Generate_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Generate_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Generate_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Generate_B.Location = new System.Drawing.Point(5, 112);
            this.Generate_B.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Generate_B.Name = "Generate_B";
            this.Generate_B.Size = new System.Drawing.Size(297, 33);
            this.Generate_B.TabIndex = 65;
            this.Generate_B.Text = "Сохранить и обновить QR";
            this.Generate_B.UseVisualStyleBackColor = false;
            this.Generate_B.Click += new System.EventHandler(this.Generate_B_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(5, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 26);
            this.label7.TabIndex = 67;
            this.label7.Text = "Порт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(5, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 24);
            this.label6.TabIndex = 66;
            this.label6.Text = "IP - адрес";
            // 
            // Port_TB
            // 
            this.Port_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Port_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Port_TB.Location = new System.Drawing.Point(78, 81);
            this.Port_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Port_TB.Size = new System.Drawing.Size(227, 20);
            this.Port_TB.TabIndex = 69;
            this.Port_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IP_TB
            // 
            this.IP_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.IP_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IP_TB.Location = new System.Drawing.Point(78, 57);
            this.IP_TB.Margin = new System.Windows.Forms.Padding(2);
            this.IP_TB.Name = "IP_TB";
            this.IP_TB.ReadOnly = true;
            this.IP_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IP_TB.Size = new System.Drawing.Size(227, 20);
            this.IP_TB.TabIndex = 68;
            this.IP_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.OK_B, 2);
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.OK_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.OK_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.OK_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK_B.Location = new System.Drawing.Point(5, 249);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(297, 33);
            this.OK_B.TabIndex = 72;
            this.OK_B.Text = "Завершить редактирование";
            this.OK_B.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(529, 35);
            this.label3.TabIndex = 73;
            this.label3.Text = "Настройки подключения мобильного приложения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 90);
            this.label4.TabIndex = 74;
            this.label4.Text = "Используйте QR сканер для определения\r\nпараметров подлючения на устройстве";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OK_B, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.IP_TB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Generate_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Port_TB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.QR_PB, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 286);
            this.tableLayoutPanel1.TabIndex = 75;
            // 
            // QR_PB
            // 
            this.QR_PB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QR_PB.Location = new System.Drawing.Point(309, 57);
            this.QR_PB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 7);
            this.QR_PB.Name = "QR_PB";
            this.tableLayoutPanel1.SetRowSpan(this.QR_PB, 5);
            this.QR_PB.Size = new System.Drawing.Size(225, 225);
            this.QR_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QR_PB.TabIndex = 0;
            this.QR_PB.TabStop = false;
            // 
            // ADSettingsMobileApp_F
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 286);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ADSettingsMobileApp_F";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки мобильного приложения";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QR_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Generate_B;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox Port_TB;
        public System.Windows.Forms.TextBox IP_TB;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox QR_PB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}