using System;
using System.Collections.Generic;
using System.Linq;

namespace SZMK.TeklaInteraction.Shared.Models
{
    public class User
    {
        private Int64 _ID;
        private String _Name;
        private String _MiddleName;
        private String _Surname;
        private DateTime _DateCreate;
        private Role _Role;
        private String _Login;
        private String _HashPassword;
        private Boolean _UpdPassword;
        private List<Status> _StatusesUser;


        public User(Int64 ID, String Name, String MiddleName, String Surname, DateTime DateCreate, List<Role> Roles, Int64 IDRole, String Login, String HashPassword, Boolean UpdPassword, List<Status> Statuses)
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

            if (!SetRole(IDRole, Roles))
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

            _StatusesUser = Statuses.Where(p => p.IDRole == _Role.ID).OrderBy(p => p.ID).ToList();
        }

        public User() : this(-1, "Нет имени", "Нет отчества", "Нет фамилии", DateTime.Now, null, -1, "Нет лоигна", "Нет хеша", false, null) { }

        public Role GetRole()
        {
            if (_Role != null)
            {
                return _Role;
            }
            else
            {
                throw new Exception("Пользвоателю не присвоена должность");
            }
        }

        private bool SetRole(Int64 IDPosition, List<Role> Roles)
        {
            foreach (Role Temp in Roles)
            {
                if (Temp.ID == IDPosition)
                {
                    _Role = Temp;
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
    }
}
