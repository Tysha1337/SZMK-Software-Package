using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.Arhive
{
    public partial class AR_DecodeReport_F : Form
    {
        public AR_DecodeReport_F()
        {
            InitializeComponent();
        }

        private void ARDecodeReport_F_Load(object sender, EventArgs e)
        {
            Report_DGV.AutoGenerateColumns = false;
            Report_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Report_DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Report_DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void Report_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(112, 238, 226);
            e.CellStyle.SelectionForeColor = Color.Black;
        }

        private void Report_DGV_SelectionChanged(object sender, EventArgs e)
        {
            Report_DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
