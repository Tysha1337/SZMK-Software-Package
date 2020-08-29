using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services
{
    public class Updates
    {
        private String _Version;
        private DateTime _Date;
        private List<String> _AddedUpdate;
        private List<String> _DeletedUpdate;

        public Updates(String Version,DateTime Date)
        {
            if (!String.IsNullOrEmpty(Version))
            {
                _Version = Version;
            }
            else
            {
                throw new Exception("Пустое значение версии");
            }
            if (Date != null)
            {
                _Date = Date;
            }
            else
            {
                throw new Exception("Пустое значение даты");
            }
            _AddedUpdate = new List<string>();
            _DeletedUpdate = new List<string>();
        }
        public String Version
        {
            get
            {
                return _Version;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _Version = value;
                }
            }
        }
        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (value != null)
                {
                    _Date = value;
                }
            }
        }
        public List<String> GetAdded()
        {
            return _AddedUpdate;
        }
        public List<String> GetDeleted()
        {
            return _DeletedUpdate;
        }
        public override string ToString()
        {
            return _Version;
        }
    }
}
