using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsControlDemo.Models
{
    public class Rootobject
    {
        public Contact[] Contacts { get; set; }
    }

    public class Contact
    {
        public string NameHead
        {
            get
            {
                return Name.Substring(0, 1);
            }
        }
        public string Phone { get; set; }
        public string IconSource { get; set; }
        public string Name { get; set; }
    }
}
