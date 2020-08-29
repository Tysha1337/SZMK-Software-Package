using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Models
{
    public class Mail
    {
        private Int64 _ID;
        private String _Name;
        private String _MiddleName;
        private String _Surname;
        private String _MailAddress;
        private DateTime _DateCreate;

        public Mail(Int64 ID, String Name, String MiddleName, String Surname, DateTime DateCreate, String MailAddress)
        {
            _ID = ID;

            if (!String.IsNullOrEmpty(Name))
            {
                _Name = Name;
            }
            else
            {
                throw new Exception("Получено пустое значение имени пользователя");
            }

            if (!String.IsNullOrEmpty(MiddleName))
            {
                _MiddleName = MiddleName;
            }
            else
            {
                throw new Exception("Получено пустое значение отчетства пользователя");
            }

            if (!String.IsNullOrEmpty(Surname))
            {
                _Surname = Surname;
            }
            else
            {
                throw new Exception("Получено пустое значение фамилии пользователя");
            }

            if (DateCreate != null)
            {
                _DateCreate = DateCreate;
            }
            else
            {
                throw new Exception("Получено пустое значение даты создания пользователя");
            }

            if (!String.IsNullOrEmpty(MailAddress))
            {
                _MailAddress = MailAddress;
            }
            else
            {
                throw new Exception("Получено пустое значение адреса почты пользователя");
            }
        }

        public Mail() : this(-1, "Нет имени", "Нет отчества", "Нет фамилии", DateTime.Now, "Нет почты") { }

        public Int64 ID
        {
            get
            {
                return _ID;
            }

            set
            {
                if (value >= 0)
                {
                    _ID = value;
                }
            }
        }

        public String Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Name = value;
                }
            }
        }

        public String Surname
        {
            get
            {
                return _Surname;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Surname = value;
                }
            }
        }

        public String MiddleName
        {
            get
            {
                return _MiddleName;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _MiddleName = value;
                }
            }
        }

        public DateTime DateCreate
        {
            get
            {
                return _DateCreate;
            }

            set
            {
                if (value != null)
                {
                    _DateCreate = value;
                }
            }
        }

        public String DateCreateView
        {
            get
            {
                return _DateCreate.ToString();
            }
        }

        public String MailAddress
        {
            get
            {
                return _MailAddress;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _MailAddress = value;
                }
            }
        }

        public String SearchString() => $"{_Name}_{_MiddleName}_{_Surname}_{_DateCreate.ToShortDateString()}_{_MailAddress}";
    }
}
