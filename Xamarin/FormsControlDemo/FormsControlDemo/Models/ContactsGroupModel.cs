using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FormsControlDemo.Models
{
    public class ContactsGroupModel: ObservableCollection<Contact>
    {
        public string FirstInitial { get; set; }
        public string IconSource { get; set; }
        public ContactsGroupModel(IEnumerable<Contact> contact) : base(contact) { }
    }
}
