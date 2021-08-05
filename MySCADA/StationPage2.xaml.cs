using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StationPage2 : FlyoutPage
    {
        int ID;
        public SCADA Parent;
        public StationPage2()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as StationPage2FlyoutMenuItem;
            if (item == null)
                return;

            if (item.Id == 0)
            {
                Navigation.PushAsync((Page)App.Root.Motor_Faceplate[3]);
            }
            else if (item.Id == 1)
            {
                Navigation.PushAsync((Page)App.Root.Motor_Faceplate[4]);
            }
            else if (item.Id == 2)
            {
                Navigation.PushAsync((Page)App.Root.Trend[0]);
            }
            else if (item.Id == 3)
            {
                Navigation.PushAsync((Page)App.Root.Alarm[0]);
            }
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}