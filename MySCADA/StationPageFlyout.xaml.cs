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
    public partial class StationPageFlyout : ContentPage
    {
        public ListView ListView;

        public StationPageFlyout()
        {
            InitializeComponent();

            BindingContext = new StationPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class StationPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<StationPageFlyoutMenuItem> MenuItems { get; set; }

            public StationPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<StationPageFlyoutMenuItem>(new[]
                {
                    new StationPageFlyoutMenuItem {Type=typeof(MOTOR), Id = 0, Title = "Motor 1" },
                    new StationPageFlyoutMenuItem {Type=typeof(MOTOR), Id = 1, Title = "Motor 2" },
                    new StationPageFlyoutMenuItem {Type=typeof(MOTOR), Id = 2, Title = "Motor 3" },
                    new StationPageFlyoutMenuItem {Type=typeof(TrendView), Id = 3, Title = "Trend" },
                    new StationPageFlyoutMenuItem {Type=typeof(AlarmView), Id = 4, Title = "Alarm" },
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