
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


            // Init Map:
            MapPage mapPage = new MapPage();

            // SCADA:

            Root = new SCADA();
            PLC plc = new PLC();
            Root.AddPLC(plc);

            // Trạm 1: Quản lý 3 motor 1, 2, 3
            // --- Task 1 -> Control
            // --- Task 2 -> Pressure Level 1
            // --- Task 3 -> Trend 1
            // --- Task 4 -> Alarm 1


            Task Task1 = new Task("Task_1", 100);
            Task Task2 = new Task("Task_2", 100);
            Task Task3 = new Task("Task_3", 1000);
            Task Task4 = new Task("Task_4", 100);

            Tag Motor_1_Mode = new Tag("Motor_1_Mode", "Motor_1.Mode");
            Tag Motor_2_Mode = new Tag("Motor_2_Mode", "Motor_2.Mode");
            Tag Motor_3_Mode = new Tag("Motor_3_Mode", "Motor_3.Mode");

            Tag Motor_1_Start = new Tag("Motor_1_Start", "Motor_1.Start");
            Tag Motor_2_Start = new Tag("Motor_2_Start", "Motor_2.Start");
            Tag Motor_3_Start = new Tag("Motor_3_Start", "Motor_3.Start");

            Tag Motor_1_Stop = new Tag("Motor_1_Stop", "Motor_1.Stop");
            Tag Motor_2_Stop = new Tag("Motor_2_Stop", "Motor_2.Stop");
            Tag Motor_3_Stop = new Tag("Motor_3_Stop", "Motor_3.Stop");

            Tag Motor_1_RunFeedback = new Tag("Motor_1_RunFeedback", "Motor_1.RunFeedback");
            Tag Motor_2_RunFeedback = new Tag("Motor_2_RunFeedback", "Motor_2.RunFeedback");
            Tag Motor_3_RunFeedback = new Tag("Motor_3_RunFeedback", "Motor_3.RunFeedback");

            Tag Motor_1_Reset = new Tag("Motor_1_Reset", "Motor_1.Reset");
            Tag Motor_2_Reset = new Tag("Motor_2_Reset", "Motor_2.Reset");
            Tag Motor_3_Reset = new Tag("Motor_3_Reset", "Motor_3.Reset");

            Tag Motor_1_Fault = new Tag("Motor_1_Fault", "Motor_1.Fault");
            Tag Motor_2_Fault = new Tag("Motor_2_Fault", "Motor_2.Fault");
            Tag Motor_3_Fault = new Tag("Motor_3_Fault", "Motor_3.Fault");

            Tag Motor_1_Pos = new Tag("Motor_1_Pos", "Motor_1.Pos");
            Tag Motor_2_Pos = new Tag("Motor_2_Pos", "Motor_2.Pos");
            Tag Motor_3_Pos = new Tag("Motor_3_Pos", "Motor_3.Pos");

            Tag level = new Tag("level", "level.Value");

            Tag History = new Tag("History", "History.Value");

            Tag Alarm = new Tag("Alarm", "Alarm.Value");

            // Task 1: Motor 1, 2, 3
            Task1.AddTag(Motor_1_Mode);
            Task1.AddTag(Motor_2_Mode);
            Task1.AddTag(Motor_3_Mode);

            Task1.AddTag(Motor_1_Start);
            Task1.AddTag(Motor_2_Start);
            Task1.AddTag(Motor_3_Start);

            Task1.AddTag(Motor_1_Stop);
            Task1.AddTag(Motor_2_Stop);
            Task1.AddTag(Motor_3_Stop);

            Task1.AddTag(Motor_1_RunFeedback);
            Task1.AddTag(Motor_2_RunFeedback);
            Task1.AddTag(Motor_3_RunFeedback);

            Task1.AddTag(Motor_1_Reset);
            Task1.AddTag(Motor_2_Reset);
            Task1.AddTag(Motor_3_Reset);

            Task1.AddTag(Motor_1_Fault);
            Task1.AddTag(Motor_2_Fault);
            Task1.AddTag(Motor_3_Fault);

            Task1.AddTag(Motor_1_Pos);
            Task1.AddTag(Motor_2_Pos);
            Task1.AddTag(Motor_3_Pos);

            // Task 2: Pressure Level 1
            Task2.AddTag(level);

            // Task 3: Trend 1
            Task3.AddTag(History);

            // Task 4: Alarm 1
            Task4.AddTag(Alarm);

            // Add Task
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
            MOTOR Motor_3_Faceplate = new MOTOR(3);

            StationPage stationView = new StationPage();
            TrendView trendView = new TrendView();
            AlarmView alarmView = new AlarmView();
            

            Root.AddFaceplate(Motor_1_Faceplate);
            Root.AddFaceplate(Motor_2_Faceplate);
            Root.AddFaceplate(Motor_3_Faceplate);
            
            Root.AddStationView(stationView);
            Root.AddTrendView(trendView);
            Root.AddAlarmView(alarmView);


            // Trạm 2 : Quản lý 2 motor 4, 5
            // --- Task 5 -> Control
            // --- Task 6 -> Pressure Level 2
            // --- Task 7 -> Trend 2
            // --- Task 8 -> Alarm 2

            Task Task5 = new Task("Task_5", 100);
            Task Task6 = new Task("Task_6", 100);
            Task Task7 = new Task("Task_7", 1000);
            Task Task8 = new Task("Task_8", 100);

            Tag Motor_4_Mode = new Tag("Motor_4_Mode", "Motor_4.Mode");
            Tag Motor_5_Mode = new Tag("Motor_5_Mode", "Motor_5.Mode");

            Tag Motor_4_Start = new Tag("Motor_4_Start", "Motor_4.Start");
            Tag Motor_5_Start = new Tag("Motor_5_Start", "Motor_5.Start");

            Tag Motor_4_Stop = new Tag("Motor_4_Stop", "Motor_4.Stop");
            Tag Motor_5_Stop = new Tag("Motor_5_Stop", "Motor_5.Stop");

            Tag Motor_4_RunFeedback = new Tag("Motor_4_RunFeedback", "Motor_4.RunFeedback");
            Tag Motor_5_RunFeedback = new Tag("Motor_5_RunFeedback", "Motor_5.RunFeedback");

            Tag Motor_4_Reset = new Tag("Motor_4_Reset", "Motor_4.Reset");
            Tag Motor_5_Reset = new Tag("Motor_5_Reset", "Motor_5.Reset");

            Tag Motor_4_Fault = new Tag("Motor_4_Fault", "Motor_4.Fault");
            Tag Motor_5_Fault = new Tag("Motor_5_Fault", "Motor_5.Fault");

            Tag level_2 = new Tag("level_2", "level_2.Value");

            Tag History_2 = new Tag("History_2", "History_2.Value");

            Tag Alarm_2 = new Tag("Alarm_2", "Alarm.Value");

            // Task 5: Motor 3, 4
            Task5.AddTag(Motor_4_Mode);
            Task5.AddTag(Motor_5_Mode);
            Task5.AddTag(Motor_4_Start);
            Task5.AddTag(Motor_5_Start);
            Task5.AddTag(Motor_4_Stop);
            Task5.AddTag(Motor_5_Stop);
            Task5.AddTag(Motor_4_RunFeedback);
            Task5.AddTag(Motor_5_RunFeedback);
            Task5.AddTag(Motor_4_Reset);
            Task5.AddTag(Motor_5_Reset);
            Task5.AddTag(Motor_4_Fault);
            Task5.AddTag(Motor_5_Fault);

            // Task 6: Level
            Task6.AddTag(level_2);

            // Task 7: Trend
            Task7.AddTag(History_2);

            // Task 8: Alarm
            Task8.AddTag(Alarm_2);

            // Add Task
            Root.AddTask(Task5);
            Root.AddTask(Task6);
            Root.AddTask(Task7);
            Root.AddTask(Task8);

            Root.RunTask("Task_5");
            Root.RunTask("Task_6");
            Root.RunTask("Task_7");
            Root.RunTask("Task_8");

            MOTOR Motor_4_Faceplate = new MOTOR(4);
            MOTOR Motor_5_Faceplate = new MOTOR(5);

            StationPage2 stationView_2 = new StationPage2();
            TrendView2 trendView_2 = new TrendView2();
            AlarmView alarmView_2 = new AlarmView();


            Root.AddFaceplate(Motor_4_Faceplate);
            Root.AddFaceplate(Motor_5_Faceplate);

            Root.AddStation2View(stationView_2);
            Root.AddTrend2View(trendView_2);
            Root.AddAlarmView(alarmView_2);

            //////////////// Home page //////////////////////
            Root.AddMapView(mapPage);
            MainPage = new NavigationPage(mapPage);
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
