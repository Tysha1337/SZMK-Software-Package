using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.Design_Engineer
{
    public partial class Design_Engineer_SettingConfig_F : Form
    {
        public Design_Engineer_SettingConfig_F()
        {
            InitializeComponent();
        }

        private void OK_B_Click(object sender, EventArgs e)
        {
            try
            {
                SystemArgs.SettingsUser.Hidden = Hidden_CB.Checked;

                if (SystemArgs.SettingsUser.SetParametersConnect())
                {
                    MessageBox.Show("Параметры успешно записаны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Ошибка при записи параметров");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + ". Запись не выполнена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
