using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SZMK.Desktop.Services.Setting
{
    public class Program
    {
        private Boolean _CheckMarks; 
        private (Int32, Int32) _VisualRow; // (n1,n2)
        private Boolean _CheckedProcess;

        public Program()
        {
            if (!GetParametersConnect())
            {
                throw new Exception("Ошибка при получении основных путей приложения");
            }
        }

        public bool GetParametersConnect()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.MainSettingsPath))
                {
                    throw new Exception();
                }

                XDocument parameters = XDocument.Load(SystemArgs.Path.MainSettingsPath);

                string marksCheck = parameters.Element("Program").Element("MarksCheck").Value;

                if (marksCheck.ToLower() != "true")
                {
                    _CheckMarks = false;
                }
                else
                {
                    _CheckMarks = true;
                }

                _VisualRow.Item1 = Convert.ToInt32(parameters.Element("Program").Element("VisualRowWarn").Value); // n1
                _VisualRow.Item2 = Convert.ToInt32(parameters.Element("Program").Element("VisualRowCritical").Value); // n2

                string processCheck = parameters.Element("Program").Element("CheckedProcess").Value;

                if (processCheck.ToLower() != "true")
                {
                    _CheckedProcess = false;
                }
                else
                {
                    _CheckedProcess = true;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetParametersConnect()
        {
            try
            {
                XDocument parameters = XDocument.Load(SystemArgs.Path.MainSettingsPath);

                parameters.Element("Program").Element("MarksCheck").SetValue(_CheckMarks);
                parameters.Element("Program").Element("VisualRowWarn").SetValue(_VisualRow.Item1);
                parameters.Element("Program").Element("VisualRowCritical").SetValue(_VisualRow.Item2);
                parameters.Element("Program").Element("CheckedProcess").SetValue(_CheckedProcess);

                parameters.Save(SystemArgs.Path.MainSettingsPath);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean CheckMarks
        {
            get
            {
                return _CheckMarks;
            }

            set
            {
                _CheckMarks = value;
            }
        }

        public Int32 VisualRow_N1
        {
            get
            {
                return _VisualRow.Item1;
            }

            set
            {
                _VisualRow.Item1 = value;
            }
        }

        public Int32 VisualRow_N2
        {
            get
            {
                return _VisualRow.Item2;
            }

            set
            {
                _VisualRow.Item2 = value;
            }
        }
        public Boolean CheckedProcess
        {
            get
            {
                return _CheckedProcess;
            }
            set
            {
                _CheckedProcess = value;
            }
        }
    }
}
