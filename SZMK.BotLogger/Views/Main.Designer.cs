namespace SZMK.BotLogger.Views
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Logs_Page = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Products_CB = new System.Windows.Forms.ComboBox();
            this.Logs_DGV = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settings_Page = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Products_Page = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.AddProduct_B = new System.Windows.Forms.Button();
            this.DeleteProduct_B = new System.Windows.Forms.Button();
            this.Products_DGV = new System.Windows.Forms.DataGridView();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bots_Page = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveBotSettings_B = new System.Windows.Forms.Button();
            this.TelegramToken_TB = new System.Windows.Forms.TextBox();
            this.TelegramHost_TB = new System.Windows.Forms.TextBox();
            this.TelegramPort_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Server_Page = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveServer_B = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.IPServer_TB = new System.Windows.Forms.TextBox();
            this.PortServer_TB = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.Logs_Page.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logs_DGV)).BeginInit();
            this.Settings_Page.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Products_Page.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Products_DGV)).BeginInit();
            this.Bots_Page.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.Server_Page.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Logs_Page);
            this.tabControl1.Controls.Add(this.Settings_Page);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(456, 522);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Logs_Page
            // 
            this.Logs_Page.Controls.Add(this.tableLayoutPanel1);
            this.Logs_Page.Location = new System.Drawing.Point(4, 22);
            this.Logs_Page.Margin = new System.Windows.Forms.Padding(0);
            this.Logs_Page.Name = "Logs_Page";
            this.Logs_Page.Size = new System.Drawing.Size(448, 496);
            this.Logs_Page.TabIndex = 0;
            this.Logs_Page.Text = "Логи";
            this.Logs_Page.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Products_CB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Logs_DGV, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 496);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LawnGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбор продукта";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LawnGreen;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(5, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Логи по датам";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Products_CB
            // 
            this.Products_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Products_CB.FormattingEnabled = true;
            this.Products_CB.Location = new System.Drawing.Point(3, 48);
            this.Products_CB.Name = "Products_CB";
            this.Products_CB.Size = new System.Drawing.Size(442, 21);
            this.Products_CB.TabIndex = 2;
            this.Products_CB.SelectedIndexChanged += new System.EventHandler(this.Products_CB_SelectedIndexChanged);
            // 
            // Logs_DGV
            // 
            this.Logs_DGV.AllowUserToAddRows = false;
            this.Logs_DGV.AllowUserToDeleteRows = false;
            this.Logs_DGV.AllowUserToResizeColumns = false;
            this.Logs_DGV.AllowUserToResizeRows = false;
            this.Logs_DGV.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Logs_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Logs_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Logs_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date});
            this.Logs_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logs_DGV.Location = new System.Drawing.Point(5, 122);
            this.Logs_DGV.Margin = new System.Windows.Forms.Padding(5);
            this.Logs_DGV.Name = "Logs_DGV";
            this.Logs_DGV.ReadOnly = true;
            this.Logs_DGV.RowHeadersVisible = false;
            this.Logs_DGV.Size = new System.Drawing.Size(438, 369);
            this.Logs_DGV.TabIndex = 3;
            this.Logs_DGV.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Logs_DGV_CellMouseDoubleClick);
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Settings_Page
            // 
            this.Settings_Page.Controls.Add(this.tabControl2);
            this.Settings_Page.Location = new System.Drawing.Point(4, 22);
            this.Settings_Page.Margin = new System.Windows.Forms.Padding(0);
            this.Settings_Page.Name = "Settings_Page";
            this.Settings_Page.Size = new System.Drawing.Size(448, 496);
            this.Settings_Page.TabIndex = 1;
            this.Settings_Page.Text = "Настройки";
            this.Settings_Page.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Products_Page);
            this.tabControl2.Controls.Add(this.Bots_Page);
            this.tabControl2.Controls.Add(this.Server_Page);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(448, 496);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // Products_Page
            // 
            this.Products_Page.Controls.Add(this.tableLayoutPanel2);
            this.Products_Page.Location = new System.Drawing.Point(4, 22);
            this.Products_Page.Margin = new System.Windows.Forms.Padding(0);
            this.Products_Page.Name = "Products_Page";
            this.Products_Page.Size = new System.Drawing.Size(440, 470);
            this.Products_Page.TabIndex = 0;
            this.Products_Page.Text = "Продукты";
            this.Products_Page.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddProduct_B, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.DeleteProduct_B, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Products_DGV, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(440, 470);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LawnGreen;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(430, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "Список продуктов";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddProduct_B
            // 
            this.AddProduct_B.BackColor = System.Drawing.Color.PaleGreen;
            this.AddProduct_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddProduct_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProduct_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddProduct_B.Location = new System.Drawing.Point(5, 395);
            this.AddProduct_B.Margin = new System.Windows.Forms.Padding(5);
            this.AddProduct_B.Name = "AddProduct_B";
            this.AddProduct_B.Size = new System.Drawing.Size(430, 30);
            this.AddProduct_B.TabIndex = 2;
            this.AddProduct_B.Text = "Добавить";
            this.AddProduct_B.UseVisualStyleBackColor = false;
            this.AddProduct_B.Click += new System.EventHandler(this.AddProduct_B_Click);
            // 
            // DeleteProduct_B
            // 
            this.DeleteProduct_B.BackColor = System.Drawing.Color.PaleGreen;
            this.DeleteProduct_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteProduct_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteProduct_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DeleteProduct_B.Location = new System.Drawing.Point(5, 435);
            this.DeleteProduct_B.Margin = new System.Windows.Forms.Padding(5);
            this.DeleteProduct_B.Name = "DeleteProduct_B";
            this.DeleteProduct_B.Size = new System.Drawing.Size(430, 30);
            this.DeleteProduct_B.TabIndex = 3;
            this.DeleteProduct_B.Text = "Удалить";
            this.DeleteProduct_B.UseVisualStyleBackColor = false;
            this.DeleteProduct_B.Click += new System.EventHandler(this.DeleteProduct_B_Click);
            // 
            // Products_DGV
            // 
            this.Products_DGV.AllowUserToAddRows = false;
            this.Products_DGV.AllowUserToDeleteRows = false;
            this.Products_DGV.AllowUserToResizeColumns = false;
            this.Products_DGV.AllowUserToResizeRows = false;
            this.Products_DGV.BackgroundColor = System.Drawing.Color.White;
            this.Products_DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Products_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Products_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Products_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameProduct});
            this.Products_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Products_DGV.Location = new System.Drawing.Point(5, 50);
            this.Products_DGV.Margin = new System.Windows.Forms.Padding(5);
            this.Products_DGV.Name = "Products_DGV";
            this.Products_DGV.ReadOnly = true;
            this.Products_DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Products_DGV.RowHeadersVisible = false;
            this.Products_DGV.Size = new System.Drawing.Size(430, 335);
            this.Products_DGV.TabIndex = 4;
            // 
            // NameProduct
            // 
            this.NameProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NameProduct.DefaultCellStyle = dataGridViewCellStyle4;
            this.NameProduct.HeaderText = "Наименование";
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.ReadOnly = true;
            this.NameProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Bots_Page
            // 
            this.Bots_Page.Controls.Add(this.tableLayoutPanel3);
            this.Bots_Page.Location = new System.Drawing.Point(4, 22);
            this.Bots_Page.Margin = new System.Windows.Forms.Padding(0);
            this.Bots_Page.Name = "Bots_Page";
            this.Bots_Page.Size = new System.Drawing.Size(440, 470);
            this.Bots_Page.TabIndex = 1;
            this.Bots_Page.Text = "Боты";
            this.Bots_Page.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.SaveBotSettings_B, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.TelegramToken_TB, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.TelegramHost_TB, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.TelegramPort_TB, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(440, 470);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LawnGreen;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(430, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "Telegram";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveBotSettings_B
            // 
            this.SaveBotSettings_B.BackColor = System.Drawing.Color.PaleGreen;
            this.tableLayoutPanel3.SetColumnSpan(this.SaveBotSettings_B, 2);
            this.SaveBotSettings_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBotSettings_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBotSettings_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.SaveBotSettings_B.Location = new System.Drawing.Point(5, 128);
            this.SaveBotSettings_B.Margin = new System.Windows.Forms.Padding(5);
            this.SaveBotSettings_B.Name = "SaveBotSettings_B";
            this.SaveBotSettings_B.Size = new System.Drawing.Size(430, 30);
            this.SaveBotSettings_B.TabIndex = 3;
            this.SaveBotSettings_B.Text = "Сохранить";
            this.SaveBotSettings_B.UseVisualStyleBackColor = false;
            this.SaveBotSettings_B.Click += new System.EventHandler(this.SaveBotSettings_B_Click);
            // 
            // TelegramToken_TB
            // 
            this.TelegramToken_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TelegramToken_TB.Location = new System.Drawing.Point(223, 48);
            this.TelegramToken_TB.Name = "TelegramToken_TB";
            this.TelegramToken_TB.Size = new System.Drawing.Size(214, 20);
            this.TelegramToken_TB.TabIndex = 4;
            // 
            // TelegramHost_TB
            // 
            this.TelegramHost_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TelegramHost_TB.Location = new System.Drawing.Point(223, 74);
            this.TelegramHost_TB.Name = "TelegramHost_TB";
            this.TelegramHost_TB.Size = new System.Drawing.Size(214, 20);
            this.TelegramHost_TB.TabIndex = 5;
            // 
            // TelegramPort_TB
            // 
            this.TelegramPort_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TelegramPort_TB.Location = new System.Drawing.Point(223, 100);
            this.TelegramPort_TB.Name = "TelegramPort_TB";
            this.TelegramPort_TB.Size = new System.Drawing.Size(214, 20);
            this.TelegramPort_TB.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Token";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Host Proxy";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Port Proxy";
            // 
            // Server_Page
            // 
            this.Server_Page.Controls.Add(this.tableLayoutPanel4);
            this.Server_Page.Location = new System.Drawing.Point(4, 22);
            this.Server_Page.Margin = new System.Windows.Forms.Padding(0);
            this.Server_Page.Name = "Server_Page";
            this.Server_Page.Size = new System.Drawing.Size(440, 470);
            this.Server_Page.TabIndex = 2;
            this.Server_Page.Text = "Сервер";
            this.Server_Page.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.SaveServer_B, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.IPServer_TB, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.PortServer_TB, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(440, 470);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // SaveServer_B
            // 
            this.SaveServer_B.BackColor = System.Drawing.Color.PaleGreen;
            this.tableLayoutPanel4.SetColumnSpan(this.SaveServer_B, 2);
            this.SaveServer_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveServer_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveServer_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.SaveServer_B.Location = new System.Drawing.Point(5, 102);
            this.SaveServer_B.Margin = new System.Windows.Forms.Padding(5);
            this.SaveServer_B.Name = "SaveServer_B";
            this.SaveServer_B.Size = new System.Drawing.Size(430, 30);
            this.SaveServer_B.TabIndex = 6;
            this.SaveServer_B.Text = "Сохранить";
            this.SaveServer_B.UseVisualStyleBackColor = false;
            this.SaveServer_B.Click += new System.EventHandler(this.SaveServer_B_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LawnGreen;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(430, 35);
            this.label8.TabIndex = 3;
            this.label8.Text = "Параметры сервера";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "IP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Порт";
            // 
            // IPServer_TB
            // 
            this.IPServer_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPServer_TB.Location = new System.Drawing.Point(223, 48);
            this.IPServer_TB.Name = "IPServer_TB";
            this.IPServer_TB.ReadOnly = true;
            this.IPServer_TB.Size = new System.Drawing.Size(214, 20);
            this.IPServer_TB.TabIndex = 7;
            // 
            // PortServer_TB
            // 
            this.PortServer_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortServer_TB.Location = new System.Drawing.Point(223, 74);
            this.PortServer_TB.Name = "PortServer_TB";
            this.PortServer_TB.Size = new System.Drawing.Size(214, 20);
            this.PortServer_TB.TabIndex = 8;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 522);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bot Logger";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.Logs_Page.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logs_DGV)).EndInit();
            this.Settings_Page.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.Products_Page.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Products_DGV)).EndInit();
            this.Bots_Page.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.Server_Page.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Logs_Page;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Products_CB;
        private System.Windows.Forms.DataGridView Logs_DGV;
        private System.Windows.Forms.TabPage Settings_Page;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Products_Page;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddProduct_B;
        private System.Windows.Forms.Button DeleteProduct_B;
        private System.Windows.Forms.DataGridView Products_DGV;
        private System.Windows.Forms.TabPage Bots_Page;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveBotSettings_B;
        private System.Windows.Forms.TextBox TelegramToken_TB;
        private System.Windows.Forms.TextBox TelegramHost_TB;
        private System.Windows.Forms.TextBox TelegramPort_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProduct;
        private System.Windows.Forms.TabPage Server_Page;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button SaveServer_B;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox IPServer_TB;
        private System.Windows.Forms.TextBox PortServer_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}

