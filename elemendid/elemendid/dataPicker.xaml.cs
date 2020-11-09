using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Picker = Xamarin.Forms.Picker;
using DatePicker = Xamarin.Forms.DatePicker;
using Entry = Xamarin.Forms.Entry;
namespace elemendid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class dataPicker : ContentPage
    {
        Picker pick;
        Editor editor;
        DatePicker dpicker;
        Entry entry;

        public dataPicker()
        {
            Grid gr = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },

                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                }
            };

            pick = new Xamarin.Forms.Picker 
            {
                Title = "keeld"
            };
            pick.Items.Add("C#");
            pick.Items.Add("python");
            pick.Items.Add("C++");
            pick.Items.Add("VisualBasic");
            pick.Items.Add("Java");

            gr.Children.Add(pick, 0, 0);
            pick.SelectedIndexChanged += Pick_SelectedIndexChanged;

            editor = new Editor { Placeholder = "vali keel" };

            editor = new Editor { Placeholder = "vali keel nimekirjas" };
            gr.Children.Add(editor, 1, 0);

            dpicker = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-10),
                MaximumDate = DateTime.Now.AddDays(10),
            };
            dpicker.DateSelected += Dpicker_DateSelected;
            gr.Children.Add(dpicker, 1, 1);

            entry = new Entry { Text = "vali kuupäev"}
            Content = gr;

        }

        private void Pick_SelectedIndexChanged(object sender, EventArgs e)
        {
            editor.Text = "TEXT" + pick.Items[pick.SelectedIndex];
        }

    }
}