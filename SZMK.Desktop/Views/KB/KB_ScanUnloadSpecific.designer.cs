namespace SZMK.Desktop.Views.KB
{
    partial class KB_ScanUnloadSpecific
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Report_DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.OK_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Send_B = new System.Windows.Forms.Button();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Executor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberSpecific = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Report_DGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Report_DGV
            // 
            this.Report_DGV.AllowUserToAddRows = false;
            this.Report_DGV.AllowUserToDeleteRows = false;
            this.Report_DGV.AllowUserToResizeColumns = false;
            this.Report_DGV.AllowUserToResizeRows = false;
            this.Report_DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Report_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Report_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.List,
            this.Executor,
            this.NumberSpecific,
            this.Finded});
            this.Report_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report_DGV.Location = new System.Drawing.Point(5, 55);
            this.Report_DGV.Margin = new System.Windows.Forms.Padding(5, 0, 5, 1);
            this.Report_DGV.Name = "Report_DGV";
            this.Report_DGV.ReadOnly = true;
            this.Report_DGV.RowHeadersVisible = false;
            this.Report_DGV.Size = new System.Drawing.Size(815, 386);
            this.Report_DGV.TabIndex = 0;
            this.Report_DGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Report_DGV_CellFormatting);
            this.Report_DGV.SelectionChanged += new System.EventHandler(this.Report_DGV_SelectionChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(815, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отчет о проверке";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OK_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.OK_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.OK_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.OK_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.OK_B.Location = new System.Drawing.Point(5, 491);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(815, 33);
            this.OK_B.TabIndex = 2;
            this.OK_B.Text = "Закрыть";
            this.OK_B.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Report_DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OK_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Send_B, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 530);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Send_B
            // 
            this.Send_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Send_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Send_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Send_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Send_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Send_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Send_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Send_B.Location = new System.Drawing.Point(5, 451);
            this.Send_B.Margin = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.Send_B.Name = "Send_B";
            this.Send_B.Size = new System.Drawing.Size(815, 33);
            this.Send_B.TabIndex = 3;
            this.Send_B.Text = "Отправить сообщение";
            this.Send_B.UseVisualStyleBackColor = false;
            this.Send_B.Click += new System.EventHandler(this.Send_B_Click);
            // 
            // Number
            // 
            this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Number.DataPropertyName = "Number";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Number.DefaultCellStyle = dataGridViewCellStyle1;
            this.Number.FillWeight = 20F;
            this.Number.HeaderText = "Номер заказа";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // List
            // 
            this.List.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.List.DataPropertyName = "_Specific.List";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.List.DefaultCellStyle = dataGridViewCellStyle2;
            this.List.FillWeight = 15F;
            this.List.HeaderText = "Номер листа";
            this.List.Name = "List";
            this.List.ReadOnly = true;
            this.List.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Executor
            // 
            this.Executor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Executor.DataPropertyName = "Executor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Executor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Executor.FillWeight = 40F;
            this.Executor.HeaderText = "Исполнитель";
            this.Executor.Name = "Executor";
            this.Executor.ReadOnly = true;
            this.Executor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NumberSpecific
            // 
            this.NumberSpecific.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumberSpecific.DataPropertyName = "_Specific.NumberSpecific";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NumberSpecific.DefaultCellStyle = dataGridViewCellStyle4;
            this.NumberSpecific.FillWeight = 15F;
            this.NumberSpecific.HeaderText = "Номер детали";
            this.NumberSpecific.Name = "NumberSpecific";
            this.NumberSpecific.ReadOnly = true;
            this.NumberSpecific.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Finded
            // 
            this.Finded.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Finded.DataPropertyName = "_Specific.FindedView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Finded.DefaultCellStyle = dataGridViewCellStyle5;
            this.Finded.FillWeight = 10F;
            this.Finded.HeaderText = "Найдено";
            this.Finded.Name = "Finded";
            this.Finded.ReadOnly = true;
            this.Finded.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // KBScanUnloadSpecific
            // 
            this.AcceptButton = this.OK_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.OK_B;
            this.ClientSize = new System.Drawing.Size(825, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(841, 569);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(841, 569);
            this.Name = "KBScanUnloadSpecific";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет о проверке";
            this.Load += new System.EventHandler(this.KBScanUnloadSpecific_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report_DGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Report_DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK_B;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Send_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn List;
        private System.Windows.Forms.DataGridViewTextBoxColumn Executor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberSpecific;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finded;
    }
}