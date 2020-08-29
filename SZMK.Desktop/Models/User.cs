using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Models.Interfaces;

namespace SZMK.Desktop.Models
{
    public class User : IPositionToUser
    {
        private Int64 _ID;
        private String _Name;
        private String _MiddleName;
        private String _Surname;
        private DateTime _DateCreate;
        private readonly List<Mail> _Mails;
        private Position _Position;
        private String _Login;
        private String _HashPassword;
        private Boolean _UpdPassword;
        private readonly List<Status> _StatusesUser;


        public User(Int64 ID, String Name, String MiddleName, String Surname, DateTime DateCreate, Int64 IDPosition,
                    List<Mail> ListMails, String Login, String HashPassword, Boolean UpdPassword)
        {
            _ID = ID;

            if(!String.IsNullOrEmpty(Name))
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

            if(DateCreate != null)
            {
                _DateCreate = DateCreate;
            }

            if (ListMails != null)
            {
                _Mails = ListMails;
            }

            if (!SetPosition(IDPosition))
            {
                throw new Exception("Получено пустое значение должности пользователя");
            }

            if (!String.IsNullOrEmpty(Login))
            {
                _Login = Login;
            }
            else
            {
                throw new Exception("Получено пустое значение логина пользователя");
            }

            if (!String.IsNullOrEmpty(HashPassword))
            {
                _HashPassword = HashPassword;
            }
            else
            {
                throw new Exception("Получено пустое значение хэша пароля пользователя");
            }

            _UpdPassword = UpdPassword;

            _StatusesUser = SystemArgs.Statuses.Where(p => p.IDPosition == _Position.ID).OrderBy(p=>p.ID).ToList();
        }

        public User() : this(-1,"Нет имени", "Нет отчества", "Нет фамилии", DateTime.Now, -1, null, "Нет лоигна", "Нет хеша", false) { }

        public Position GetPosition()
        {
            if (_Position != null)
            {
                return _Position;
            }
            else
            {
                throw new Exception("Пользвоателю не присвоена должность");
            }
        }

        private bool SetPosition(Int64 IDPosition)
        {
            foreach(Position Temp in SystemArgs.Positions)
            {
                if(Temp.ID == IDPosition)
                {
                    _Position = Temp;
                    return true;
                }
            }

            return false;
        }

        public Boolean UpdPassword
        {
            get
            {
                return _UpdPassword;
            }

            set
            {
                _UpdPassword = value;
            }
        }

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

        public String Login
        {
            get
            {
                return _Login;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Login = value;
                }
            }
        }

        public String HashPassword
        {
            get
            {
                return _HashPassword;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _HashPassword = value;
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
                if(!String.IsNullOrEmpty(value))
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
                if(value != null)
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

        public Mail this[int index]
        {
            get
            {
                return _Mails[index];
            }

            set
            {
                _Mails[index] = value;
            }
        }

        public Int64 MailsCount
        {
            get
            {
                return _Mails.Count;
            }
        }

        public List<Mail> Mails
        {
            get
            {
                return _Mails;
            }
        }
        public List<Status> StatusesUser
        {
            get
            {
                return _StatusesUser;
            }
        }
        public override String ToString()
        {
            return _Login;
        }

        public String SearchString() => $"{_Name}_{_MiddleName}_{_Surname}_{_DateCreate.ToShortDateString()}_{_Position.Name}_{_Login}";
    }
}
