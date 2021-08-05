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
    public partial class StationPage2Flyout : ContentPage
    {
        public ListView ListView;

        public StationPage2Flyout()
        {
            InitializeComponent();

            BindingContext = new StationPage2FlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class StationPage2FlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<StationPage2FlyoutMenuItem> MenuItems { get; set; }

            public StationPage2FlyoutViewModel()
            {
                MenuItems = new ObservableCollection<StationPage2FlyoutMenuItem>(new[]
                {
                    new StationPage2FlyoutMenuItem {Type=typeof(MOTOR), Id = 0, Title = "Motor 4" },
                    new StationPage2FlyoutMenuItem {Type=typeof(MOTOR), Id = 1, Title = "Motor 5" },
                    new StationPage2FlyoutMenuItem {Type=typeof(TrendView), Id = 2, Title = "Trend" },
                    new StationPage2FlyoutMenuItem {Type=typeof(AlarmView), Id = 3, Title = "Alarm" },
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