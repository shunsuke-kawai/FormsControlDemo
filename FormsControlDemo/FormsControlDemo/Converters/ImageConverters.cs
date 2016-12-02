using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using FormsControlDemo.Utilities;

namespace FormsControlDemo.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                return default(ImageSource);
            }
            return ImageSourceUtility.GetEmbeddedImageSource(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

   
    ///// <summary>
    ///// 講師写真用コンバータ
    ///// </summary>
    //public class SpeakerPhotoConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        var source = ImageSourceUtility.GetEmbeddedImageSource("JMAS.MicrosoftForesight.Images.sessions_np.jpg");
    //        if (value == null)
    //        {
    //            return source;
    //        }
    //        else
    //        {
    //            return ImageSource.FromUri(new Uri(string.Format("http://microsoft-events.jp/assets/img/msforesight/detail/session/{0}", value)));
    //        }
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    ///// <summary>
    ///// 講師写真用コンバータ(常にデフォルト画像)
    ///// </summary>
    //public class SpeakerDefaultImgConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return ImageSourceUtility.GetEmbeddedImageSource("JMAS.MicrosoftForesight.Images.sessions_np.jpg");
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    /// <summary>
    /// メニューアイテムボタン背景色用コンバータ
    /// </summary>
    public class MenuItemBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (bool)value)
            {
                return Color.FromHex("4D000000");
            }
            else
            {
                return Color.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
