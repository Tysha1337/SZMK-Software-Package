using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.ServerControl.Common
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
             where TView : IView;

        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;
        DialogResult RunDialog<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
        DialogResult RunDialog<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}
