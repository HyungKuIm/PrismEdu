using NavTree;
using NavTree2;
using Prism.Ioc;
using Prism.Modularity;
using PrismEdu.Views;
using System.Windows;

namespace PrismEdu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<NavTree2Module>();
            //moduleCatalog.AddModule<NavTreeModule>();
        }
    }
}
