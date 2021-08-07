using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace MySCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmView : ContentPage
    {
        int ID;
        public SCADA Parent;

        string Nomal = "Nomal";
        string Hight = "Hight";
        string vHight = "Very Hight";
        string Low = " Low";
        string vLow = "Very Low";
        private int presentValue;
        private int preValue;


        public ObservableCollection<string> al { get; set; }
        public AlarmView()
        {
            InitializeComponent();

            al = new ObservableCollection<string>();
            lvName.BindingContext = this;
            Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task task = Parent.FindTask("Task_4");
                    Tag tag;
                    if (task != null)
                    {
                        tag = task.FindTag("Alarm");
                        if (tag != null)
                        {
                            presentValue = Convert.ToUInt16(tag.Value);

                            if (((preValue < 80) && (presentValue >= 80)) || ((preValue >= 90) && (presentValue < 90)))
                            {
                                DateTime dt = DateTime.Now;
                                string dateTime = dt.ToString();
                                al.Add(dateTime);
                                al.Add(Hight);
                            }
                            if ((preValue > 20) && (presentValue <= 20) || ((preValue <= 10) && (presentValue > 10)))
                            {
                                DateTime dt = DateTime.Now;
                                string dateTime = dt.ToString();
                                al.Add(dateTime);
                                al.Add(Low);
                            }
                            if ((preValue < 90) && (presentValue >= 90))
                            {
                                DateTime dt = DateTime.Now;
                                string dateTime = dt.ToString();
                                al.Add(dateTime);
                                al.Add(vHight);
                            }

                            if ((preValue > 10) && (presentValue <= 10))
                            {
                                DateTime dt = DateTime.Now;
                                string dateTime = dt.ToString();
                                al.Add(dateTime);
                                al.Add(vLow);
                            }
                            if (((preValue <= 20) && (presentValue > 20)) || ((preValue >= 80) && (presentValue < 80)))
                            {
                                DateTime dt = DateTime.Now;
                                string dateTime = dt.ToString();
                                al.Add(dateTime);
                                al.Add(Nomal);
                            }

                            preValue = presentValue;
                        }

                    }

                    // interact with UI elements
                });
                return true; // runs again, or false to stop
            });
        }
    }
}