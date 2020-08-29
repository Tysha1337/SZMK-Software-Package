
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Services.Scan
{
    /*Класс для создания клиента отправки файла для распознования на сервере, и получение информации в ответ, также реализовано проверка подключения, добавление в лист сессии, и сжатие файла перед отправкой*/
    public class ByteScout
    {
        private String _Port;
        private String _Server;
        private Boolean _NeedChecked;
        public delegate void LoadData(List<DecodeScanSession> ScanSession);
        public event LoadData Load;
        public delegate void RenameData(String result, String Path);
        public event RenameData Rename;
        public delegate void FailData(String FileName);
        public event FailData Fail;
        private readonly List<DecodeScanSession> _DecodeSession;

        public ByteScout()
        {
            if (!GetParametersConnect())
            {
                throw new Exception("Ошибка при получении конфигурационных путей программы распознавания");
            }

            _DecodeSession = new List<DecodeScanSession>();
        }

        public DecodeScanSession this[Int32 Index]
        {
            get
            {
                return _DecodeSession[Index];
            }
            set
            {
                if (value != null)
                {
                    _DecodeSession[Index] = value;
                }
            }
        }
        public List<DecodeScanSession> GetDecodeSession()
        {
            return _DecodeSession;
        }
        public Boolean NeedChecked
        {
            get
            {
                return _NeedChecked;
            }
            set
            {
                _NeedChecked = value;
            }
        }
        public bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.MainConnectProgramPath))
                {
                    throw new Exception();
                }

                using (StreamReader sr = new StreamReader(File.Open(SystemArgs.Path.MainConnectProgramPath, FileMode.Open)))
                {
                    _Server = sr.ReadLine();
                    _Port = sr.ReadLine();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SetParametersConnect()
        {
            try
            {

                String DirConnProgram = SystemArgs.Path.GetDirectory(SystemArgs.Path.MainConnectProgramPath);

                if (!Directory.Exists(DirConnProgram))
                {
                    Directory.CreateDirectory(DirConnProgram);
                }

                using (StreamWriter sw = new StreamWriter(File.Open(SystemArgs.Path.MainConnectProgramPath, FileMode.Create)))
                {
                    sw.WriteLine(_Server);
                    sw.WriteLine(_Port);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public String Server
        {
            get
            {
                return _Server;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Server = value;
                }
            }
        }

        public String Port
        {
            get
            {
                return _Port;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Port = value;
                }
            }
        }

        public void ClearData()
        {
            _DecodeSession.Clear();
        }
        public String SendAndRead(String FileName, String OldFileName)
        {
            TcpClient tcpClient = new TcpClient(_Server, Convert.ToInt32(_Port));
            String responseData = String.Empty;
            using (FileStream inputStream = File.OpenRead(FileName))
            {
                using (NetworkStream outputStream = tcpClient.GetStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(outputStream))
                    {
                        bool CloseConnect = false;
                        long lenght = inputStream.Length;
                        long totalBytes = 0;
                        int readBytes = 0;
                        byte[] buffer = new byte[8192];
                        writer.Write(CloseConnect);
                        writer.Write(SystemArgs.User.Login);
                        writer.Write(OldFileName);
                        writer.Write(SystemArgs.Path.GetFileName(FileName));
                        writer.Write(lenght);
                        do
                        {
                            readBytes = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        } while (tcpClient.Connected && totalBytes < lenght);
                        Byte[] readingData = new Byte[256];
                        StringBuilder completeMessage = new StringBuilder();
                        int numberOfBytesRead = 0;
                        do
                        {
                            numberOfBytesRead = outputStream.Read(readingData, 0, readingData.Length);
                            completeMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
                        }
                        while (outputStream.DataAvailable);
                        responseData = completeMessage.ToString();
                        if (_NeedChecked)
                        {
                            if (AddDecodeSession(responseData.Replace(" ", "")))
                            {
                                Load?.Invoke(_DecodeSession);
                            }
                            else
                            {
                                Fail?.Invoke(OldFileName);
                            }
                        }
                        else if (responseData.Split('_').Length != 6)
                        {
                            Fail?.Invoke(OldFileName);
                        }
                        else
                        {
                            Rename?.Invoke(responseData, OldFileName);
                        }
                    }
                }
            }
            tcpClient.Close();
            return responseData;
        }

        public bool CheckedUniqueList(String Message)
        {
            foreach (var item in _DecodeSession)
            {
                if (item.DataMatrix.Equals(Message))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckConnect()
        {
            try
            {
                TcpClient tcpClient = new TcpClient();

                var result = tcpClient.BeginConnect(_Server, Convert.ToInt32(_Port),null,null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                if (!success)
                {
                    throw new Exception();
                }

                NetworkStream outputStream = tcpClient.GetStream();
                BinaryWriter writer = new BinaryWriter(outputStream);
                writer.Write(true);
                writer.Write(SystemArgs.User.Login);
                tcpClient.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public String GetPathTempFile(String FileName, int Index)
        {
            Image myImage = Image.FromFile(FileName);
            Bitmap source = new Bitmap(myImage);
            Bitmap CroppedImage = source.Clone(new System.Drawing.Rectangle(source.Width - 1300, source.Height - 1800, 1300, 1500), source.PixelFormat);
            string path = @"TempFile\" + Index + ".jpg";
            CroppedImage = new Bitmap(CroppedImage, new Size(500, 600));
            CroppedImage.Save(path);
            source.Dispose();
            CroppedImage.Dispose();
            myImage.Dispose();
            return path;
        }

        private bool AddDecodeSession(String DataMatrix)
        {
            if (DataMatrix.Split('_').Length != 6)
            {
                return false;
            }
            else
            {
                String[] Temp = DataMatrix.Split('_');
                DataMatrix = Temp[0] + "_" + Temp[1] + "_" + Temp[2] + "_" + Temp[3] + "_" + Temp[4].Replace(".", ",") + "_" + Temp[5].Replace(".", ",");
                if (CheckedUniqueList(DataMatrix))
                {
                    if (SystemArgs.Request.CheckedStatusOrderDB(Temp[0], Temp[1]) == SystemArgs.User.StatusesUser[0].ID - 1)
                    {
                        _DecodeSession.Add(new DecodeScanSession(DataMatrix, 1));
                    }
                    else if ((SystemArgs.Request.CheckedStatusOrderDB(Temp[0], Temp[1]) >= SystemArgs.User.StatusesUser[0].ID))
                    {
                        _DecodeSession.Add(new DecodeScanSession(DataMatrix, 0));
                    }
                    else
                    {
                        _DecodeSession.Add(new DecodeScanSession(DataMatrix, -1));
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
