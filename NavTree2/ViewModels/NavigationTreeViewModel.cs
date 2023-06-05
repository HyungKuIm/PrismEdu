using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NavTree2.ViewModels
{
    public class NavigationTreeViewModel : BindableBase
    {
        public ObservableCollection<TreeItemViewModel> Items { get; set; }

        public NavigationTreeViewModel()
        {
            // 논리 드라이브를 구한다.
            var children = Directory.GetLogicalDrives();
               

            this.Items = new ObservableCollection<TreeItemViewModel>(
                    children.Select(x => new TreeItemViewModel
                    {
                        FullPath = x,
                        Name = x,
                        Children = new ObservableCollection<TreeItemViewModel>
                        {
                            new TreeItemViewModel {}
                        }
                    }
                ));

            //foreach ( var child in children ) {
            //    TreeItemViewModel treeItemViewModel = new TreeItemViewModel
            //    {
            //        FullPath = child,
            //        Name = child,
            //        Children = new ObservableCollection<TreeItemViewModel>()
            //    };
            //    treeItemViewModel.Children.Add(null);
            //    this.Items.Add(treeItemViewModel);
            //}

        }
    }
}
