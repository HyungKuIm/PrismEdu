using NavTree2.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace NavTree2
{
    public class NavTree2Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("NaviTree", typeof(NavigationTree));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}