namespace SZMK.ServerControl.Views.Main
{
    partial class Main
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.основныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsServer_TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.38931F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.41985F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.98001F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 2);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(228, 467);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(527, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(5, 467);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Состояние сервера";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(5, 422);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(368, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Запустить";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(5, 367);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(750, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Управление сервером";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(750, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "Список клиентов";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChangeDate,
            this.ClientStatus,
            this.ClientIP,
            this.ClientName,
            this.ClientVersion});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(5, 60);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(750, 297);
            this.dataGridView1.TabIndex = 6;
            // 
            // ChangeDate
            // 
            this.ChangeDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChangeDate.FillWeight = 20F;
            this.ChangeDate.HeaderText = "Дата изменения";
            this.ChangeDate.Name = "ChangeDate";
            // 
            // ClientStatus
            // 
            this.ClientStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientStatus.FillWeight = 15F;
            this.ClientStatus.HeaderText = "Статус клиента";
            this.ClientStatus.Name = "ClientStatus";
            // 
            // ClientIP
            // 
            this.ClientIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientIP.FillWeight = 25F;
            this.ClientIP.HeaderText = "IP Клиента";
            this.ClientIP.Name = "ClientIP";
            // 
            // ClientName
            // 
            this.ClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientName.FillWeight = 25F;
            this.ClientName.HeaderText = "Имя клиента";
            this.ClientName.Name = "ClientName";
            // 
            // ClientVersion
            // 
            this.ClientVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientVersion.FillWeight = 15F;
            this.ClientVersion.HeaderText = "Версия клиента";
            this.ClientVersion.Name = "ClientVersion";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(383, 422);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(372, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Остановить";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.основныеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // основныеToolStripMenuItem
            // 
            this.основныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsServer_TSM});
            this.основныеToolStripMenuItem.Name = "основныеToolStripMenuItem";
            this.основныеToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.основныеToolStripMenuItem.Text = "Основные";
            // 
            // SettingsServer_TSM
            // 
            this.SettingsServer_TSM.Name = "SettingsServer_TSM";
            this.SettingsServer_TSM.Size = new System.Drawing.Size(180, 22);
            this.SettingsServer_TSM.Text = "Настройка сервера";
            this.SettingsServer_TSM.Click += new System.EventHandler(this.SettingsServer_TSM_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервер контроля клиентов";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientVersion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem основныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsServer_TSM;
    }
}