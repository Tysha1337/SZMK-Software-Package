using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.Services.DataGridView.Sort
{
    class ListFieldSort
    {
        private static Boolean _isSort;

        public Boolean IsSort
        {
            get => _isSort;

            set => _isSort = value;
        }

        private String ReplaceSymbol(String list)
        {
            return list.Replace("и", ",").Replace(".", ",");
        }

        public IEnumerable<Order> SortAsc(IEnumerable<Order> orders)
        {
            try
            {
                IEnumerable<Order> ResultSuccess = orders.OrderBy(p => Convert.ToDouble(ReplaceSymbol(p.List)));

                return ResultSuccess;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public IEnumerable<Order> SortDesc(IEnumerable<Order> orders)
        {
            try
            {
                IEnumerable<Order> ResultSuccess = orders.OrderByDescending(p => Convert.ToDouble(ReplaceSymbol(p.List)));

                return ResultSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
