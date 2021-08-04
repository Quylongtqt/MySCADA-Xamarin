using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MySCADA
{
    public class SCADA
    {
        ArrayList Tasks = new ArrayList();
        ArrayList Displays = new ArrayList();
        public ArrayList Main = new ArrayList();
        public ArrayList Trend = new ArrayList();
        public ArrayList Alarm = new ArrayList();
        public ArrayList Motor_Faceplate = new ArrayList();
        public ArrayList Valve_Faceplate = new ArrayList();
        public ArrayList Map = new ArrayList();
        public ArrayList Station = new ArrayList();

        public PLC S71500;

        public void AddTask(Task task)
        {
            task.Parent = this;
            Tasks.Add(task);
        }
        public void AddFaceplate(MOTOR fpl)
        {
            fpl.Parent = this;
            Motor_Faceplate.Add(fpl);
        }
        public void AddMainView(MainPage fpl)
        {
            fpl.Parent = this;
            Main.Add(fpl);
        }
        public void AddMapView(MapPage fpl)
        {
            fpl.Parent = this;
            Map.Add(fpl);
        }
        public void AddStationView(FlyoutPage1 fpl)
        {
            fpl.Parent = this;
            Station.Add(fpl);
        }
        public void AddTrendView(TrendView fpl)
        {
            fpl.Parent = this;
            Trend.Add(fpl);
        }
        public void AddAlarmView(AlarmView fpl)
        {
            fpl.Parent = this;
            Alarm.Add(fpl);
        }

        public void AddPLC(PLC plc)
        {
            plc.Parent = this;
            S71500 = plc;
        }

        public Task FindTask(string name)
        {
            Task task = null;
            for (int i = 0; i < Tasks.Count; i++)
            {
                task = (Task)Tasks[i];
                if (task.Name == name)
                    return task;
            }

            return null;
        }

        public void RunTask(string name)
        {
            Task task = null;
            for (int i = 0; i < Tasks.Count; i++)
            {
                task = (Task)Tasks[i];
                if (task.Name == name)
                    task.Engine();
            }
        }

        public void SleepTask(string name)
        {
            Task task = null;
            for (int i = 0; i < Tasks.Count; i++)
            {
                task = (Task)Tasks[i];
                if (task.Name == name)
                    task.Sleep();
            }
        }

        public void ResumeTask(string name)
        {
            Task task = null;
            for (int i = 0; i < Tasks.Count; i++)
            {
                task = (Task)Tasks[i];
                if (task.Name == name)
                    task.Resume();
            }
        }

        public void KillTask(string name)
        {
            Task task = null;
            for (int i = 0; i < Tasks.Count; i++)
            {
                task = (Task)Tasks[i];
                if (task.Name == name)
                    task.Kill();
            }
        }


    }
}
