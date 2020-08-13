namespace SZMK.BotLogger.Views
{
    partial class AddProduct
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
            this.Cancel_B = new System.Windows.Forms.Button();
            this.OK_B = new System.Windows.Forms.Button();
            this.ProductName_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.OK_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProductName_TB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 155);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Cancel_B
            // 
            this.Cancel_B.BackColor = System.Drawing.Color.PaleGreen;
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Cancel_B.Location = new System.Drawing.Point(5, 120);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(376, 30);
            this.Cancel_B.TabIndex = 4;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.PaleGreen;
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.OK_B.Location = new System.Drawing.Point(5, 80);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(376, 30);
            this.OK_B.TabIndex = 1;
            this.OK_B.Text = "OK";
            this.OK_B.UseVisualStyleBackColor = false;
            // 
            // ProductName_TB
            // 
            this.ProductName_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductName_TB.Location = new System.Drawing.Point(5, 50);
            this.ProductName_TB.Margin = new System.Windows.Forms.Padding(5);
            this.ProductName_TB.Name = "ProductName_TB";
            this.ProductName_TB.Size = new System.Drawing.Size(376, 20);
            this.ProductName_TB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LawnGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите имя продукта";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 155);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление продукта";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox ProductName_TB;
    }
}