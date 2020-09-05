using NLog;
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
        private readonly Logger logger;

        private BindingList<string> Products;

        public SettingsProducts(BindingList<string> Products)
        {
            InitializeComponent();

            logger = LogManager.GetCurrentClassLogger();

            this.Products = Products;

            logger.Info("Инициализация формы настроек продуктов пройдена успешно");
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                PositionListBox dialog = new PositionListBox(Products_LB.Items.Cast<String>().ToList());
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OperationsProducts product = new OperationsProducts();
                    product.Add(dialog.Info_TB.Text);
                    Products.Add(dialog.Info_TB.Text);
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Change_B_Click(object sender, EventArgs e)
        {
            try
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
                    throw new Exception("Необходимо выбрать одну позицию для изменения");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            try
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
                    throw new Exception("Необходимо выбрать одну позицию для удаления");
                }
            }
            catch (Exception Ex)
            {
                Error(Ex);
            }
        }
        public void Info(string Message)
        {
            logger.Info(Message);
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warn(string Message)
        {
            logger.Warn(Message);
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(Exception Ex)
        {
            logger.Error(Ex.ToString());
            MessageBox.Show(Ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
