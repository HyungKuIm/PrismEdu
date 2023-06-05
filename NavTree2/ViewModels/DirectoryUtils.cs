using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavTree2.ViewModels
{
    public static class DirectoryUtils
    {
        public static List<TreeItemViewModel> GetDirectoryContents(string fullPath)
        {
            var list = new List<TreeItemViewModel>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    list.AddRange(dirs.Select(dir => new TreeItemViewModel
                    {
                        FullPath = dir,
                        Name = GetFileFolderName(dir)
                    }));
                }
            } catch { }

            return list;
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
