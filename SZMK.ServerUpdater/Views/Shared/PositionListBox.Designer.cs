namespace SZMK.ServerUpdater.Views.Shared
{
    partial class PositionListBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionListBox));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Info_TB = new System.Windows.Forms.TextBox();
            this.Title_L = new System.Windows.Forms.Label();
            this.Add_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Info_TB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Title_L, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Add_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 231);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Info_TB
            // 
            this.Info_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Info_TB.Location = new System.Drawing.Point(5, 50);
            this.Info_TB.Margin = new System.Windows.Forms.Padding(5);
            this.Info_TB.Multiline = true;
            this.Info_TB.Name = "Info_TB";
            this.Info_TB.Size = new System.Drawing.Size(428, 96);
            this.Info_TB.TabIndex = 0;
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
            this.Title_L.Size = new System.Drawing.Size(428, 35);
            this.Title_L.TabIndex = 1;
            this.Title_L.Text = "Добавление информации";
            this.Title_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add_B
            // 
            this.Add_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.Add_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Add_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Add_B.Location = new System.Drawing.Point(5, 156);
            this.Add_B.Margin = new System.Windows.Forms.Padding(5);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(428, 30);
            this.Add_B.TabIndex = 2;
            this.Add_B.Text = "Применить";
            this.Add_B.UseVisualStyleBackColor = false;
            // 
            // Cancel_B
            // 
            this.Cancel_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Cancel_B.Location = new System.Drawing.Point(5, 196);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(428, 30);
            this.Cancel_B.TabIndex = 3;
            this.Cancel_B.Text = "Отменить";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // PositionListBox
            // 
            this.AcceptButton = this.Add_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(438, 231);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionListBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление информации";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PositionListBox_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Add_B;
        private System.Windows.Forms.Button Cancel_B;
        public System.Windows.Forms.TextBox Info_TB;
        public System.Windows.Forms.Label Title_L;
    }
}