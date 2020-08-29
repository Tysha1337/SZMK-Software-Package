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
    public class ScannerBlankOrder : BaseScanBlankOrder
    {
        protected bool connect;
        protected SerialPort port;

        private String Port;
        private Boolean _Added;
        public delegate void LoadData(List<BlankOrderScanSession> ScanSession);
        public event LoadData LoadResult;
        public delegate void LoadStatus(String QRBlankOrder);
        public event LoadStatus Status;
        private readonly List<BlankOrderScanSession> _Orders;

        public ScannerBlankOrder(Boolean Added)
        {
            try
            {
                connect = false;

                _Added = Added;

                if (GetPort())
                {
                    port = new SerialPort(Port);

                    _Orders = new List<BlankOrderScanSession>();
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
                port.Encoding = Encoding.UTF8;
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

            if (SetResult(code, _Added, _Orders))
            {
                Status?.Invoke(code.Replace("\u00a0", "").Replace(" ", ""));

                LoadResult?.Invoke(_Orders);
            }
        }
        public List<BlankOrderScanSession> GetScanSessions()
        {
            return _Orders;
        }
        public Boolean Added
        {
            get
            {
                return _Added;
            }
            set
            {
                _Added = value;
            }
        }
        public void ClearData()
        {
            _Orders.Clear();
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
