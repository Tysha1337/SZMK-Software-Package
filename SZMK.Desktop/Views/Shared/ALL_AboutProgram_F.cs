using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Services;

namespace SZMK.Desktop.Views.Shared
{
    public partial class ALL_AboutProgram_F : Form
    {
        public ALL_AboutProgram_F()
        {
            InitializeComponent();
        }

        private void AboutProgram_F_Load(object sender, EventArgs e)
        {
            Version_TB.Text = SystemArgs.About.Version;
            DateUpdate_TB.Text = SystemArgs.About.DateUpdate.ToShortDateString();
            Versions_CB.DataSource=SystemArgs.About.GetUpdates();
            Developers_RTB.SelectAll();
            Developers_RTB.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void Versions_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DiscriptionsUpdate_RTB.Clear();
                Updates Temp = SystemArgs.About.GetUpdates().Where(p => p == (Updates)Versions_CB.SelectedItem).Single();
                DiscriptionsUpdate_RTB.AppendText($"Дата выпуска: " + Temp.Date.ToShortDateString() + Environment.NewLine);
                if (Temp.GetAdded().Count() != 0)
                {
                    DiscriptionsUpdate_RTB.AppendText($"Добавлено: " + Environment.NewLine);
                }
                for (int j = 0; j < Temp.GetAdded().Count(); j++)
                {
                    DiscriptionsUpdate_RTB.AppendText($"- " + Temp.GetAdded()[j] + Environment.NewLine);
                }
                if (Temp.GetDeleted().Count() != 0)
                {
                    DiscriptionsUpdate_RTB.AppendText($"Убрано: " + Environment.NewLine);
                }
                for (int j = 0; j < Temp.GetDeleted().Count(); j++)
                {
                    DiscriptionsUpdate_RTB.AppendText($"- " + Temp.GetDeleted()[j] + Environment.NewLine);
                }
            }
            catch
            {
                MessageBox.Show("Указанное обновление не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
