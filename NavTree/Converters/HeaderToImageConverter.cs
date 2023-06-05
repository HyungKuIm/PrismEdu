using NavTree.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace NavTree.Converters
{
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = 
            new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;

            if (path == null) {
                return null;
            }

            var name = NavigationTree.GetFileFolderName(path);

            var image = "Images/file.png";

            if (string.IsNullOrEmpty(name))
            {
                image = "Images/drive.png";
            } else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory)) 
            {
                image = "Images/folder-closed.png";
            }
            //pack://application:,,,/ReferencedAssembly;component/Subfolder/ResourceFile.xaml
            return new BitmapImage(new Uri($"pack://application:,,,/NavTree;component/{image}"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
