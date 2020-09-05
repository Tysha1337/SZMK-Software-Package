namespace SZMK.TeklaInteraction.Tekla21_1.Views.Main
{
    partial class Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OldOrder_TB = new System.Windows.Forms.TextBox();
            this.NewOrder_TB = new System.Windows.Forms.TextBox();
            this.OK_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OldOrder_TB, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.NewOrder_TB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.OK_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(715, 179);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Было";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(707, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список чертежей";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OldOrder_TB
            // 
            this.OldOrder_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.OldOrder_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OldOrder_TB.Location = new System.Drawing.Point(5, 112);
            this.OldOrder_TB.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.OldOrder_TB.Name = "OldOrder_TB";
            this.OldOrder_TB.ReadOnly = true;
            this.OldOrder_TB.Size = new System.Drawing.Size(347, 20);
            this.OldOrder_TB.TabIndex = 12;
            this.OldOrder_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NewOrder_TB
            // 
            this.NewOrder_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.NewOrder_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewOrder_TB.Location = new System.Drawing.Point(362, 112);
            this.NewOrder_TB.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.NewOrder_TB.Name = "NewOrder_TB";
            this.NewOrder_TB.ReadOnly = true;
            this.NewOrder_TB.Size = new System.Drawing.Size(348, 20);
            this.NewOrder_TB.TabIndex = 13;
            this.NewOrder_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.OK_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.OK_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.OK_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.OK_B.Location = new System.Drawing.Point(5, 141);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(347, 33);
            this.OK_B.TabIndex = 58;
            this.OK_B.Text = "Подтвердить";
            this.OK_B.UseVisualStyleBackColor = false;
            // 
            // Cancel_B
            // 
            this.Cancel_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Cancel_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Cancel_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Cancel_B.Location = new System.Drawing.Point(362, 141);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(348, 33);
            this.Cancel_B.TabIndex = 59;
            this.Cancel_B.Text = "Отменить";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(362, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "Стало";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(715, 179);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(731, 218);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(731, 218);
            this.Name = "Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обновление чертежа";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox OldOrder_TB;
        public System.Windows.Forms.TextBox NewOrder_TB;
        public System.Windows.Forms.Button OK_B;
        public System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Label label3;
    }
}