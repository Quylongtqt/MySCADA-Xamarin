using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;
using Microcharts;
using System.Collections.ObjectModel;

namespace MySCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrendView : ContentPage
    {
        int ID;
        public SCADA Parent;
        static int a;
        public ObservableCollection<Entry> entries { get; set; }


        public TrendView()
        {
           
            InitializeComponent();
            entries = new ObservableCollection<Entry>();
            cName.HeightRequest = 240;
            //for (int i = 1; i < 100; i++)
            //{
            //    a++;
            //    entries.Add(new Entry(a)
            //    {
            //        Color = SkiaSharp.SKColor.Parse("#FF1493"),



            //    });

            //}

            Device.StartTimer(TimeSpan.FromMilliseconds(3000), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                { //zedGraphControl1.AxisChange();
                    Task task3 = Parent.FindTask("Task_3");
                    if (task3 != null)
                    {
                        int temp = task3.position;
                        entries.Clear();
                        if (temp >= 10)
                        {
                            for (int i = 0; i < 10; i++)
                            {

                                entries.Add(new Entry(task3.aHistory[temp - 10 + i])
                                {
                                    Color = SkiaSharp.SKColor.Parse("#FF1493"),
                                    Label = $"{temp - 10 + i}",


                                    ValueLabel = Convert.ToString(task3.aHistory[temp - 10 + i])

                                });
                            }


                        }
                        if (temp < 10)
                        {
                            int temp1 = temp + 90;

                            for (int i = 0; i < 10; i++)
                            {
                                temp1++;
                                if (temp1<=99 && temp1>=90)
                                {
                                    entries.Add(new Entry(task3.aHistory[temp1])
                                    {
                                        Color = SkiaSharp.SKColor.Parse("#FF1493"),
                                        Label = $"{temp1}",
                                        ValueLabel = Convert.ToString(task3.aHistory[temp1])


                                    });
                                }
                                else if(temp1>99)
                                {
                                  
                                   
                                   
                                        entries.Add(new Entry(task3.aHistory[temp1-100])
                                        {
                                            Color = SkiaSharp.SKColor.Parse("#FF1493"),
                                            Label = $"{temp1}",
                                            ValueLabel = Convert.ToString(task3.aHistory[temp1-100])


                                        });
                                    
                                    
                                }
                                
                            }

                        }




                    }


                    //entries.RemoveAt(0);
                    //a--;

                    //entries.Add(new Entry(a)
                    //{
                    //    Color = SkiaSharp.SKColor.Parse("#FF1493"),



                    //});

                    cName.Chart = new LineChart { Entries = entries, LineMode = LineMode.Straight, AnimationDuration = new TimeSpan(0), BackgroundColor= SkiaSharp.SKColor.Parse("#FFFFFF"),IsAnimated=false} ;
                    
                    // interact with UI elements
                });
                return true; // runs again, or false to stop
            });
        }
    }
}