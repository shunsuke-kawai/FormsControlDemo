using System;   
using System.Reflection;
using Xamarin.Forms;
namespace FormsControlDemo.Utilities
{
    public static class ImageSourceUtility
    {
        /// <summary>
        /// 埋め込みリソースの画像のSourceを取得
        /// </summary>
        /// <param name="path">namespaceを含むファイルパス</param>
        /// <example>JMAS.MicrosoftForesight.Images.XXXX.png</example>
        /// <returns>埋め込みリソースの画像のSource</returns>
        public static ImageSource GetEmbeddedImageSource(string path)
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                return ImageSource.FromResource(path);
            }
            else
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                return ImageSource.FromResource(path, assembly);
            }
        }
    }
}
