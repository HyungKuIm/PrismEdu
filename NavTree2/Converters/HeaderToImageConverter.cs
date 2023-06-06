using NavTree2.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace NavTree2.Converters
{
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = 
            new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = (string)value;

            if (image == null) {
                return null;
            }

            
            //pack://application:,,,/ReferencedAssembly;component/Subfolder/ResourceFile.xaml
            return new BitmapImage(new Uri($"pack://application:,,,/NavTree2;component/Images/{image}.png"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
