using System;
using SimpleTCP;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Services.Scan
{
    /*Данный класс описывает сервер для получения данных от клиентского мобильного приложения после сканирования чертежей, 
     а также реализует проверки на уникальность полученных данных, замену одинаковопишущихся букв на английский алфавит, проверки на формат полученных данных*/
    public class ServerMobileAppOrder : BaseScanOrder
    {
        SimpleTcpServer ServerTCP;
        public delegate void LoadData(List<OrderScanSession> ScanSession);
        public event LoadData Load;
        private readonly List<OrderScanSession> _Orders;

        public ServerMobileAppOrder()
        {
            _Orders = new List<OrderScanSession>();
        }
        public OrderScanSession this[Int32 Index]
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
        public List<OrderScanSession> GetScanSessions()
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
            if (SetResult(FormingOrder(e.MessageString), _Orders, false))
            {
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
