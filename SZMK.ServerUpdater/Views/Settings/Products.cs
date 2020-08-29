using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.ServerUpdater.Services;
using SZMK.ServerUpdater.Views.Interfaces;
using SZMK.ServerUpdater.Views.Shared;

namespace SZMK.ServerUpdater.Views.Settings
{
    public partial class SettingsProducts : Form, IBaseView
    {
        private BindingList<string> Products;

        public SettingsProducts(BindingList<string> Products)
        {
            InitializeComponent();

            this.Products = Products;
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            PositionListBox dialog = new PositionListBox(Products_LB.Items.Cast<String>().ToList());
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OperationsProducts product = new OperationsProducts();
                product.Add(dialog.Info_TB.Text);
                Products.Add(dialog.Info_TB.Text);
            }
        }

        private void Change_B_Click(object sender, EventArgs e)
        {
            if (Products_LB.SelectedItems.Count == 1)
            {
                PositionListBox dialog = new PositionListBox(Products_LB.Items.Cast<String>().ToList());
                dialog.Text = "Изменение информации";
                dialog.Title_L.Text = "Изменение информации";
                dialog.Info_TB.Text = Products_LB.SelectedItem.ToString();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OperationsProducts product = new OperationsProducts();
                    product.Change(Products_LB.SelectedItem.ToString(), dialog.Info_TB.Text);
                    Products[Products_LB.SelectedIndex] = dialog.Info_TB.Text;
                }
            }
            else
            {
                Error("Необходимо выбрать одну позицию для изменения");
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if (Products_LB.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Вы действтельно хотите удалить продукт, также удалятся все загруженные версии?!", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    OperationsProducts product = new OperationsProducts();
                    product.Delete(Products_LB.SelectedItem.ToString());
                    Products.Remove(Products[Products_LB.SelectedIndex]);
                }
            }
            else
            {
                Error("Необходимо выбрать одну позицию для удаления");
            }
        }
        public void Info(string Message)
        {
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warn(string Message)
        {
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(string Message)
        {
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
