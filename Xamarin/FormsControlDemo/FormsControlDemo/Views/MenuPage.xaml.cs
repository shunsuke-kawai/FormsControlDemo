using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Xamarin.Forms;
using FormsControlDemo.Models;

namespace FormsControlDemo.Views
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MenuPage()
        {
            InitializeComponent();


            var menuList = new ObservableCollection<MasterPageItemModel>()
            {
                new MasterPageItemModel { Title = "マイページ", IconSource = "FormsControlDemo.Images.icon01_mypage.png", TargetType = typeof(MyPage) },
                new MasterPageItemModel { Title = "お知らせ", IconSource = "FormsControlDemo.Images.icon12_news.png", TargetType = typeof(MyPage) },
                new MasterPageItemModel { Title = "ファイル", IconSource = "FormsControlDemo.Images.icon08_enquete.png", TargetType = typeof(MyPage) },
                new MasterPageItemModel { Title = "設定", IconSource = "FormsControlDemo.Images.icon13_setting.png", TargetType = typeof(MyPage)},
            };

            listView.ItemsSource = menuList;
            listView.SelectedItem = ((ObservableCollection<MasterPageItemModel>)listView.ItemsSource)[0];
        }
    }
}
