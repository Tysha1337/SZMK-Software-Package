namespace SZMK.Desktop.Views.Arhive
{
    partial class AR_RenameOrder_F
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.Save_B = new System.Windows.Forms.Button();
            this.Change_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.41177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.58824F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Scan_DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Status_TB, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.ServerStatus_TB, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_B, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Save_B, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Change_B, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 578);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(702, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 35);
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
            this.label4.Size = new System.Drawing.Size(691, 35);
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
            this.Scan_DGV.Size = new System.Drawing.Size(691, 518);
            this.Scan_DGV.TabIndex = 10;
            this.Scan_DGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Scan_DGV_CellFormatting);
            this.Scan_DGV.SelectionChanged += new System.EventHandler(this.Scan_DGV_SelectionChanged);
            // 
            // DataMatrixOrder
            // 
            this.DataMatrixOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataMatrixOrder.DataPropertyName = "DataMatrix";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataMatrixOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataMatrixOrder.FillWeight = 50F;
            this.DataMatrixOrder.HeaderText = "Данные чертежа";
            this.DataMatrixOrder.Name = "DataMatrixOrder";
            this.DataMatrixOrder.ReadOnly = true;
            // 
            // Unique
            // 
            this.Unique.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unique.DefaultCellStyle = dataGridViewCellStyle6;
            this.Unique.FillWeight = 50F;
            this.Unique.HeaderText = "Название файла";
            this.Unique.Name = "Unique";
            this.Unique.ReadOnly = true;
            this.Unique.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Status_TB
            // 
            this.Status_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Status_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Status_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Status_TB.Location = new System.Drawing.Point(702, 285);
            this.Status_TB.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(301, 288);
            this.Status_TB.TabIndex = 13;
            this.Status_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(702, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 35);
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
            this.ServerStatus_TB.Location = new System.Drawing.Point(702, 210);
            this.ServerStatus_TB.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.ServerStatus_TB.Name = "ServerStatus_TB";
            this.ServerStatus_TB.ReadOnly = true;
            this.ServerStatus_TB.Size = new System.Drawing.Size(301, 20);
            this.ServerStatus_TB.TabIndex = 12;
            this.ServerStatus_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(702, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 35);
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
            this.Cancel_B.Location = new System.Drawing.Point(702, 125);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(301, 30);
            this.Cancel_B.TabIndex = 15;
            this.Cancel_B.Text = "Отменить";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // Save_B
            // 
            this.Save_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Save_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Save_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Save_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Save_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Save_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Save_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Save_B.Location = new System.Drawing.Point(702, 90);
            this.Save_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Save_B.Name = "Save_B";
            this.Save_B.Size = new System.Drawing.Size(301, 30);
            this.Save_B.TabIndex = 19;
            this.Save_B.Text = "Переименовать";
            this.Save_B.UseVisualStyleBackColor = false;
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
            this.Change_B.Location = new System.Drawing.Point(702, 55);
            this.Change_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Change_B.Name = "Change_B";
            this.Change_B.Size = new System.Drawing.Size(301, 30);
            this.Change_B.TabIndex = 23;
            this.Change_B.Text = "Выбрать чертежи";
            this.Change_B.UseVisualStyleBackColor = false;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // ARRenameOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 578);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 617);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 617);
            this.Name = "ARRenameOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Переименование чертежей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ARRenameOrder_FormClosing);
            this.Load += new System.EventHandler(this.ARRenameOrder_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView Scan_DGV;
        public System.Windows.Forms.TextBox Status_TB;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox ServerStatus_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Button Save_B;
        private System.Windows.Forms.Button Change_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataMatrixOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unique;
    }
}