namespace SZMK.Desktop.Views.Admin.MainSettings
{
    partial class Settings_DataBase
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
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.Server_TB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Save_B = new System.Windows.Forms.Button();
            this.Owner_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OK_B = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Port_TB
            // 
            this.Port_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Port_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Port_TB.Location = new System.Drawing.Point(82, 81);
            this.Port_TB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Port_TB.Size = new System.Drawing.Size(309, 20);
            this.Port_TB.TabIndex = 74;
            this.Port_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Server_TB
            // 
            this.Server_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Server_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Server_TB.Location = new System.Drawing.Point(82, 57);
            this.Server_TB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.Server_TB.Name = "Server_TB";
            this.Server_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Server_TB.Size = new System.Drawing.Size(309, 20);
            this.Server_TB.TabIndex = 73;
            this.Server_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(5, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 24);
            this.label7.TabIndex = 72;
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
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 71;
            this.label6.Text = "Сервер";
            // 
            // Save_B
            // 
            this.Save_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.Save_B, 2);
            this.Save_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Save_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Save_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Save_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Save_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save_B.Location = new System.Drawing.Point(5, 237);
            this.Save_B.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Save_B.Name = "Save_B";
            this.Save_B.Size = new System.Drawing.Size(386, 33);
            this.Save_B.TabIndex = 70;
            this.Save_B.Text = "Проверить подключение и сохранить";
            this.Save_B.UseVisualStyleBackColor = false;
            this.Save_B.Click += new System.EventHandler(this.Save_B_Click);
            // 
            // Owner_TB
            // 
            this.Owner_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Owner_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Owner_TB.Location = new System.Drawing.Point(82, 105);
            this.Owner_TB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.Owner_TB.Name = "Owner_TB";
            this.Owner_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Owner_TB.Size = new System.Drawing.Size(309, 20);
            this.Owner_TB.TabIndex = 76;
            this.Owner_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 75;
            this.label1.Text = "Владелец";
            // 
            // Password_TB
            // 
            this.Password_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Password_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Password_TB.Location = new System.Drawing.Point(82, 129);
            this.Password_TB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Password_TB.Size = new System.Drawing.Size(309, 20);
            this.Password_TB.TabIndex = 78;
            this.Password_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 77;
            this.label2.Text = "Пароль";
            // 
            // Name_TB
            // 
            this.Name_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.Name_TB, 2);
            this.Name_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_TB.Location = new System.Drawing.Point(5, 208);
            this.Name_TB.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Name_TB.Name = "Name_TB";
            this.Name_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Name_TB.Size = new System.Drawing.Size(386, 20);
            this.Name_TB.TabIndex = 80;
            this.Name_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(386, 35);
            this.label3.TabIndex = 79;
            this.label3.Text = "Наименование базы данных";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.OK_B.Location = new System.Drawing.Point(5, 277);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5, 0, 5, 7);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(386, 33);
            this.OK_B.TabIndex = 81;
            this.OK_B.Text = "Завершить редактирование";
            this.OK_B.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 35);
            this.label4.TabIndex = 82;
            this.label4.Text = "Настройки базы данных";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OK_B, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Save_B, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.Name_TB, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.Server_TB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Password_TB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Port_TB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Owner_TB, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 315);
            this.tableLayoutPanel1.TabIndex = 83;
            // 
            // ADSettingsDataBase_F
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 315);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ADSettingsDataBase_F";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки базы данных";
            this.Load += new System.EventHandler(this.ADSettingsDataBase_F_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox Port_TB;
        public System.Windows.Forms.TextBox Server_TB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Save_B;
        public System.Windows.Forms.TextBox Owner_TB;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Password_TB;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox Name_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}