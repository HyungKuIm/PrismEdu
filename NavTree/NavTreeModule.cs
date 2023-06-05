using NavTree.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace NavTree
{
    public class NavTreeModule : IModule
    {
        // Prism 6
        //private IRegionManager _regionManager;

        //public NavTreeModule(IRegionManager regionManager)
        //{
        //    _regionManager = regionManager;
        //}

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //this._regionManager.RegisterViewWithRegion("NaviTree", typeof(Views.NavigationTree));
            //Prism 7이후 코딩
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("NaviTree", typeof(Views.NavigationTree));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}