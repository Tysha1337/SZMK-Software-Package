using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.ViewModel
{
    public class DetailViewModel
    {
        private long _ID;
        private string _Position;
        private long _Count;
        private string _Profile;
        private double _Width;
        private double _Lenght;
        private double _Weight;
        private string _Height;
        private string _Diameter;
        private double _SubtotalWeight;
        private string _MarkSteel;
        private string _Discription;
        private string _Machining;
        private string _MethodOfPaintingRAL;
        private double _PaintingArea;
        private string _GostName;
        private string _FlangeThickness;
        private string _PlateThickness;


        public DetailViewModel(string Position, string Count, string Profile, string Width, string Lenght, string Weight, string Height, string Diameter, string SubtotalWeight, string MarkSteel, string Discription, string Machining, string MethodOfPaintingRAL, string PaintingArea, string GostName, string FlangeThickness, string PlateThickness)
        {
            string Error = "";
            try
            {
                if (String.IsNullOrEmpty(Position))
                {
                    Error = $"Не заполнена позиция детали";
                    throw new Exception();
                }
                else
                {
                    _Position = Position.Replace(" ", "");
                }

                Error = $"Позиция {_Position}: Количество деталей должно быть целым числом";
                _Count = Convert.ToInt32(Count.Replace(" ", ""));

                Error = $"Позиция {_Position}: Высота детали должна быть целым или вещественным числом";
                _Width = Convert.ToDouble(Width.Replace(" ", "").Replace(".", ","));

                Error = $"Позиция {_Position}: Длина детали должна быть целым или вещественным числом";
                _Lenght = Convert.ToDouble(Lenght.Replace(" ", "").Replace(".", ","));

                Error = $"Позиция {_Position}: Вес детали должна быть целым или вещественным числом";
                _Weight = Convert.ToDouble(Weight.Replace(" ", "").Replace(".", ","));

                _Height = Height.Replace(" ", "").Replace(".", ",");

                _Diameter = Diameter.Replace(" ", "").Replace(".", ",");

                Error = $"Позиция {_Position}: Итоговый вес детали должна быть целым или вещественным числом";
                _SubtotalWeight = Convert.ToDouble(SubtotalWeight.Replace(" ", "").Replace(".", ","));

                if (String.IsNullOrEmpty(MarkSteel))
                {
                    Error = $"Позиция {_Position}: Не заполнена марка стали детали";
                    throw new Exception();
                }
                else
                {
                    _MarkSteel = MarkSteel.Replace(" ", "");
                }

                _Discription = Discription.Replace(" ", "");

                _Machining = Machining.Replace(" ", "");

                _MethodOfPaintingRAL = MethodOfPaintingRAL.Replace(" ", "");

                Error = $"Позиция {_Position}: Площадь покраски детали должна быть целым или вещественным числом";
                _PaintingArea = Convert.ToDouble(PaintingArea.Replace(" ", "").Replace(".", ","));

                if (String.IsNullOrEmpty(GostName))
                {
                    Error = $"Позиция {_Position}: Не заполнен гост стали детали";
                    throw new Exception();
                }
                else
                {
                    _GostName = MarkSteel.Replace(" ", "");
                }

                _FlangeThickness = FlangeThickness.Replace(" ", "");
                _PlateThickness = PlateThickness.Replace(" ", "");

                if (String.IsNullOrEmpty(Profile))
                {
                    Error = $"Позиция {_Position}: Не заполнен профиль детали";
                    throw new Exception();
                }
                else
                {
                    _Profile = GetProfile(Profile.Replace(" ", ""));
                }

            }
            catch
            {
                throw new Exception(Error);
            }
        }

        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value > 0)
                {
                    _ID = value;
                }
            }
        }
        public string Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
            }
        }
        public long Count
        {
            get
            {
                return _Count;
            }
            set
            {
                if (value > 0)
                {
                    _Count = value;
                }
            }
        }
        public string Profile
        {
            get
            {
                return _Profile;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Profile = value;
                }
            }
        }
        public double Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (value > 0)
                {
                    _Width = value;
                }
            }
        }
        public double Lenght
        {
            get
            {
                return _Lenght;
            }
            set
            {
                if (value > 0)
                {
                    _Lenght = value;
                }
            }
        }
        public double Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                if (value > 0)
                {
                    _Weight = value;
                }
            }
        }
        public string Height
        {
            get
            {
                return _Height;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Height = value;
                }
            }
        }
        public string Diameter
        {
            get
            {
                return _Diameter;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Diameter = value;
                }
            }
        }
        public double SubTotalWeight
        {
            get
            {
                return _SubtotalWeight;
            }
            set
            {
                if (value > 0)
                {
                    _SubtotalWeight = value;
                }
            }
        }
        public string MarkSteel
        {
            get
            {
                return _MarkSteel;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _MarkSteel = value;
                }
            }
        }
        public string Discription
        {
            get
            {
                return _Discription;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Discription = value;
                }
            }
        }
        public string Machining
        {
            get
            {
                return _Machining;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Machining = value;
                }
            }
        }
        public string MethodOfPaintiongRAL
        {
            get
            {
                return _MethodOfPaintingRAL;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _MethodOfPaintingRAL = value;
                }
            }
        }
        public double PaintingArea
        {
            get
            {
                return _PaintingArea;
            }
            set
            {
                if (value > 0)
                {
                    _PaintingArea = value;
                }
            }
        }
        public string GostName
        {
            get
            {
                return _GostName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _GostName = value;
                }
            }
        }
        public string FlangeThickness
        {
            get
            {
                return _FlangeThickness;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _FlangeThickness = value;
                }
            }
        }
        public string PlateThickness
        {
            get
            {
                return _PlateThickness;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _PlateThickness = value;
                }
            }
        }

        private string GetProfile(string Profile)
        {
            try
            {
                int Index = -1;

                string[] Arguments = new string[] { "PL", "Утеплит", "Риф", "Сетка 50/50х2.5 В=1800", "ПВ", "ГОСТ 8509-93", "ГОСТ 8510-93", "PD", "Профиль(кв.)", "Профиль", "*" };
                for (int i = 0; i < Arguments.Length; i++)
                {
                    if (Arguments[i].IndexOf("ГОСТ") == -1)
                    {
                        if (Profile.IndexOf(Arguments[i]) != -1)
                        {
                            Index = i;
                            break;
                        }
                    }
                    else
                    {
                        if (_GostName.IndexOf(Arguments[i]) != -1)
                        {
                            Index = i;
                            break;
                        }
                    }
                }
                switch (Index)
                {
                    case 0:
                        int var4 = Convert.ToInt32(Profile.Substring(2, Profile.IndexOf("x") - 2));
                        int var5 = Convert.ToInt32(Profile.Substring(1 + Profile.IndexOf("x"), Profile.Length - Profile.IndexOf("x") - 1));

                        if (var4 > var5)
                        {
                            return "-" + var5.ToString();
                        }
                        else
                        {
                            return "-" + var4.ToString();
                        }
                    case 1:
                        return _MarkSteel;
                    case 2:
                        return _MarkSteel;
                    case 3:
                        return "Сетка 50/50х2.5 В=1800";
                    case 4:
                        return _MarkSteel;
                    case 5:
                        return $"L{_Width.ToString("F2").TrimEnd('0', ',')}x{_FlangeThickness}";
                    case 6:
                        return $"L{_Width.ToString("F2").TrimEnd('0', ',')}x{_Width.ToString("F2").TrimEnd('0', ',')}x{_FlangeThickness}";
                    case 7:
                        return $"Труба {_Diameter}x{_PlateThickness}";
                    case 8:
                        return $"Тр.кв.{_Height}x{_PlateThickness}";
                    case 9:
                        return $"Тр.пр.{_Height}x{_Height}x{_PlateThickness}";
                    case 10:
                        return Profile.Replace("*", "x");
                }
                return Profile;
            }
            catch
            {
                return Profile;
            }
        }
    }
}
