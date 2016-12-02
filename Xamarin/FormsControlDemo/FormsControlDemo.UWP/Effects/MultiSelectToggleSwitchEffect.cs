using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormsControlDemo.UWP.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MultiSelectToggleSwitchEffect), "MultiSelectToggleSwitchEffect")]
namespace FormsControlDemo.UWP.Effects
{
    public class MultiSelectToggleSwitchEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var toggleSwitch = Control as Windows.UI.Xaml.Controls.ToggleSwitch;

            if (toggleSwitch == null) { return; }

            toggleSwitch.OnContent = string.Empty;
            toggleSwitch.OffContent = string.Empty;
        }

        protected override void OnDetached()
        {

        }
    }
}
