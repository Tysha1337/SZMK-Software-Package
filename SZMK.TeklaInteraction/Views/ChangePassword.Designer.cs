namespace SZMK.TeklaInteraction.Views
{
    partial class ChangePassword
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.OK_B = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.OldPassword_TB = new System.Windows.Forms.TextBox();
            this.ComparePassword_TB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NewPassword_TB = new System.Windows.Forms.TextBox();
            this.CheckPass_CB = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.OK_B, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.OldPassword_TB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ComparePassword_TB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.NewPassword_TB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.CheckPass_CB, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 238);
            this.tableLayoutPanel1.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 35);
            this.label1.TabIndex = 84;
            this.label1.Text = "Изменение пароля";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cancel_B
            // 
            this.Cancel_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.Cancel_B, 2);
            this.Cancel_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Cancel_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Cancel_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel_B.Location = new System.Drawing.Point(5, 200);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5, 0, 5, 14);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(404, 33);
            this.Cancel_B.TabIndex = 86;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = false;
            this.Cancel_B.Click += new System.EventHandler(this.Cancel_B_Click);
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.OK_B, 2);
            this.OK_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.OK_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.OK_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.OK_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK_B.Location = new System.Drawing.Point(5, 160);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(404, 33);
            this.OK_B.TabIndex = 85;
            this.OK_B.Text = "Изменить";
            this.OK_B.UseVisualStyleBackColor = false;
            this.OK_B.Click += new System.EventHandler(this.OK_B_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Старый пароль";
            // 
            // OldPassword_TB
            // 
            this.OldPassword_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.OldPassword_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OldPassword_TB.Location = new System.Drawing.Point(173, 57);
            this.OldPassword_TB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.OldPassword_TB.Name = "OldPassword_TB";
            this.OldPassword_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OldPassword_TB.Size = new System.Drawing.Size(236, 20);
            this.OldPassword_TB.TabIndex = 56;
            this.OldPassword_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OldPassword_TB.UseSystemPasswordChar = true;
            // 
            // ComparePassword_TB
            // 
            this.ComparePassword_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ComparePassword_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComparePassword_TB.Location = new System.Drawing.Point(173, 105);
            this.ComparePassword_TB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.ComparePassword_TB.Name = "ComparePassword_TB";
            this.ComparePassword_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ComparePassword_TB.Size = new System.Drawing.Size(236, 20);
            this.ComparePassword_TB.TabIndex = 60;
            this.ComparePassword_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ComparePassword_TB.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(5, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 16);
            this.label6.TabIndex = 59;
            this.label6.Text = "Подтверждение пароля";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Новый пароль";
            // 
            // NewPassword_TB
            // 
            this.NewPassword_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.NewPassword_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPassword_TB.Location = new System.Drawing.Point(173, 81);
            this.NewPassword_TB.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.NewPassword_TB.Name = "NewPassword_TB";
            this.NewPassword_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NewPassword_TB.Size = new System.Drawing.Size(236, 20);
            this.NewPassword_TB.TabIndex = 58;
            this.NewPassword_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NewPassword_TB.UseSystemPasswordChar = true;
            // 
            // CheckPass_CB
            // 
            this.CheckPass_CB.AutoSize = true;
            this.CheckPass_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.CheckPass_CB.Location = new System.Drawing.Point(174, 130);
            this.CheckPass_CB.Name = "CheckPass_CB";
            this.CheckPass_CB.Size = new System.Drawing.Size(140, 20);
            this.CheckPass_CB.TabIndex = 87;
            this.CheckPass_CB.Text = "Показать пароль";
            this.CheckPass_CB.UseVisualStyleBackColor = true;
            this.CheckPass_CB.Click += new System.EventHandler(this.CheckPass_CB_CheckedChanged);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 238);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 277);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 277);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change password";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox OldPassword_TB;
        public System.Windows.Forms.TextBox ComparePassword_TB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox NewPassword_TB;
        public System.Windows.Forms.CheckBox CheckPass_CB;
    }
}