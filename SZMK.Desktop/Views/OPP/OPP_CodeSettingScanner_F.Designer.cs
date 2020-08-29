namespace SZMK.Desktop.Views.OPP
{
    partial class OPP_CodeSettingScanner_F
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
            this.NoSuffix_PB = new System.Windows.Forms.PictureBox();
            this.SerialPort_PB = new System.Windows.Forms.PictureBox();
            this.Manual_PB = new System.Windows.Forms.PictureBox();
            this.Automatic_PB = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoSuffix_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerialPort_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manual_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Automatic_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NoSuffix_PB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SerialPort_PB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Manual_PB, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Automatic_PB, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 280);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список портов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cancel_B
            // 
            this.Cancel_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.SetColumnSpan(this.Cancel_B, 2);
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Cancel_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Cancel_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Cancel_B.Location = new System.Drawing.Point(5, 240);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(379, 35);
            this.Cancel_B.TabIndex = 59;
            this.Cancel_B.Text = "Закрыть";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // NoSuffix_PB
            // 
            this.NoSuffix_PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NoSuffix_PB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoSuffix_PB.Image = global::SZMK.Desktop.Properties.Resources.No_Suffix;
            this.NoSuffix_PB.Location = new System.Drawing.Point(3, 58);
            this.NoSuffix_PB.Name = "NoSuffix_PB";
            this.NoSuffix_PB.Size = new System.Drawing.Size(188, 84);
            this.NoSuffix_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NoSuffix_PB.TabIndex = 60;
            this.NoSuffix_PB.TabStop = false;
            // 
            // SerialPort_PB
            // 
            this.SerialPort_PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SerialPort_PB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerialPort_PB.Image = global::SZMK.Desktop.Properties.Resources.SerialPort;
            this.SerialPort_PB.Location = new System.Drawing.Point(197, 58);
            this.SerialPort_PB.Name = "SerialPort_PB";
            this.SerialPort_PB.Size = new System.Drawing.Size(189, 84);
            this.SerialPort_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SerialPort_PB.TabIndex = 61;
            this.SerialPort_PB.TabStop = false;
            // 
            // Manual_PB
            // 
            this.Manual_PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Manual_PB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Manual_PB.Image = global::SZMK.Desktop.Properties.Resources.Manual_Scanning;
            this.Manual_PB.Location = new System.Drawing.Point(3, 148);
            this.Manual_PB.Name = "Manual_PB";
            this.Manual_PB.Size = new System.Drawing.Size(188, 84);
            this.Manual_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Manual_PB.TabIndex = 62;
            this.Manual_PB.TabStop = false;
            // 
            // Automatic_PB
            // 
            this.Automatic_PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Automatic_PB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Automatic_PB.Image = global::SZMK.Desktop.Properties.Resources.Automatic_Scanning;
            this.Automatic_PB.Location = new System.Drawing.Point(197, 148);
            this.Automatic_PB.Name = "Automatic_PB";
            this.Automatic_PB.Size = new System.Drawing.Size(189, 84);
            this.Automatic_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Automatic_PB.TabIndex = 63;
            this.Automatic_PB.TabStop = false;
            // 
            // OPP_CodeSettingScanner_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 280);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 319);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 319);
            this.Name = "OPP_CodeSettingScanner_F";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "КШК коды";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NoSuffix_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerialPort_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manual_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Automatic_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox NoSuffix_PB;
        public System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.PictureBox SerialPort_PB;
        private System.Windows.Forms.PictureBox Manual_PB;
        private System.Windows.Forms.PictureBox Automatic_PB;
    }
}