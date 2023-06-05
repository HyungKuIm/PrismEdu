using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace NavTree2.ViewModels
{
    public class TreeItemViewModel : BindableBase
    {
        //public string FullPath { get; set; }
        private string fullPath;
        public string FullPath
        {
            get { return fullPath; }
            set { SetProperty(ref fullPath, value); }
        }
        //public string Name { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private bool isExpanded;

        public bool IsExpanded
        {
            get {
                return isExpanded;
            }
            set {
                Debug.WriteLine($"IsExpanded:{value}");
                SetProperty(ref isExpanded, value);

                if (value == true)
                {
                    Expand();
                } else
                {
                    ClearChildren();
                }
                
            }
        }

        private void Expand()
        {
            var children = DirectoryUtils.GetDirectoryContents(fullPath);
            this.Children.Clear();
            children.ForEach(d =>
            {
                var treeItemModel = new TreeItemViewModel
                {
                    FullPath = d,
                    Name = DirectoryUtils.GetFileFolderName(d),
                    Children = new ObservableCollection<TreeItemViewModel>
                    {
                        new TreeItemViewModel { }
                    }
                };
                this.Children.Add(treeItemModel);
            });

        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<TreeItemViewModel>();
            this.Children.Add(null);
        }

        public ObservableCollection<TreeItemViewModel> Children { get; set; }

        public TreeItemViewModel()
        {
            //Debug.WriteLine("TreeItemViewModel");
        }

        //public TreeItemViewModel(string fullPath)
        //{
        //    FullPath = fullPath;
        //    Name = fullPath;
        //}
    }
}
