using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml.Linq;
using SZMK.Desktop.BindingModels;
using ZXing;

namespace SZMK.Desktop.Services.Scan
{
    public class WebcamScanBlankOrder : BaseScanBlankOrder
    {
        private Boolean _Added;
        private VideoCaptureDevice videoSource;
        private BarcodeReader reader;
        private String Device;
        public delegate void LoadData(List<BlankOrderScanSession> ScanSession);
        public event LoadData LoadResult;
        public delegate void LoadStatus(String QRBlankOrder);
        public event LoadStatus Status;
        public delegate void LoadVideo(Bitmap Frame);
        public event LoadVideo LoadFrame;
        private readonly List<BlankOrderScanSession> _Orders;

        public WebcamScanBlankOrder(Boolean Added)
        {
            try
            {
                GetDevice();
                _Added = Added;
                _Orders = new List<BlankOrderScanSession>();
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public List<BlankOrderScanSession> GetScanSessions()
        {
            return _Orders;
        }
        public void ClearData()
        {
            _Orders.Clear();
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
                if (result != null)
                {
                    if (SetResult(result.Text, Added, _Orders))
                    {
                        Status?.Invoke(result.Text.Replace("\u00a0", "").Replace(" ", ""));
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
                    reader =null;
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

    }
}
