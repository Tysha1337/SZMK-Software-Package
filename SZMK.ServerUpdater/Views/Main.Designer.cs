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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Main_MS = new System.Windows.Forms.MenuStrip();
            this.основныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Versions_DGV = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_B = new System.Windows.Forms.Button();
            this.Change_B = new System.Windows.Forms.Button();
            this.Delete_B = new System.Windows.Forms.Button();
            this.Main_MS.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Versions_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_MS
            // 
            this.Main_MS.BackColor = System.Drawing.Color.FloralWhite;
            this.Main_MS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
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
            this.настройкаToolStripMenuItem});
            this.основныеToolStripMenuItem.Name = "основныеToolStripMenuItem";
            this.основныеToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.основныеToolStripMenuItem.Text = "Основные";
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.настройкаToolStripMenuItem.Text = "Настройки";
            this.настройкаToolStripMenuItem.Click += new System.EventHandler(this.настройкаToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FloralWhite;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Versions_DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Add_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Change_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Delete_B, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(363, 567);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список версий";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Versions_DGV
            // 
            this.Versions_DGV.AllowUserToAddRows = false;
            this.Versions_DGV.AllowUserToDeleteRows = false;
            this.Versions_DGV.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Versions_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Versions_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Versions_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version});
            this.Versions_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Versions_DGV.Location = new System.Drawing.Point(5, 50);
            this.Versions_DGV.Margin = new System.Windows.Forms.Padding(5);
            this.Versions_DGV.Name = "Versions_DGV";
            this.Versions_DGV.ReadOnly = true;
            this.Versions_DGV.RowHeadersVisible = false;
            this.Versions_DGV.Size = new System.Drawing.Size(353, 392);
            this.Versions_DGV.TabIndex = 1;
            // 
            // Version
            // 
            this.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Version.DefaultCellStyle = dataGridViewCellStyle2;
            this.Version.HeaderText = "Версия";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // Add_B
            // 
            this.Add_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.Add_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_B.Location = new System.Drawing.Point(5, 452);
            this.Add_B.Margin = new System.Windows.Forms.Padding(5);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(353, 30);
            this.Add_B.TabIndex = 2;
            this.Add_B.Text = "Добавить";
            this.Add_B.UseVisualStyleBackColor = false;
            this.Add_B.Click += new System.EventHandler(this.Add_B_Click);
            // 
            // Change_B
            // 
            this.Change_B.BackColor = System.Drawing.Color.NavajoWhite;
            this.Change_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Change_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Change_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Change_B.Location = new System.Drawing.Point(5, 492);
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
            this.Delete_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Delete_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete_B.Location = new System.Drawing.Point(5, 532);
            this.Delete_B.Margin = new System.Windows.Forms.Padding(5);
            this.Delete_B.Name = "Delete_B";
            this.Delete_B.Size = new System.Drawing.Size(353, 30);
            this.Delete_B.TabIndex = 4;
            this.Delete_B.Text = "Удалить";
            this.Delete_B.UseVisualStyleBackColor = false;
            this.Delete_B.Click += new System.EventHandler(this.Delete_B_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(363, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Main_MS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.Main_MS;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервер обновлений";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Main_MS.ResumeLayout(false);
            this.Main_MS.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Versions_DGV)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
    }
}

