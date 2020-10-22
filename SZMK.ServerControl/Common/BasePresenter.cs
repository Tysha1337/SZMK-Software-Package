using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.ServerControl.Common
{

    public abstract class BasePresener<TView> : IPresenter
where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresener(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public void Run()
        {
            View.Show();
        }

        public DialogResult RunDialog()
        {
            return View.ShowDialog();
        }
    }

    public abstract class BasePresener<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresener(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public abstract void Run(TArg argument);

        public abstract DialogResult RunDialog(TArg argument);
    }
}
