using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsControlDemo.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.Windows)
            {
                swcThemeAll.Effects.Add(Effect.Resolve("Xamarin.MultiSelectToggleSwitchEffect"));
            }

            imgPhoto.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName != nameof(imgPhoto.IsLoading))
                    return;
                prgPickPhoto.IsRunning = imgPhoto.IsLoading;
                prgPickPhoto.IsVisible = imgPhoto.IsLoading;
            };
        }

        private async void OnImageTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var action = await DisplayActionSheet("プロフィール写真を変更", "キャンセル", null, "写真を撮る", "ライブラリから選択");
            if (action == "ライブラリから選択")
            {

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync();


                if (file == null)
                    return;

                imgPhoto.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
            else if (action == "写真を撮る")
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {

                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                //DisplayAlert("File Location", file.Path, "OK");

                imgPhoto.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }

        }

        private async void ButtonClicked(object sender, EventArgs args)
        {
            await DisplayAlert("完了", "保存しました", "OK");

        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var layout = ((Element)sender).Parent as Layout<View>;
            if (layout == null) return;

            foreach (var child in layout.Children)
            {
                var swc = child as Switch;
                if (swc == null) continue;

                if (swc.IsEnabled == false) break;

                swc.IsToggled = !swc.IsToggled;
                break;
            }
        }
    }
}
