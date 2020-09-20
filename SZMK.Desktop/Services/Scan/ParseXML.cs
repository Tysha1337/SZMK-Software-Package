using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.BindingModels;
using SZMK.Desktop.Models;
using SZMK.Desktop.Views.Shared;

namespace SZMK.Desktop.Services.Scan
{
    public class ParseXML : BaseScanOrder
    {
        public List<Order> Orders { get; set; }
        public List<TreeNode> TreeNodes { get; set; }
        public List<OrderScanSession> OrderScanSession { get; set; }
        public void Start(string[] FileNames)
        {
            Orders = new List<Order>();
            TreeNodes = new List<TreeNode>();

            for(int i = 0; i < FileNames.Length; i++)
            {
                Model Model = GetModel(FileNames[i]);
                Orders.AddRange(GetOrders(FileNames[i],Model));
                TreeNodes.AddRange(GetTreeNodes(FileNames[i]));
            }
        }
        public Model GetModel(string FileName)
        {
            try
            {
                return new Model();
            }
            catch
            {
                return new Model();
            }
        }
        public List<Order> GetOrders(string FileName, Model Model)
        {
            try
            {
                return new List<Order>();
            }
            catch
            {
                return new List<Order>();
            }
        }
        public List<TreeNode> GetTreeNodes(string FileName)
        {
            try
            {
                return new List<TreeNode>();
            }
            catch
            {
                return new List<TreeNode>();
            }
        }
        public void CheckedData()
        {
            try
            {
                OrderScanSession = new List<OrderScanSession>();
                for(int i = 0; i < Orders.Count; i++)
                {
                    SetResult(Orders[i],OrderScanSession);
                }
            }
            catch (Exception E)
            {
                OrderScanSession.Clear();
                throw new Exception(E.Message, E);
            }
        }
    }
}
