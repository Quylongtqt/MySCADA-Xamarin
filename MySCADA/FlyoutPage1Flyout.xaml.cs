using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1Flyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPage1Flyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPage1FlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutPage1FlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPage1FlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPage1FlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPage1FlyoutMenuItem>(new[]
                {
                    new FlyoutPage1FlyoutMenuItem {Type=typeof(MainPage), Id = 0, Title = "Main Control 1" },
                    new FlyoutPage1FlyoutMenuItem {Type=typeof(MOTOR), Id = 1, Title = "Motor 1" },
                    new FlyoutPage1FlyoutMenuItem {Type=typeof(MOTOR), Id = 2, Title = "Motor 2" },
                    new FlyoutPage1FlyoutMenuItem {Type=typeof(MOTOR), Id = 3, Title = "Motor 3" },
                    new FlyoutPage1FlyoutMenuItem {Type=typeof(TrendView), Id = 4, Title = "Trend" },
                    new FlyoutPage1FlyoutMenuItem {Type=typeof(AlarmView), Id = 5, Title = "Alarm" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}