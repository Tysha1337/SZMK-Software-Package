using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Services.Scan
{
    public class ScannerOrder : BaseScanOrder
    {
        protected bool connect;
        protected SerialPort port;
        private String Port;
        delegate void SetStringDelegate(String parameter);
        public delegate void LoadData(List<OrderScanSession> ScanSession);
        public event LoadData LoadResult;
        private List<OrderScanSession> _Orders;

        public ScannerOrder()
        {
            try
            {
                if (GetPort())
                {
                    port = new SerialPort(Port);

                    _Orders = new List<OrderScanSession>();
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Start()
        {
            try
            {
                port.Encoding = Encoding.GetEncoding(1251);
                port.Open();
                port.DiscardInBuffer();
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                connect = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                connect = false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        protected void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!connect)
            {
                return;
            }
            string code = port.ReadExisting();

            while (code.IndexOf("\u001d") != -1)
            {
                code = code.Replace("\u001d", "и");
            }

            if (SetResult(FormingOrder(code), _Orders, false))
            {
                LoadResult?.Invoke(_Orders);
            }

        }
        public List<OrderScanSession> GetScanSessions()
        {
            return _Orders;
        }
        public bool GetPort()
        {
            try
            {
                XDocument doc = XDocument.Load(SystemArgs.Path.UserScannerPort);
                Port = doc.Element("Port").Value;
                return true;
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                throw new Exception(E.Message);
            }
        }
    }
}
