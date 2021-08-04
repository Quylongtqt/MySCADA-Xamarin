using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MySCADA
{
    public partial class MainPage : ContentPage
    {
        int ID;
        public SCADA Parent;

        public MainPage()
        {

            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task task = Parent.FindTask("Task_1");
                    Tag tag;

                    if (task != null)
                    {
                        tag = task.FindTag("Motor_1_RunFeedback");
                        if (tag != null)
                        {

                            if (Convert.ToBoolean(tag.Value))
                                iName1.Source = "MotorON.png";
                            else iName1.Source = "Motor.png";
                        }
                        tag = task.FindTag("Motor_2_RunFeedback");
                        if (tag != null)
                        {

                            if (Convert.ToBoolean(tag.Value))
                                iName2.Source = "MotorON.png";
                            else iName2.Source = "Motor.png";
                        }
                        tag = task.FindTag("Valve_RunFeedback");
                        if (tag != null)
                        {

                            if (Convert.ToBoolean(tag.Value))
                                iName3.Source = "MotorON.png";
                            else iName3.Source = "Motor.png";
                        }

                    }




                    Task task3 = Parent.FindTask("Task_2");
                    Tag tag3;
                    if (task3 != null)
                    {

                        tag3 = task3.FindTag("level");
                        if (tag3 != null)
                        {
                            lName.Text = Convert.ToString(tag3.Value);
                            pName.Progress = Convert.ToDouble(tag3.Value) / 100d;
                        }


                    }



                    // interact with UI elements
                });
                return true; // runs again, or false to stop
            });
        }

        private void bOnName_Clicked(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool("M0.0", true);
            Parent.S71500.WriteBool("M0.0", false);
        }



        private void bOffName_Clicked(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool("M0.1", true);
            Parent.S71500.WriteBool("M0.1", false);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync((Page)App.Root.Motor_Faceplate[0]);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync((Page)App.Root.Motor_Faceplate[1]);
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushAsync((Page)App.Root.Motor_Faceplate[2]);
        }
    }
}