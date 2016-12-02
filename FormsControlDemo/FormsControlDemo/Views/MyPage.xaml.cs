using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsControlDemo.Views
{
    public partial class MyPage : TabbedPage
    {
        public MyPage()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
            {
                profile.Icon = "profile_n.png";
                contacts.Icon = "address_n.png";
            }
        }
    }
}
