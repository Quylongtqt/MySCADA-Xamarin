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
    public partial class StationPage2Detail : ContentPage
    {
        public StationPage2Detail()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task task5 = App.Root.FindTask("Task_5");
                    Tag tag;

                    if (task5 != null)
                    {
                        tag = task5.FindTag("Motor_4_RunFeedback");
                        if (tag != null)
                        {
                            if (Convert.ToBoolean(tag.Value))
                                iName1.Source = "MotorON.png";
                            else iName1.Source = "Motor.png";
                        }
                        tag = task5.FindTag("Motor_5_RunFeedback");
                        if (tag != null)
                        {
                            if (Convert.ToBoolean(tag.Value))
                                iName2.Source = "MotorON.png";
                            else iName2.Source = "Motor.png";
                        }

                    }

                    Task task6 = App.Root.FindTask("Task_2");
                    Tag tag1;
                    if (task6 != null)
                    {
                        tag1 = task6.FindTag("level");
                        if (tag1 != null)
                        {
                            lName.Text = Convert.ToString(tag1.Value);
                            pName.Progress = Convert.ToDouble(tag1.Value) / 100d;
                        }
                    }

                    // interact with UI elements
                });
                return true; // runs again, or false to stop
            });
        }
        private void bOnName_Clicked(object sender, EventArgs e)
        {
            App.Root.S71500.WriteBool("M0.0", true);
            App.Root.S71500.WriteBool("M0.0", false);
        }

        private void bOffName_Clicked(object sender, EventArgs e)
        {
            App.Root.S71500.WriteBool("M0.1", true);
            App.Root.S71500.WriteBool("M0.1", false);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync((Page)App.Root.Motor_Faceplate[3]);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync((Page)App.Root.Motor_Faceplate[4]);
        }

    }
}