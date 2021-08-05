using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MySCADA
{
    public class Task
    {
        public string Name;
        int Period;
        System.Timers.Timer UpdateTimer = null;
        public ArrayList Tags = new ArrayList();

        public SCADA Parent = null;
        public int[] aHistory = new int[100];
        public int position = 0;
        public Task(string name, int period)
        {
            Name = name;
            Period = period;
        }

        public void AddTag(Tag tag)
        {
            tag.Parent = this;
            Tags.Add(tag);
        }

        public Tag FindTag(string name)
        {
            Tag tag = null;
            for (int i = 0; i < Tags.Count; i++)
            {
                tag = (Tag)Tags[i];
                if (tag.Name == name)
                    return tag;
            }

            return null;
        }

        public void Engine()
        {
            UpdateTimer = new System.Timers.Timer(Period);
            UpdateTimer.AutoReset = true;
            UpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateTags);
            UpdateTimer.Start();
        }

        void UpdateTags(object sender, System.Timers.ElapsedEventArgs e)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                Tag tag = (Tag)Tags[i];

                string[] temp = tag.Address.Split('.');
                string obj = temp[0];
                string signal = temp[1];
                switch (obj)
                {
                    case "Motor_1":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.Motor_1.Mode;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.Motor_1.Start;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.Motor_1.Stop;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "RunFeedback":
                                tag.Value = Parent.S71500.Motor_1.RunFeedback;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Reset":
                                tag.Value = Parent.S71500.Motor_1.Reset;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Fault":
                                tag.Value = Parent.S71500.Motor_1.Fault;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Pos":
                                tag.Value = Parent.S71500.Motor_1.Pos;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }
                        break;
                    case "Motor_2":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.Motor_2.Mode;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.Motor_2.Start;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.Motor_2.Stop;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "RunFeedback":
                                tag.Value = Parent.S71500.Motor_2.RunFeedback;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Reset":
                                tag.Value = Parent.S71500.Motor_2.Reset;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Fault":
                                tag.Value = Parent.S71500.Motor_2.Fault;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Pos":
                                tag.Value = Parent.S71500.Motor_2.Pos;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }
                        break;
                    case "Motor_3":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.Motor_3.Mode;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.Motor_3.Start;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.Motor_3.Stop;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "RunFeedback":
                                tag.Value = Parent.S71500.Motor_3.RunFeedback;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Reset":
                                tag.Value = Parent.S71500.Motor_3.Reset;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Fault":
                                tag.Value = Parent.S71500.Motor_3.Fault;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Pos":
                                tag.Value = Parent.S71500.Motor_3.Pos;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }

                        break;
                    case "Motor_4":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.Motor_4.Mode;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.Motor_4.Start;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.Motor_4.Stop;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "RunFeedback":
                                tag.Value = Parent.S71500.Motor_4.RunFeedback;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Reset":
                                tag.Value = Parent.S71500.Motor_4.Reset;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Fault":
                                tag.Value = Parent.S71500.Motor_4.Fault;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Pos":
                                tag.Value = Parent.S71500.Motor_4.Pos;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }

                        break;
                    case "Motor_5":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.Motor_5.Mode;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.Motor_5.Start;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.Motor_5.Stop;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "RunFeedback":
                                tag.Value = Parent.S71500.Motor_5.RunFeedback;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Reset":
                                tag.Value = Parent.S71500.Motor_5.Reset;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Fault":
                                tag.Value = Parent.S71500.Motor_5.Fault;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Pos":
                                tag.Value = Parent.S71500.Motor_5.Pos;
                                tag.Quality = "GOOD";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }

                        break;

                    case "level":
                        tag.Value = Parent.S71500.level;
                        break;
                    case "History":
                        tag.Value = Parent.S71500.level;
                        aHistory[position] = Convert.ToInt32(tag.Value);
                        position++;
                        if (position == 100) position = 0;

                        break;
                    case "Alarm":
                        tag.Value = Parent.S71500.level;
                        break;
                }
            }
        }

        public void Sleep()
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Stop();
            }
        }

        public void Resume()
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Start();
            }
        }

        public void Kill()
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Dispose();
                UpdateTimer = null;
            }
        }

    }
}
