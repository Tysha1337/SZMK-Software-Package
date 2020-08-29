using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.Shared
{
    public partial class Settings_MobileApp : Form
    {
        public Settings_MobileApp()
        {
            InitializeComponent();
        }

        private void Generate_B_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(IP_TB.Text))
                {
                    IP_TB.Focus();
                    throw new Exception("Необходимо ввести IP - адрес");
                }

                if (String.IsNullOrEmpty(Port_TB.Text))
                {
                    Port_TB.Focus();
                    throw new Exception("Необходимо ввести порт");
                }

                Int32 Port = Convert.ToInt32(Port_TB.Text);

                if ((Port >= 48654 && Port <= 48999)||( Port >= 49152 && Port <= 65535))
                {
                    Port_TB.Focus();
                    throw new Exception("Необходимо использовать порты в диапазоне [48654..48999] или [49152..65535]");
                }

                SystemArgs.MobileApplication.Port = Port_TB.Text.Trim();

                if (SystemArgs.MobileApplication.SetParametersConnect())
                {
                    Zen.Barcode.CodeQrBarcodeDraw QrCode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    QR_PB.Image = QrCode.Draw($"{IP_TB.Text.Trim()}_{SystemArgs.MobileApplication.Port}", 100);
                    MessageBox.Show("Параметры подключения успешно обновлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                Port_TB.Focus();
                MessageBox.Show("Порт подключения должен состоять из целых цифр", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
