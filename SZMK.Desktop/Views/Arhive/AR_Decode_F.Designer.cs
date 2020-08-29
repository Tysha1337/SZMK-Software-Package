namespace SZMK.Desktop.Views.Arhive
{
    partial class AR_Decode_F
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateAct_TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Scan_DGV = new System.Windows.Forms.DataGridView();
            this.DataMatrixOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unique = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerStatus_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.Add_B = new System.Windows.Forms.Button();
            this.Change_B = new System.Windows.Forms.Button();
            this.TIFF_OFD = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(201)))), ((int)(((byte)(188)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateAct_TSM});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 21);
            this.toolStripMenuItem1.Text = "Акты";
            // 
            // CreateAct_TSM
            // 
            this.CreateAct_TSM.Name = "CreateAct_TSM";
            this.CreateAct_TSM.Size = new System.Drawing.Size(178, 22);
            this.CreateAct_TSM.Text = "Сформировать акт";
            this.CreateAct_TSM.Click += new System.EventHandler(this.CreateAct_TSM_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.22449F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.77551F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Scan_DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Status_TB, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ServerStatus_TB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Add_B, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Change_B, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 543);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(483, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 35);
            this.label2.TabIndex = 21;
            this.label2.Text = "Управление";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(472, 35);
            this.label4.TabIndex = 18;
            this.label4.Text = "Позиции";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Scan_DGV
            // 
            this.Scan_DGV.AllowUserToAddRows = false;
            this.Scan_DGV.AllowUserToDeleteRows = false;
            this.Scan_DGV.AllowUserToResizeColumns = false;
            this.Scan_DGV.AllowUserToResizeRows = false;
            this.Scan_DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Scan_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Scan_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataMatrixOrder,
            this.Unique});
            this.Scan_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scan_DGV.Location = new System.Drawing.Point(5, 55);
            this.Scan_DGV.Margin = new System.Windows.Forms.Padding(5, 0, 3, 5);
            this.Scan_DGV.Name = "Scan_DGV";
            this.Scan_DGV.ReadOnly = true;
            this.Scan_DGV.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.Scan_DGV, 7);
            this.Scan_DGV.Size = new System.Drawing.Size(472, 482);
            this.Scan_DGV.TabIndex = 10;
            this.Scan_DGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Scan_DGV_CellFormatting);
            this.Scan_DGV.SelectionChanged += new System.EventHandler(this.Scan_DGV_SelectionChanged);
            // 
            // DataMatrixOrder
            // 
            this.DataMatrixOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataMatrixOrder.DataPropertyName = "DataMatrix";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataMatrixOrder.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataMatrixOrder.FillWeight = 75F;
            this.DataMatrixOrder.HeaderText = "Данные чертежа";
            this.DataMatrixOrder.Name = "DataMatrixOrder";
            this.DataMatrixOrder.ReadOnly = true;
            // 
            // Unique
            // 
            this.Unique.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Unique.DataPropertyName = "Unique";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unique.DefaultCellStyle = dataGridViewCellStyle4;
            this.Unique.FillWeight = 25F;
            this.Unique.HeaderText = "Найдено";
            this.Unique.Name = "Unique";
            this.Unique.ReadOnly = true;
            this.Unique.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Status_TB
            // 
            this.Status_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Status_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Status_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Status_TB.Location = new System.Drawing.Point(483, 260);
            this.Status_TB.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(296, 237);
            this.Status_TB.TabIndex = 13;
            this.Status_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(483, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 35);
            this.label5.TabIndex = 20;
            this.label5.Text = "Статус операции";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerStatus_TB
            // 
            this.ServerStatus_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ServerStatus_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerStatus_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerStatus_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerStatus_TB.Location = new System.Drawing.Point(483, 185);
            this.ServerStatus_TB.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.ServerStatus_TB.Name = "ServerStatus_TB";
            this.ServerStatus_TB.ReadOnly = true;
            this.ServerStatus_TB.Size = new System.Drawing.Size(296, 20);
            this.ServerStatus_TB.TabIndex = 12;
            this.ServerStatus_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(483, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 35);
            this.label1.TabIndex = 22;
            this.label1.Text = "Статус работы программы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Cancel_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Cancel_B.Location = new System.Drawing.Point(485, 507);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(294, 30);
            this.Cancel_B.TabIndex = 15;
            this.Cancel_B.Text = "Отменить";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // Add_B
            // 
            this.Add_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Add_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Add_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Add_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Add_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Add_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Add_B.Location = new System.Drawing.Point(483, 95);
            this.Add_B.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(296, 30);
            this.Add_B.TabIndex = 19;
            this.Add_B.Text = "Добавить";
            this.Add_B.UseVisualStyleBackColor = false;
            // 
            // Change_B
            // 
            this.Change_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Change_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Change_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Change_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Change_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Change_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Change_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Change_B.Location = new System.Drawing.Point(483, 55);
            this.Change_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Change_B.Name = "Change_B";
            this.Change_B.Size = new System.Drawing.Size(296, 30);
            this.Change_B.TabIndex = 23;
            this.Change_B.Text = "Выбрать чертежи";
            this.Change_B.UseVisualStyleBackColor = false;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // AR_Decode_F
            // 
            this.AcceptButton = this.Add_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(784, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AR_Decode_F";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распознование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ARDecode_F_FormClosing);
            this.Load += new System.EventHandler(this.ARDecode_F_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CreateAct_TSM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox Status_TB;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox ServerStatus_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Scan_DGV;
        private System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Button Add_B;
        private System.Windows.Forms.Button Change_B;
        private System.Windows.Forms.OpenFileDialog TIFF_OFD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataMatrixOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unique;
    }
}