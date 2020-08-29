using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Services.Setting
{
    public class SelectedColumn
    {
        List<Column> _Columns;
        public SelectedColumn()
        {
            if (CheckFile())
            {
                if (!GetParametrColumn())
                {
                    throw new Exception("Ошибка при чтении настроек столбцов");
                }
            }
            else
            {
                throw new Exception("Файл настроек столбцов не найден");
            }
        }

        public Column this[int Index]
        {
            get
            {
                return _Columns[Index];
            }
            set
            {
                _Columns[Index] = value;
            }
        }

        public List<Column> GetColumns()
        {
            return _Columns;
        }
        public bool SetParametrColumnFillWeight()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.UserVisualColumnsPath))
                {
                    throw new Exception();
                }

                XDocument xdoc = XDocument.Load(SystemArgs.Path.UserVisualColumnsPath);

                int i = 0;

                foreach (XElement ColumnVisible in xdoc.Element("Columns").Elements("Column"))
                {
                    for (int j = 0; j < _Columns.Count; j++)
                    {
                        if (_Columns[i].Name == ColumnVisible.Element("Name").Value)
                        {
                            ColumnVisible.Element("FillWeight").SetValue(_Columns[i].FillWeight);
                        }
                    }
                    i++;
                }

                xdoc.Save(SystemArgs.Path.UserVisualColumnsPath);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetParametrColumnDisplayIndex()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.UserVisualColumnsPath))
                {
                    throw new Exception();
                }

                XDocument xdoc = XDocument.Load(SystemArgs.Path.UserVisualColumnsPath);

                int i = 0;

                foreach (XElement ColumnVisible in xdoc.Element("Columns").Elements("Column"))
                {
                    for (int j = 0; j < _Columns.Count; j++)
                    {
                        if (_Columns[i].Name == ColumnVisible.Element("Name").Value)
                        {
                            ColumnVisible.Element("DisplayIndex").SetValue(_Columns[i].DisplayIndex);
                        }
                    }
                    i++;
                }

                xdoc.Save(SystemArgs.Path.UserVisualColumnsPath);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetParametrColumnVisible()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.UserVisualColumnsPath))
                {
                    throw new Exception();
                }

                XDocument xdoc = XDocument.Load(SystemArgs.Path.UserVisualColumnsPath);

                int i = 0;

                foreach (XElement ColumnVisible in xdoc.Element("Columns").Elements("Column"))
                {
                    for (int j = 0; j < _Columns.Count; j++)
                    {
                        if (_Columns[i].Name == ColumnVisible.Element("Name").Value)
                        {
                            if (_Columns[i].Visible)
                            {
                                ColumnVisible.Element("Visible").SetValue("true");
                            }
                            else
                            {
                                ColumnVisible.Element("Visible").SetValue("false");
                            }
                        }
                    }
                    i++;
                }

                xdoc.Save(SystemArgs.Path.UserVisualColumnsPath);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool GetParametrColumn()
        {
            try
            {
                if (!File.Exists(SystemArgs.Path.UserVisualColumnsPath))
                {
                    throw new Exception();
                }

                XDocument xdoc = XDocument.Load(SystemArgs.Path.UserVisualColumnsPath);

                _Columns = new List<Column>();

                foreach (XElement ColumnVisible in xdoc.Element("Columns").Elements("Column"))
                {
                    _Columns.Add(new Column(ColumnVisible.Element("Name").Value, ColumnVisible.Element("Visible").Value == "true" ? true : false, Convert.ToInt32(ColumnVisible.Element("DisplayIndex").Value), float.Parse(ColumnVisible.Element("FillWeight").Value, CultureInfo.InvariantCulture.NumberFormat)));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckFile()
        {
            if (!File.Exists(SystemArgs.Path.UserVisualColumnsPath))
            {
                return false;
            }

            return true;
        }
    }
}
