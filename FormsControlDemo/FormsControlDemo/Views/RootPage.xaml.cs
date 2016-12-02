using FormsControlDemo.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsControlDemo.Views
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();

            menuPage.ListView.ItemSelected += OnItemSelected;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = e.SelectedItem as MasterPageItemModel;
                if (item != null)
                {
                    IsPresented = false;
                    if (Device.OS == TargetPlatform.Android) await Task.Delay(300);
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
