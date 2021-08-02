
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySCADA
{
    public partial class App : Application
    {
        static public SCADA Root = null;
        public App()
        {
            InitializeComponent();

            Root = new SCADA();

            PLC plc = new PLC();
            Root.AddPLC(plc);

            Task Task1 = new Task("Task_1", 100);
            Task Task2 = new Task("Task_2", 100);
            Task Task3 = new Task("Task_3", 1000);
            Task Task4 = new Task("Task_4", 100);

            Tag Motor_1_Mode = new Tag("Motor_1_Mode", "Motor_1.Mode");
            Tag Motor_2_Mode = new Tag("Motor_2_Mode", "Motor_2.Mode");
            Tag Valve_Mode = new Tag("Valve_Mode", "Valve.Mode");

            Tag Motor_1_Start = new Tag("Motor_1_Start", "Motor_1.Start");
            Tag Motor_2_Start = new Tag("Motor_2_Start", "Motor_2.Start");
            Tag Valve_Start = new Tag("Valve_Start", "Valve.Start");

            Tag Motor_1_Stop = new Tag("Motor_1_Stop", "Motor_1.Stop");
            Tag Motor_2_Stop = new Tag("Motor_2_Stop", "Motor_2.Stop");
            Tag Valve_Stop = new Tag("Valve_Stop", "Valve.Stop");

            Tag Motor_1_RunFeedback = new Tag("Motor_1_RunFeedback", "Motor_1.RunFeedback");
            Tag Motor_2_RunFeedback = new Tag("Motor_2_RunFeedback", "Motor_2.RunFeedback");
            Tag Valve_RunFeedback = new Tag("Valve_RunFeedback", "Valve.RunFeedback");

            Tag Motor_1_Reset = new Tag("Motor_1_Reset", "Motor_1.Reset");
            Tag Motor_2_Reset = new Tag("Motor_2_Reset", "Motor_2.Reset");
            Tag Valve_Reset = new Tag("Valve_Reset", "Valve.Reset");

            Tag Motor_1_Fault = new Tag("Motor_1_Fault", "Motor_1.Fault");
            Tag Motor_2_Fault = new Tag("Motor_2_Fault", "Motor_2.Fault");
            Tag Valve_Fault = new Tag("Valve_Fault", "Valve.Fault");

            Tag Motor_1_Pos = new Tag("Motor_1_Pos", "Motor_1.Pos");
            Tag Motor_2_Pos = new Tag("Motor_2_Pos", "Motor_2.Pos");
            Tag Valve_Pos = new Tag("Valve_Pos", "Valve.Pos");

            Tag level = new Tag("level", "level.Value");

            Tag History = new Tag("History", "History.Value");

            Tag Alarm = new Tag("Alarm", "Alarm.Value");

            Task1.AddTag(Motor_1_Mode);
            Task1.AddTag(Motor_2_Mode);
            Task1.AddTag(Valve_Mode);

            Task1.AddTag(Motor_1_Start);
            Task1.AddTag(Motor_2_Start);
            Task1.AddTag(Valve_Start);

            Task1.AddTag(Motor_1_Stop);
            Task1.AddTag(Motor_2_Stop);
            Task1.AddTag(Valve_Stop);

            Task1.AddTag(Motor_1_RunFeedback);
            Task1.AddTag(Motor_2_RunFeedback);
            Task1.AddTag(Valve_RunFeedback);

            Task1.AddTag(Motor_1_Reset);
            Task1.AddTag(Motor_2_Reset);
            Task1.AddTag(Valve_Reset);

            Task1.AddTag(Motor_1_Fault);
            Task1.AddTag(Motor_2_Fault);
            Task1.AddTag(Valve_Fault);

            Task1.AddTag(Motor_1_Pos);
            Task1.AddTag(Motor_2_Pos);
            Task1.AddTag(Valve_Pos);

            Task2.AddTag(level);

            Task3.AddTag(History);
            Task4.AddTag(Alarm);

            Root.AddTask(Task1);
            Root.AddTask(Task2);
            Root.AddTask(Task3);
            Root.AddTask(Task4);

            Root.RunTask("Task_1");
            Root.RunTask("Task_2");
            Root.RunTask("Task_3");
            Root.RunTask("Task_4");
            MOTOR Motor_1_Faceplate = new MOTOR(1);
            MOTOR Motor_2_Faceplate = new MOTOR(2);
            MOTOR Valve_Faceplate = new MOTOR(3);

            MainPage mainPage = new MainPage();
            TrendView trendView = new TrendView();
            AlarmView alarmView = new AlarmView();

            Root.AddFaceplate(Motor_1_Faceplate);
            Root.AddFaceplate(Motor_2_Faceplate);
            Root.AddFaceplate(Valve_Faceplate);
            Root.AddMainView(mainPage);
            Root.AddTrendView(trendView);
            Root.AddAlarmView(alarmView);
            MainPage = new NavigationPage(new FlyoutPage1());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
