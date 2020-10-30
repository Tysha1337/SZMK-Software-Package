namespace SZMK.ServerUpdater.Views
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Main_MS = new System.Windows.Forms.MenuStrip();
            this.основныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Products_TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Versions_DGV = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_CB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusServer_TB = new System.Windows.Forms.TextBox();
            this.StartServer_B = new System.Windows.Forms.Button();
            this.Change_B = new System.Windows.Forms.Button();
            this.Delete_B = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Add_B = new System.Windows.Forms.Button();
            this.StopServer_B = new System.Windows.Forms.Button();
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Open_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckerStatus_T = new System.Windows.Forms.Timer(this.components);
            this.AddAutoRun_TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_MS.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Versions_DGV)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_MS
            // 
            this.Main_MS.BackColor = System.Drawing.Color.FloralWhite;
            this.Main_MS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Main_MS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.основныеToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.Main_MS.Location = new System.Drawing.Point(0, 0);
            this.Main_MS.Name = "Main_MS";
            this.Main_MS.Size = new System.Drawing.Size(363, 24);
            this.Main_MS.TabIndex = 0;
            this.Main_MS.Text = "menuStrip1";
            // 
            // основныеToolStripMenuItem
            // 
            this.основныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Products_TSM,
            this.Server_TSM,
            this.AddAutoRun_TSM});
            this.основныеToolStripMenuItem.Name = "основныеToolStripMenuItem";
            this.основныеToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.основныеToolStripMenuItem.Text = "Основные";
            // 
            // Products_TSM
            // 
            this.Products_TSM.Name = "Products_TSM";
            this.Products_TSM.Size = new System.Drawing.Size(245, 22);
            this.Products_TSM.Text = "Продукты";
            this.Products_TSM.Click += new System.EventHandler(this.Products_TSM_Click);
            // 
            // Server_TSM
            // 
            this.Server_TSM.Name = "Server_TSM";
            this.Server_TSM.Size = new System.Drawing.Size(245, 22);
            this.Server_TSM.Text = "Сервер";
            this.Server_TSM.Click += new System.EventHandler(this.Server_TSM_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FloralWhite;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.79339F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.20661F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Versions_DGV, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Product_CB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.StatusServer_TB, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.StartServer_B, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.Change_B, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Delete_B, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.Add_B, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.StopServer_B, 2, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(363, 584);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Tan;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 35);
            this.label2.TabIndex = 6;
            this.label2.Text = "Список версий";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Versions_DGV
            // 
            this.Versions_DGV.AllowUserToAddRows = false;
            this.Versions_DGV.AllowUserToDeleteRows = false;
            this.Versions_DGV.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Versions_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Versions_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Versions_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version});
            this.tableLayoutPanel1.SetColumnSpan(this.Versions_DGV, 3);
            this.Versions_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Versions_DGV.Location = new System.Drawing.Point(5, 129);
            this.Versions_DGV.Margin = new System.Windows.Forms.Padding(5);
            this.Versions_DGV.Name = "Versions_DGV";
            this.Versions_DGV.ReadOnly = true;
            this.Versions_DGV.RowHeadersVisible = false;
            this.Versions_DGV.Size = new System.Drawing.Size(353, 213);
            this.Versions_DGV.TabIndex = 1;
            // 
            // Version
            // 
            this.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Version.DefaultCellStyle = dataGridViewCellStyle2;
            this.Version.HeaderText = "Версия";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // Product_CB
            // 
            this.Product_CB.BackColor = System.Drawing.Color.PeachPuff;
            this.tableLayoutPanel1.SetColumnSpan(this.Product_CB, 3);
            this.Product_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Product_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Product_CB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Product_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Product_CB.ForeColor = System.Drawing.Color.Black;
            this.Product_CB.FormattingEnabled = true;
            this.Product_CB.Location = new System.Drawing.Point(5, 50);
            this.Product_CB.Margin = new System.Windows.Forms.Padding(5);
            this.Product_CB.Name = "Product_CB";
            this.Product_CB.Size = new System.Drawing.Size(353, 24);
            this.Product_CB.TabIndex = 5;
            this.Product_CB.SelectedIndexChanged += new System.EventHandler(this.Product_CB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбор продукта";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(5, 557);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Статус сервера:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusServer_TB
            // 
            this.StatusServer_TB.BackColor = System.Drawing.Color.AntiqueWhite;
            this.StatusServer_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.StatusServer_TB, 2);
            this.StatusServer_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusServer_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.StatusServer_TB.Location = new System.Drawing.Point(130, 557);
            this.StatusServer_TB.Margin = new System.Windows.Forms.Padding(5);
            this.StatusServer_TB.Name = "StatusServer_TB";
            this.StatusServer_TB.ReadOnly = true;
            this.StatusServer_TB.Size = new System.Drawing.Size(228, 22);
            this.StatusServer_TB.TabIndex = 10;
            this.StatusServer_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartServer_B
            // 
            this.StartServer_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.SetColumnSpan(this.StartServer_B, 2);
            this.StartServer_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartServer_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartServer_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.StartServer_B.Location = new System.Drawing.Point(5, 517);
            this.StartServer_B.Margin = new System.Windows.Forms.Padding(5);
            this.StartServer_B.Name = "StartServer_B";
            this.StartServer_B.Size = new System.Drawing.Size(174, 30);
            this.StartServer_B.TabIndex = 7;
            this.StartServer_B.Text = "Запуск";
            this.StartServer_B.UseVisualStyleBackColor = false;
            this.StartServer_B.Click += new System.EventHandler(this.StartServer_B_Click);
            // 
            // Change_B
            // 
            this.Change_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.SetColumnSpan(this.Change_B, 3);
            this.Change_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Change_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Change_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Change_B.Location = new System.Drawing.Point(5, 392);
            this.Change_B.Margin = new System.Windows.Forms.Padding(5);
            this.Change_B.Name = "Change_B";
            this.Change_B.Size = new System.Drawing.Size(353, 30);
            this.Change_B.TabIndex = 3;
            this.Change_B.Text = "Изменить";
            this.Change_B.UseVisualStyleBackColor = false;
            this.Change_B.Click += new System.EventHandler(this.Change_B_Click);
            // 
            // Delete_B
            // 
            this.Delete_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.SetColumnSpan(this.Delete_B, 3);
            this.Delete_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Delete_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete_B.Location = new System.Drawing.Point(5, 432);
            this.Delete_B.Margin = new System.Windows.Forms.Padding(5);
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.Size = new System.Drawing.Size(353, 30);
            this.Delete_B.TabIndex = 4;
            this.Delete_B.Text = "Удалить";
            this.Delete_B.UseVisualStyleBackColor = false;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 3);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 472);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 35);
            this.label4.TabIndex = 11;
            this.label4.Text = "Сервер";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add_B
            // 
            this.Add_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.SetColumnSpan(this.Add_B, 3);
            this.Add_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_B.Location = new System.Drawing.Point(5, 352);
            this.Add_B.Margin = new System.Windows.Forms.Padding(5);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(353, 30);
            this.Add_B.TabIndex = 2;
            this.Add_B.Text = "Добавить";
            this.Add_B.UseVisualStyleBackColor = false;
            this.Add_B.Click += new System.EventHandler(this.Add_B_Click);
            // 
            // StopServer_B
            // 
            this.StopServer_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.StopServer_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopServer_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopServer_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.StopServer_B.Location = new System.Drawing.Point(189, 517);
            this.StopServer_B.Margin = new System.Windows.Forms.Padding(5);
            this.StopServer_B.Name = "StopServer_B";
            this.StopServer_B.Size = new System.Drawing.Size(169, 30);
            this.StopServer_B.TabIndex = 8;
            this.StopServer_B.Text = "Остановка";
            this.StopServer_B.UseVisualStyleBackColor = false;
            this.StopServer_B.Click += new System.EventHandler(this.StopServer_B_Click);
            // 
            // Tray
            // 
            this.Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tray.BalloonTipText = "Нажмите правой кнопкой мыши для выбора действия";
            this.Tray.BalloonTipTitle = "Подсказка";
            this.Tray.ContextMenuStrip = this.contextMenuStrip1;
            this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
            this.Tray.Text = "SZMK.ServerUpdater";
            this.Tray.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FloralWhite;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_TSMI,
            this.Exit_TSMI});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 48);
            // 
            // Open_TSMI
            // 
            this.Open_TSMI.Name = "Open_TSMI";
            this.Open_TSMI.Size = new System.Drawing.Size(96, 22);
            this.Open_TSMI.Text = "Открыть";
            this.Open_TSMI.Click += new System.EventHandler(this.Open_TSMI_Click);
            // 
            // Exit_TSMI
            // 
            this.Exit_TSMI.Name = "Exit_TSMI";
            this.Exit_TSMI.Size = new System.Drawing.Size(96, 22);
            this.Exit_TSMI.Text = "Выход";
            this.Exit_TSMI.Click += new System.EventHandler(this.Exit_TSMI_Click);
            // 
            // CheckerStatus_T
            // 
            this.CheckerStatus_T.Interval = 1000;
            this.CheckerStatus_T.Tick += new System.EventHandler(this.CheckerStatus_T_Tick);
            // 
            // AddAutoRun_TSM
            // 
            this.AddAutoRun_TSM.Name = "AddAutoRun_TSM";
            this.AddAutoRun_TSM.Size = new System.Drawing.Size(245, 22);
            this.AddAutoRun_TSM.Text = "Добавить в автозагрузку";
            this.AddAutoRun_TSM.Click += new System.EventHandler(this.AddAutoRun_TSM_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(363, 608);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Main_MS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Main_MS;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 647);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 647);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервер обновлений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Main_MS.ResumeLayout(false);
            this.Main_MS.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Versions_DGV)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Main_MS;
        private System.Windows.Forms.ToolStripMenuItem основныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Versions_DGV;
        private System.Windows.Forms.Button Add_B;
        private System.Windows.Forms.Button Change_B;
        private System.Windows.Forms.Button Delete_B;
        private System.Windows.Forms.ToolStripMenuItem Server_TSM;
        private System.Windows.Forms.ComboBox Product_CB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem Products_TSM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Open_TSMI;
        private System.Windows.Forms.ToolStripMenuItem Exit_TSMI;
        private System.Windows.Forms.Button StartServer_B;
        private System.Windows.Forms.Button StopServer_B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StatusServer_TB;
        private System.Windows.Forms.Timer CheckerStatus_T;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem AddAutoRun_TSM;
    }
}

