namespace SZMK.Desktop.Views.KB
{
    partial class KB_Scan_F
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateAct_TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.Scan_DGV = new System.Windows.Forms.DataGridView();
            this.DataMatrixOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unique = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerStatus_TB = new System.Windows.Forms.TextBox();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.Position_L = new System.Windows.Forms.Label();
            this.Main_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.Status_TB = new System.Windows.Forms.TextBox();
            this.Web_L = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Add_B = new System.Windows.Forms.Button();
            this.SessionCount_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewWeb_PB = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_DGV)).BeginInit();
            this.Main_TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewWeb_PB)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 0;
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
            this.CreateAct_TSM.Size = new System.Drawing.Size(180, 22);
            this.CreateAct_TSM.Text = "Сформировать акт";
            this.CreateAct_TSM.Click += new System.EventHandler(this.CreateAct_TSM_Click);
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
            this.Unique,
            this.Discription});
            this.Scan_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scan_DGV.Location = new System.Drawing.Point(5, 50);
            this.Scan_DGV.Margin = new System.Windows.Forms.Padding(5);
            this.Scan_DGV.Name = "Scan_DGV";
            this.Scan_DGV.ReadOnly = true;
            this.Scan_DGV.RowHeadersVisible = false;
            this.Main_TLP.SetRowSpan(this.Scan_DGV, 11);
            this.Scan_DGV.Size = new System.Drawing.Size(753, 790);
            this.Scan_DGV.TabIndex = 10;
            this.Scan_DGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Scan_DGV_CellFormatting);
            this.Scan_DGV.SelectionChanged += new System.EventHandler(this.Scan_DGV_SelectionChanged);
            // 
            // DataMatrixOrder
            // 
            this.DataMatrixOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataMatrixOrder.DataPropertyName = "DataMatrix";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataMatrixOrder.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataMatrixOrder.FillWeight = 65F;
            this.DataMatrixOrder.HeaderText = "Данные чертежа";
            this.DataMatrixOrder.Name = "DataMatrixOrder";
            this.DataMatrixOrder.ReadOnly = true;
            // 
            // Unique
            // 
            this.Unique.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Unique.DataPropertyName = "Unique";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unique.DefaultCellStyle = dataGridViewCellStyle2;
            this.Unique.FillWeight = 40F;
            this.Unique.HeaderText = "Уникальность";
            this.Unique.Name = "Unique";
            this.Unique.ReadOnly = true;
            this.Unique.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Discription
            // 
            this.Discription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Discription.DefaultCellStyle = dataGridViewCellStyle3;
            this.Discription.FillWeight = 75F;
            this.Discription.HeaderText = "Описание";
            this.Discription.Name = "Discription";
            this.Discription.ReadOnly = true;
            // 
            // ServerStatus_TB
            // 
            this.ServerStatus_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ServerStatus_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerStatus_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerStatus_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerStatus_TB.Location = new System.Drawing.Point(768, 390);
            this.ServerStatus_TB.Margin = new System.Windows.Forms.Padding(5);
            this.ServerStatus_TB.Name = "ServerStatus_TB";
            this.ServerStatus_TB.ReadOnly = true;
            this.ServerStatus_TB.Size = new System.Drawing.Size(411, 20);
            this.ServerStatus_TB.TabIndex = 12;
            this.ServerStatus_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.Cancel_B.Location = new System.Drawing.Point(768, 810);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(411, 30);
            this.Cancel_B.TabIndex = 15;
            this.Cancel_B.Text = "Отменить";
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // Position_L
            // 
            this.Position_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.Position_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Position_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Position_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Position_L.Location = new System.Drawing.Point(5, 5);
            this.Position_L.Margin = new System.Windows.Forms.Padding(5);
            this.Position_L.Name = "Position_L";
            this.Position_L.Size = new System.Drawing.Size(753, 35);
            this.Position_L.TabIndex = 18;
            this.Position_L.Text = "Позиции";
            this.Position_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main_TLP
            // 
            this.Main_TLP.ColumnCount = 2;
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.51613F));
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.48387F));
            this.Main_TLP.Controls.Add(this.Status_TB, 1, 9);
            this.Main_TLP.Controls.Add(this.Web_L, 1, 0);
            this.Main_TLP.Controls.Add(this.label2, 1, 2);
            this.Main_TLP.Controls.Add(this.Position_L, 0, 0);
            this.Main_TLP.Controls.Add(this.ServerStatus_TB, 1, 5);
            this.Main_TLP.Controls.Add(this.label1, 1, 4);
            this.Main_TLP.Controls.Add(this.Scan_DGV, 0, 1);
            this.Main_TLP.Controls.Add(this.Add_B, 1, 3);
            this.Main_TLP.Controls.Add(this.SessionCount_TB, 1, 7);
            this.Main_TLP.Controls.Add(this.label3, 1, 6);
            this.Main_TLP.Controls.Add(this.ViewWeb_PB, 1, 1);
            this.Main_TLP.Controls.Add(this.label5, 1, 8);
            this.Main_TLP.Controls.Add(this.Cancel_B, 1, 10);
            this.Main_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TLP.Location = new System.Drawing.Point(0, 25);
            this.Main_TLP.Name = "Main_TLP";
            this.Main_TLP.RowCount = 12;
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.Main_TLP.Size = new System.Drawing.Size(1184, 845);
            this.Main_TLP.TabIndex = 3;
            // 
            // Status_TB
            // 
            this.Status_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Status_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Status_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Status_TB.Location = new System.Drawing.Point(768, 540);
            this.Status_TB.Margin = new System.Windows.Forms.Padding(5);
            this.Status_TB.Multiline = true;
            this.Status_TB.Name = "Status_TB";
            this.Status_TB.ReadOnly = true;
            this.Status_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TB.Size = new System.Drawing.Size(411, 260);
            this.Status_TB.TabIndex = 27;
            this.Status_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Web_L
            // 
            this.Web_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.Web_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Web_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Web_L.Location = new System.Drawing.Point(768, 5);
            this.Web_L.Margin = new System.Windows.Forms.Padding(5);
            this.Web_L.Name = "Web_L";
            this.Web_L.Size = new System.Drawing.Size(411, 35);
            this.Web_L.TabIndex = 25;
            this.Web_L.Text = "Вебкамера";
            this.Web_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(768, 260);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 35);
            this.label2.TabIndex = 21;
            this.label2.Text = "Управление";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(768, 345);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 35);
            this.label1.TabIndex = 22;
            this.label1.Text = "Статус сервера";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Add_B.Location = new System.Drawing.Point(768, 305);
            this.Add_B.Margin = new System.Windows.Forms.Padding(5);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(411, 30);
            this.Add_B.TabIndex = 19;
            this.Add_B.Text = "Добавить";
            this.Add_B.UseVisualStyleBackColor = false;
            // 
            // SessionCount_TB
            // 
            this.SessionCount_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.SessionCount_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SessionCount_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SessionCount_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SessionCount_TB.Location = new System.Drawing.Point(768, 465);
            this.SessionCount_TB.Margin = new System.Windows.Forms.Padding(5);
            this.SessionCount_TB.Name = "SessionCount_TB";
            this.SessionCount_TB.ReadOnly = true;
            this.SessionCount_TB.Size = new System.Drawing.Size(411, 20);
            this.SessionCount_TB.TabIndex = 24;
            this.SessionCount_TB.Text = "0";
            this.SessionCount_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(768, 420);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(411, 35);
            this.label3.TabIndex = 23;
            this.label3.Text = "Количество чертежей";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewWeb_PB
            // 
            this.ViewWeb_PB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewWeb_PB.Location = new System.Drawing.Point(768, 50);
            this.ViewWeb_PB.Margin = new System.Windows.Forms.Padding(5);
            this.ViewWeb_PB.Name = "ViewWeb_PB";
            this.ViewWeb_PB.Size = new System.Drawing.Size(411, 200);
            this.ViewWeb_PB.TabIndex = 26;
            this.ViewWeb_PB.TabStop = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(768, 495);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(411, 35);
            this.label5.TabIndex = 20;
            this.label5.Text = "Статус операции";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KB_Scan_F
            // 
            this.AcceptButton = this.Add_B;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.Cancel_B;
            this.ClientSize = new System.Drawing.Size(1184, 870);
            this.Controls.Add(this.Main_TLP);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 866);
            this.Name = "KB_Scan_F";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сканирование чертежей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KBScan_F_FormClosing);
            this.Load += new System.EventHandler(this.Scan_F_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_DGV)).EndInit();
            this.Main_TLP.ResumeLayout(false);
            this.Main_TLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewWeb_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CreateAct_TSM;
        private System.Windows.Forms.Button Cancel_B;
        public System.Windows.Forms.TextBox ServerStatus_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Add_B;
        public System.Windows.Forms.TextBox SessionCount_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label Web_L;
        public System.Windows.Forms.PictureBox ViewWeb_PB;
        public System.Windows.Forms.DataGridView Scan_DGV;
        public System.Windows.Forms.Label Position_L;
        public System.Windows.Forms.TableLayoutPanel Main_TLP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataMatrixOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unique;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discription;
        public System.Windows.Forms.TextBox Status_TB;
    }
}