using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;

namespace MySCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        int ID;
        public SCADA Parent;
        public MapPage()
        {
            InitializeComponent();

            Pin pinTram1 = new Pin()
            {
                Type = PinType.Place,
                Label = "Trạm sông Tắc",
                Address = "Quận 9, HCM",
                Position = new Position(10.8397d, 106.8523d),
                Rotation = 0.0f,
                Tag = "id_1",

            };
            Pin pinTram2 = new Pin()
            {
                Type = PinType.Place,
                Label = "Trạm Gò Công",
                Address = "Quận 9, HCM",
                Position = new Position(10.8319d, 106.8357d),
                Rotation = 0.0f,
                Tag = "id_2",

            };
            Pin pinTram3 = new Pin()
            {
                Type = PinType.Place,
                Label = "Trạm Trau Trảu",
                Address = "Quận 9, HCM",
                Position = new Position(10.8276d, 106.835d),
                Rotation = 0.0f,
                Tag = "id_3",

            };

            map.Pins.Add(pinTram1);
            map.Pins.Add(pinTram2);
            map.Pins.Add(pinTram3);
            
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinTram1.Position, Distance.FromMeters(4000)));

            map.InfoWindowClicked += Map_InfoWindowClicked;
            
        }

        public void Map_InfoWindowClicked(object sender, InfoWindowClickedEventArgs e)
        {
            if(e.Pin.Tag.ToString() == "id_1")
            {
                Navigation.PushAsync((Page)App.Root.Station[0]);
            }
            if (e.Pin.Tag.ToString() == "id_2")
            {
                Navigation.PushAsync((Page)App.Root.Station2[0]);
            }
            if (e.Pin.Tag.ToString() == "id_3")
            {
                Navigation.PushAsync((Page)App.Root.Station2[0]);
            }
        }
    }
    
}