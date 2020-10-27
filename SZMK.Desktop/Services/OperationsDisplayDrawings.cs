using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.Services
{
    public class OperationsDisplayDrawings
    {
        public List<Order> ViewSeletedDrawing(ref System.Windows.Forms.DataGridView dataGridView)
        {
            try
            {
                List<Order> selectedDrawing = new List<Order>();

                if (dataGridView == null)
                {
                    throw new Exception("Полученая пустая ссылка элемента отображения DataGridView");
                }

                for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[i];

                    Order order = (Order)selectedRow.DataBoundItem ;

                    if (order != null)
                    {
                        selectedDrawing.Add(order);
                    }
                    else
                    {
                        selectedDrawing.Clear();
                        throw new Exception("В коллекции выделенных элементов DataGridView получен объект null");
                    }
                }

                return selectedDrawing;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }       
        }
    }
}
