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
    public partial class FlyoutPage1 : FlyoutPage
    {
        int ID;
        public SCADA Parent;
        public FlyoutPage1()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutPage1FlyoutMenuItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.Type);
            //page.Title = item.Title;
            if (item.Id == 0)
            {
                //Detail =  (Page)App.Root.Main[0];
                Navigation.PushAsync((Page)App.Root.Main[0]);
            }

            else if (item.Id == 1)
            {
                Navigation.PushAsync((Page)App.Root.Motor_Faceplate[0]);
            }
            else if (item.Id == 2)
            {
                Navigation.PushAsync((Page)App.Root.Motor_Faceplate[1]);
            }
            else if (item.Id == 3)
            {
                Navigation.PushAsync((Page)App.Root.Motor_Faceplate[2]);
            }
            else if (item.Id == 4)
            {
                Navigation.PushAsync((Page)App.Root.Trend[0]);
            }
            else if (item.Id == 5)
            {
                Navigation.PushAsync((Page)App.Root.Alarm[0]);
            }
            else if (item.Id == 6)
            {
                Navigation.PushAsync((Page)App.Root.Map[0]);
            }
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}