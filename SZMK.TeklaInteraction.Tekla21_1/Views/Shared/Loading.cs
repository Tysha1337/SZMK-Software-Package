using System;
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
