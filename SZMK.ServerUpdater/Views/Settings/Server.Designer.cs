namespace SZMK.ServerUpdater.Views.Settings
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IP_TB = new System.Windows.Forms.TextBox();
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.Save_B = new System.Windows.Forms.Button();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.58314F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.41686F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.IP_TB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Port_TB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Save_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(427, 189);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Настройки подключения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(5, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Порт";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IP_TB
            // 
            this.IP_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IP_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.IP_TB.Location = new System.Drawing.Point(63, 50);
            this.IP_TB.Margin = new System.Windows.Forms.Padding(5);
            this.IP_TB.Name = "IP_TB";
            this.IP_TB.ReadOnly = true;
            this.IP_TB.Size = new System.Drawing.Size(359, 22);
            this.IP_TB.TabIndex = 5;
            // 
            // Port_TB
            // 
            this.Port_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Port_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Port_TB.Location = new System.Drawing.Point(63, 82);
            this.Port_TB.Margin = new System.Windows.Forms.Padding(5);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.Size = new System.Drawing.Size(359, 22);
            this.Port_TB.TabIndex = 6;
            // 
            // Save_B
            // 
            this.Save_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.SetColumnSpan(this.Save_B, 2);
            this.Save_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Save_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Save_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Save_B.Location = new System.Drawing.Point(5, 114);
            this.Save_B.Margin = new System.Windows.Forms.Padding(5);
            this.Save_B.Name = "Save_B";
            this.Save_B.Size = new System.Drawing.Size(417, 30);
            this.Save_B.TabIndex = 0;
            this.Save_B.Text = "Сохранить";
            this.Save_B.UseVisualStyleBackColor = false;
            // 
            // Cancel_B
            // 
            this.Cancel_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.SetColumnSpan(this.Cancel_B, 2);
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Cancel_B.Location = new System.Drawing.Point(5, 154);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(417, 30);
            this.Cancel_B.TabIndex = 1;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // Server
            // 
            this.AcceptButton = this.Save_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(427, 189);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(443, 224);
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Button Save_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox IP_TB;
        public System.Windows.Forms.TextBox Port_TB;
    }
}