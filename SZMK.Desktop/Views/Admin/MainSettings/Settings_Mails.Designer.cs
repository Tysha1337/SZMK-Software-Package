namespace SZMK.Desktop.Views.Admin.MainSettings
{
    partial class Settings_Mails
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
            this.Mails_DGV = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.Add_B = new System.Windows.Forms.Button();
            this.Change_B = new System.Windows.Forms.Button();
            this.Delete_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Search_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Search_B = new System.Windows.Forms.Button();
            this.ResetSearch_B = new System.Windows.Forms.Button();
            this.MoreInfo_B = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Server_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Refresh_B = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.GeneralConstrucor_B = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Mails_DGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mails_DGV
            // 
            this.Mails_DGV.AllowUserToAddRows = false;
            this.Mails_DGV.AllowUserToDeleteRows = false;
            this.Mails_DGV.AllowUserToResizeColumns = false;
            this.Mails_DGV.AllowUserToResizeRows = false;
            this.Mails_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Mails_DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Mails_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mails_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1});
            this.Mails_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mails_DGV.Location = new System.Drawing.Point(5, 60);
            this.Mails_DGV.Margin = new System.Windows.Forms.Padding(5, 5, 3, 5);
            this.Mails_DGV.MultiSelect = false;
            this.Mails_DGV.Name = "Mails_DGV";
            this.Mails_DGV.ReadOnly = true;
            this.Mails_DGV.RowHeadersVisible = false;
            this.Mails_DGV.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.Mails_DGV, 15);
            this.Mails_DGV.Size = new System.Drawing.Size(413, 567);
            this.Mails_DGV.TabIndex = 19;
            this.Mails_DGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Mails_DGV_CellFormatting);
            this.Mails_DGV.SelectionChanged += new System.EventHandler(this.Mails_DGV_SelectionChanged);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DateCreateView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Дата создания";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "MailAddress";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.HeaderText = "Адрес электронной почты";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(411, 35);
            this.label4.TabIndex = 83;
            this.label4.Text = "Список почтовых адресов";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add_B
            // 
            this.Add_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Add_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Add_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Add_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Add_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_B.Location = new System.Drawing.Point(424, 60);
            this.Add_B.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(173, 30);
            this.Add_B.TabIndex = 84;
            this.Add_B.Text = "Добавить";
            this.Add_B.UseVisualStyleBackColor = false;
            this.Add_B.Click += new System.EventHandler(this.Add_B_Click);
            // 
            // Change_B
            // 
            this.Change_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Change_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Change_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Change_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Change_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Change_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Change_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Change_B.Location = new System.Drawing.Point(424, 95);
            this.Change_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Change_B.Name = "Change_B";
            this.Change_B.Size = new System.Drawing.Size(173, 30);
            this.Change_B.TabIndex = 85;
            this.Change_B.Text = "Изменить";
            this.Change_B.UseVisualStyleBackColor = false;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // Delete_B
            // 
            this.Delete_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Delete_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Delete_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Delete_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Delete_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Delete_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete_B.Location = new System.Drawing.Point(424, 130);
            this.Delete_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.Size = new System.Drawing.Size(173, 30);
            this.Delete_B.TabIndex = 86;
            this.Delete_B.Text = "Удалить";
            this.Delete_B.UseVisualStyleBackColor = false;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(424, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 35);
            this.label1.TabIndex = 87;
            this.label1.Text = "Операции";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Search_TB
            // 
            this.Search_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Search_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Search_TB.Location = new System.Drawing.Point(426, 255);
            this.Search_TB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Search_TB.Name = "Search_TB";
            this.Search_TB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Search_TB.Size = new System.Drawing.Size(171, 20);
            this.Search_TB.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(424, 210);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 35);
            this.label2.TabIndex = 90;
            this.label2.Text = "Поиск";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Search_B
            // 
            this.Search_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Search_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Search_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Search_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Search_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Search_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search_B.Location = new System.Drawing.Point(424, 280);
            this.Search_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Search_B.Name = "Search_B";
            this.Search_B.Size = new System.Drawing.Size(173, 30);
            this.Search_B.TabIndex = 91;
            this.Search_B.Text = "Поиск";
            this.Search_B.UseVisualStyleBackColor = false;
            this.Search_B.Click += new System.EventHandler(this.Search_B_Click);
            // 
            // ResetSearch_B
            // 
            this.ResetSearch_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ResetSearch_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetSearch_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.ResetSearch_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.ResetSearch_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.ResetSearch_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetSearch_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetSearch_B.Location = new System.Drawing.Point(424, 315);
            this.ResetSearch_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.ResetSearch_B.Name = "ResetSearch_B";
            this.ResetSearch_B.Size = new System.Drawing.Size(173, 30);
            this.ResetSearch_B.TabIndex = 92;
            this.ResetSearch_B.Text = "Сбросить";
            this.ResetSearch_B.UseVisualStyleBackColor = false;
            this.ResetSearch_B.Click += new System.EventHandler(this.ResetSearch_B_Click);
            // 
            // MoreInfo_B
            // 
            this.MoreInfo_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.MoreInfo_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoreInfo_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.MoreInfo_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.MoreInfo_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.MoreInfo_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoreInfo_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoreInfo_B.Location = new System.Drawing.Point(424, 165);
            this.MoreInfo_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.MoreInfo_B.Name = "MoreInfo_B";
            this.MoreInfo_B.Size = new System.Drawing.Size(173, 30);
            this.MoreInfo_B.TabIndex = 94;
            this.MoreInfo_B.Text = "Подробнее";
            this.MoreInfo_B.UseVisualStyleBackColor = false;
            this.MoreInfo_B.Click += new System.EventHandler(this.MoreInfo_B_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(424, 360);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 35);
            this.label3.TabIndex = 96;
            this.label3.Text = "Почтовый сервер";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Server_B
            // 
            this.Server_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Server_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Server_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Server_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Server_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Server_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Server_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Server_B.Location = new System.Drawing.Point(424, 405);
            this.Server_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Server_B.Name = "Server_B";
            this.Server_B.Size = new System.Drawing.Size(173, 30);
            this.Server_B.TabIndex = 95;
            this.Server_B.Text = "Настройки";
            this.Server_B.UseVisualStyleBackColor = false;
            this.Server_B.Click += new System.EventHandler(this.Server_B_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Mails_DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Server_B, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.Add_B, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Change_B, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ResetSearch_B, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.MoreInfo_B, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Search_B, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.Delete_B, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Search_TB, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Refresh_B, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.GeneralConstrucor_B, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 15);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(602, 632);
            this.tableLayoutPanel1.TabIndex = 97;
            // 
            // Refresh_B
            // 
            this.Refresh_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Refresh_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Refresh_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.Refresh_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.Refresh_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.Refresh_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refresh_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Refresh_B.Location = new System.Drawing.Point(424, 440);
            this.Refresh_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.Refresh_B.Name = "Refresh_B";
            this.Refresh_B.Size = new System.Drawing.Size(173, 30);
            this.Refresh_B.TabIndex = 97;
            this.Refresh_B.Text = "Обновить";
            this.Refresh_B.UseVisualStyleBackColor = false;
            this.Refresh_B.Click += new System.EventHandler(this.Refresh_B_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(228)))), ((int)(((byte)(213)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(424, 485);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 5, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 35);
            this.label5.TabIndex = 99;
            this.label5.Text = "Главный конструктор";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GeneralConstrucor_B
            // 
            this.GeneralConstrucor_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.GeneralConstrucor_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralConstrucor_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.GeneralConstrucor_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.GeneralConstrucor_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.GeneralConstrucor_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GeneralConstrucor_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeneralConstrucor_B.Location = new System.Drawing.Point(424, 530);
            this.GeneralConstrucor_B.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.GeneralConstrucor_B.Name = "GeneralConstrucor_B";
            this.GeneralConstrucor_B.Size = new System.Drawing.Size(173, 30);
            this.GeneralConstrucor_B.TabIndex = 100;
            this.GeneralConstrucor_B.Text = "Email";
            this.GeneralConstrucor_B.UseVisualStyleBackColor = false;
            this.GeneralConstrucor_B.Click += new System.EventHandler(this.GeneralConstructor_B_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(424, 595);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 32);
            this.button1.TabIndex = 98;
            this.button1.Text = "Завершить редактирование";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Settings_Mails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 632);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings_Mails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ADSettingsMails_F_FormClosing);
            this.Load += new System.EventHandler(this.SettingsMails_F_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsMails_F_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Mails_DGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView Mails_DGV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Add_B;
        private System.Windows.Forms.Button Change_B;
        private System.Windows.Forms.Button Delete_B;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Search_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Search_B;
        private System.Windows.Forms.Button ResetSearch_B;
        private System.Windows.Forms.Button MoreInfo_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button Server_B;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Refresh_B;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button GeneralConstrucor_B;
        private System.Windows.Forms.Button button1;
    }
}