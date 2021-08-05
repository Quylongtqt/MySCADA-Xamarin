using System;
using System.Collections.Generic;
using System.Text;
using S7.Net;

namespace MySCADA
{
    public class PLC
    {
        public string IPAddress = "192.168.1.201";
        System.Timers.Timer ReadPLCTimer = new System.Timers.Timer();
        Plc thePLC;
        public PLC_Device Motor_1 = new PLC_Device();   // Device = "Motor_1"
        public PLC_Device Motor_2 = new PLC_Device();   // Device = "Motor_2"
        public PLC_Device Motor_3 = new PLC_Device();   // Device = "Motor_3"
        public PLC_Device Motor_4 = new PLC_Device();   // Device = "Motor_4"
        public PLC_Device Motor_5 = new PLC_Device();   // Device = "Motor_5"

        public SCADA Parent;
        public ushort level;
        public PLC()
        {
            thePLC = new Plc(CpuType.S71500, IPAddress, 0, 1);

            try
            {
                thePLC.Open();
            }
            catch
            {
                ;
            }

            ReadPLCTimer.Interval = 1000;
            ReadPLCTimer.Elapsed += new System.Timers.ElapsedEventHandler(ReadPLCTimer_Tick);
            ReadPLCTimer.Enabled = true;
            ReadPLCTimer.Start();
        }

        private void ReadPLCTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (thePLC.IsConnected)
                {
                    thePLC.ReadClass(Motor_1, 1);
                    thePLC.ReadClass(Motor_2, 2);
                    thePLC.ReadClass(Motor_3, 3);
                    thePLC.ReadClass(Motor_4, 4);
                    thePLC.ReadClass(Motor_5, 5);
                    object obj = thePLC.Read("MW20");
                    level = ((ushort)obj);

                }
            }
            catch
            {
                ;
            }

        }

        public void WriteBool(string address, bool value)
        {
            try
            {
                thePLC.Write(address, value);
            }

            catch
            {
                ;
            }

        }


        public void WriteInt(string address, short value)
        {
            try
            {
                thePLC.Write(address, value);
            }

            catch
            {
                ;
            }

        }
    }

    public class PLC_Device
    {
        public ushort Mode { get; set; } // "Mode"
        public bool Start { get; set; } // "Start"
        public bool Stop { get; set; }  // "Stop"
        public bool RunCond { get; set; }
        public bool StopCond { get; set; }
        public bool RunFeedback { get; set; }
        public bool Reset { get; set; }
        public byte aByte { get; set; }
        public bool Cmd { get; set; }
        public bool Fault { get; set; }

        public byte aByte2 { get; set; }
        public ushort Pos { get; set; }

    }
}
