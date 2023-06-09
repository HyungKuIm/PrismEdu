﻿using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;
using System;

namespace NavTree.Views
{
    /// <summary>
    /// Interaction logic for NavigationTree
    /// </summary>
    public partial class NavigationTree : UserControl
    {
        public NavigationTree()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // 장비의 모든 논리 드라이브를 가져온다.
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem
                {
                    Header = drive,
                    Tag = drive
                };

                // 더미 아이템 추가
                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                this.FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            if (item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }

            item.Items.Clear();

            var fullPath = (string)item.Tag;

            var directories = new List<string>();
            
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            } catch { }

            directories.ForEach(d =>
            {
                var subItem = new TreeViewItem
                {
                    Header = GetFileFolderName(d),
                    Tag = d
                };

                subItem.Items.Add(null);
                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });

        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            var normalizedPath = path.Replace("/", "\\");
            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex < 0)
            {
                return path;
            }

            return path.Substring(lastIndex + 1);
        }
    }
}
