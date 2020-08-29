using System;
using SimpleTCP;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Services.Scan
{
    /*Данный класс описывает серверную часть для получения данных после сканирования бланка заказа, 
     * также в нем реализованы проверки на уникальность полученных данных и вызываются проверки для определения нахождения чертежа или его отсутсвия*/
    public class ServerMobileAppBlankOrder : BaseScanBlankOrder
    {
        SimpleTcpServer ServerTCP;
        private Boolean _Added;
        public delegate void LoadData(List<BlankOrderScanSession> ScanSession);
        public event LoadData Load;
        public delegate void LoadStatus(String QRBlankOrder);
        public event LoadStatus Status;
        private readonly List<BlankOrderScanSession> _Orders;

        public ServerMobileAppBlankOrder(Boolean Added)
        {
            _Added = Added;
            _Orders = new List<BlankOrderScanSession>();
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
        public BlankOrderScanSession this[Int32 Index]
        {
            get
            {
                return _Orders[Index];
            }
            set
            {
                if (value != null)
                {
                    _Orders[Index] = value;
                }
            }
        }
        public List<BlankOrderScanSession> GetScanSessions()
        {
            return _Orders;
        }
        public void ClearData()
        {
            _Orders.Clear();
        }
        public bool Start()
        {
            ServerTCP = new SimpleTcpServer
            {
                Delimiter = 0x13
            };
            ServerTCP.DataReceived += Server_DataReceived;
            ServerTCP.StringEncoder = Encoding.UTF8;
            IPAddress ip = IPAddress.Parse(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString());
            ServerTCP.Start(ip, Convert.ToInt32(SystemArgs.MobileApplication.Port));
            if (ServerTCP.IsStarted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            if(SetResult(e.MessageString, Added, _Orders))
            {
                Status?.Invoke(e.MessageString.Replace("\u00a0", "").Replace(" ", ""));
                Load?.Invoke(_Orders);
            }
        }
        public bool Stop()
        {
            if (ServerTCP != null)
            {
                if (ServerTCP.IsStarted)
                {
                    ServerTCP.Stop();
                }
            }
            if (!ServerTCP.IsStarted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
