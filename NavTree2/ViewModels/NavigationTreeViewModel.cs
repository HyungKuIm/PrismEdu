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
            var children = Directory.GetLogicalDrives()
                .Select(drive => new TreeItemViewModel
                {
                    FullPath = drive
                }).ToList();

            //foreach (var child in children)
            //{
            //    Debug.WriteLine(child.FullPath);
            //}

            this.Items = new ObservableCollection<TreeItemViewModel>(
                    children.Select(drive => new TreeItemViewModel(drive.FullPath))
                );
            //this.Items = new ObservableCollection<TreeItemViewModel>(children);

        }
    }
}
