﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage2 : ContentPage
    {
        int ID;
        public SCADA Parent;

        public MainPage2()
        {

            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task task = Parent.FindTask("Task_5");
                    Tag tag;

                    if (task != null)
                    {
                        tag = task.FindTag("Motor_3_RunFeedback");
                        if (tag != null)
                        {

                            if (Convert.ToBoolean(tag.Value))
                                iName1.Source = "MotorON.png";
                            else iName1.Source = "Motor.png";
                        }
                        tag = task.FindTag("Valve_2_RunFeedback");
                        if (tag != null)
                        {

                            if (Convert.ToBoolean(tag.Value))
                                iName2.Source = "MotorON.png";
                            else iName2.Source = "Motor.png";
                        }


                    }


                    Task task6 = Parent.FindTask("Task_6");
                    Tag tag6;
                    if (task6 != null)
                    {

                        tag6 = task6.FindTag("level");
                        if (tag6 != null)
                        {
                            lName.Text = Convert.ToString(tag6.Value);
                            pName.Progress = Convert.ToDouble(tag6.Value) / 100d;
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
    }
}