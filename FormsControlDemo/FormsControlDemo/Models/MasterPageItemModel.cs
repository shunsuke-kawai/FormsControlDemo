using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsControlDemo.Models
{
    public class MasterPageItemModel
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }

        public bool IsShowSeparator { get; set; } = false;
    }


    public class MasterPageGroupModel : ObservableCollection<MasterPageItemModel>
    {
        private Color _groupHeaderColor = Color.FromRgba(0, 32, 80, 255);
        public Color GroupHeaderColor
        {
            get
            {
                return this._groupHeaderColor;
            }
            set
            {
                _groupHeaderColor = value;
                //OnPropertyChanged();
            }
        }
        public MasterPageGroupModel(Color headerColor)
        {
            GroupHeaderColor = headerColor;
        }
    }
}
