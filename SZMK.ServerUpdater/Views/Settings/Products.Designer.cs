namespace SZMK.ServerUpdater.Views.Settings
{
    partial class SettingsProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsProducts));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Add_B = new System.Windows.Forms.Button();
            this.Change_B = new System.Windows.Forms.Button();
            this.Delete_B = new System.Windows.Forms.Button();
            this.Products_LB = new System.Windows.Forms.ListBox();
            this.Title_L = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Add_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Change_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Delete_B, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Products_LB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Title_L, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 334);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Add_B
            // 
            this.Add_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.Add_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Add_B.Location = new System.Drawing.Point(5, 219);
            this.Add_B.Margin = new System.Windows.Forms.Padding(5);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(305, 30);
            this.Add_B.TabIndex = 0;
            this.Add_B.Text = "Добавить";
            this.Add_B.UseVisualStyleBackColor = false;
            this.Add_B.Click += new System.EventHandler(this.Add_B_Click);
            // 
            // Change_B
            // 
            this.Change_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.Change_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Change_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Change_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Change_B.Location = new System.Drawing.Point(5, 259);
            this.Change_B.Margin = new System.Windows.Forms.Padding(5);
            this.Change_B.Name = "Change_B";
            this.Change_B.Size = new System.Drawing.Size(305, 30);
            this.Change_B.TabIndex = 1;
            this.Change_B.Text = "Изменить";
            this.Change_B.UseVisualStyleBackColor = false;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // Delete_B
            // 
            this.Delete_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.Delete_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Delete_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Delete_B.Location = new System.Drawing.Point(5, 299);
            this.Delete_B.Margin = new System.Windows.Forms.Padding(5);
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.Size = new System.Drawing.Size(305, 30);
            this.Delete_B.TabIndex = 2;
            this.Delete_B.Text = "Удалить";
            this.Delete_B.UseVisualStyleBackColor = false;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // Products_LB
            // 
            this.Products_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Products_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Products_LB.FormattingEnabled = true;
            this.Products_LB.ItemHeight = 16;
            this.Products_LB.Location = new System.Drawing.Point(5, 50);
            this.Products_LB.Margin = new System.Windows.Forms.Padding(5);
            this.Products_LB.Name = "Products_LB";
            this.Products_LB.Size = new System.Drawing.Size(305, 159);
            this.Products_LB.TabIndex = 3;
            // 
            // Title_L
            // 
            this.Title_L.AutoSize = true;
            this.Title_L.BackColor = System.Drawing.Color.Tan;
            this.Title_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Title_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title_L.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Title_L.Location = new System.Drawing.Point(5, 5);
            this.Title_L.Margin = new System.Windows.Forms.Padding(5);
            this.Title_L.Name = "Title_L";
            this.Title_L.Size = new System.Drawing.Size(305, 35);
            this.Title_L.TabIndex = 4;
            this.Title_L.Text = "Список продуктов";
            this.Title_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(315, 334);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка продуктов";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Add_B;
        private System.Windows.Forms.Button Change_B;
        private System.Windows.Forms.Button Delete_B;
        private System.Windows.Forms.Label Title_L;
        public System.Windows.Forms.ListBox Products_LB;
    }
}