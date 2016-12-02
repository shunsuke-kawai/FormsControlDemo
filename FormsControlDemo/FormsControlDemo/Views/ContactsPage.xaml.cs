using FormsControlDemo.Models;
using Newtonsoft.Json;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsControlDemo.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();

            var assembly = typeof(ContactsPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("FormsControlDemo.SampleDatas.ContactsData.json");

            Contact[] contacts;

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var rootobject = JsonConvert.DeserializeObject<Rootobject>(json);

                contacts = rootobject.Contacts;
            }

            var grouped = new ObservableCollection<ContactsGroupModel>(
                contacts.OrderBy(g => g.Name).GroupBy(n => new { n.NameHead })
                .Select(g => new ContactsGroupModel(g) { FirstInitial = g.ToArray()[0].NameHead })
                .OrderBy(g => g.FirstInitial));

            ContactsListView.ItemsSource = grouped;
        }

        ICommand _refreshCommand;
        public ICommand RefreshCommand =>
        _refreshCommand ?? (_refreshCommand = new Command(() => ExecuteLoadSessions()));

        private void ExecuteLoadSessions()
        {

            var assembly = typeof(ContactsPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("FormsControlDemo.SampleDatas.ContactsData.json");

            Contact[] contacts;

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var rootobject = JsonConvert.DeserializeObject<Rootobject>(json);

                contacts = rootobject.Contacts;
            }

            var grouped = new ObservableCollection<ContactsGroupModel>(
                contacts.OrderBy(g => g.Name).GroupBy(n => new { n.NameHead })
                .Select(g => new ContactsGroupModel(g) { FirstInitial = g.ToArray()[0].NameHead })
                .OrderBy(g => g.FirstInitial));

            ContactsListView.ItemsSource = grouped;
        }

        private async void ContactsListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if ((Contact)args.SelectedItem != null)
            {

                // Make Phone Call
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                {
                    phoneDialer.MakePhoneCall(((Contact)args.SelectedItem).Phone);
                }
                else
                {
                    await DisplayAlert("PhoneCall Not Supported", "電話機能を使用することができません。", "OK");
                }

                ContactsListView.SelectedItem = null;
            }
        }
    }
}
