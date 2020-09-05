using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Tekla21_1.Views.Shared.Interfaces;

namespace SZMK.TeklaInteraction.Tekla21_1.Views.Shared
{
    public partial class Loading : Form, INotifyProgress
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
