using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml.Linq;
using SZMK.Desktop.BindingModels;
using ZXing;

namespace SZMK.Desktop.Services.Scan
{
    public class WebcamScanOrder : BaseScanOrder
    {
        private VideoCaptureDevice videoSource;
        private BarcodeReader reader;
        private String Device;
        delegate void SetStringDelegate(String parameter);
        public delegate void LoadData(List<OrderScanSession> ScanSession);
        public event LoadData LoadResult;
        public delegate void LoadVideo(Bitmap Frame);
        public event LoadVideo LoadFrame;
        private List<OrderScanSession> _Orders;

        public WebcamScanOrder()
        {
            try
            {
                GetDevice();
                _Orders = new List<OrderScanSession>();
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool GetDevice()
        {
            try
            {
                XDocument doc = XDocument.Load(SystemArgs.Path.UserWebCamDevice);
                Device = doc.Element("Device").Value;
                return true;
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                throw new Exception(E.Message);
            }
        }

        public bool Start()
        {
            try
            {
                reader = new BarcodeReader();
                reader.Options.PossibleFormats = new List<BarcodeFormat>
                {
                    ZXing.BarcodeFormat.QR_CODE,
                    ZXing.BarcodeFormat.DATA_MATRIX
                };

                videoSource = new VideoCaptureDevice(Device);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
                if (videoSource.IsRunning)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                return false;
            }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                LoadFrame?.Invoke(bitmap);
                Result result = reader.Decode((Bitmap)eventArgs.Frame.Clone());

                eventArgs.Frame.Dispose();

                if (result != null)
                {
                    var fromEncodind = Encoding.GetEncoding("ISO-8859-1");//из какой кодировки
                    var bytes = fromEncodind.GetBytes(result.Text);
                    var toEncoding = Encoding.GetEncoding(1251);//в какую кодировку

                    string datamatrix = toEncoding.GetString(bytes);

                    while (datamatrix.IndexOf("\u001d") != -1)
                    {
                        datamatrix = datamatrix.Replace("\u001d", "и");
                    }

                    if(SetResult(FormingOrder(datamatrix), _Orders, false))
                    {
                        LoadResult?.Invoke(_Orders);
                    }
                }
            }
            catch
            {

            }

        }
        public bool Stop()
        {
            try
            {

                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
                    reader = null;
                    videoSource.SignalToStop();
                    Dispatcher.CurrentDispatcher.InvokeShutdown();
                    videoSource.WaitForStop();
                    videoSource = null;
                }
                return true;
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                return false;
            }
        }
        public List<OrderScanSession> GetScanSessions()
        {
            return _Orders;
        }
    }
}
