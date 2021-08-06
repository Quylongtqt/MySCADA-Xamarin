using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;
using System.Collections.ObjectModel;
using MindFusion.Charting;
using Brush = MindFusion.Drawing.Brush;
using SolidBrush = MindFusion.Drawing.SolidBrush;

namespace MySCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrendView2 : ContentPage
    {
        int ID;
        public SCADA Parent;
        static int a;
        public ObservableCollection<Entry> entries { get; set; }

        MyDateTimeSeries LineLevel;

        public TrendView2()
        {

            InitializeComponent();
            
            entries = new ObservableCollection<Entry>();

            LineLevel = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            LineLevel.DateTimeFormat = DateTimeFormat.LongTime;

            LineLevel.LabelInterval = 10;
            LineLevel.MinValue = 0;
            LineLevel.MaxValue = 120;
            LineLevel.Title = "Áp suất";
            LineLevel.SupportedLabels = LabelKinds.XAxisLabel;
            

            // setup chart           
            lineChart.Series.Add(LineLevel);
            lineChart.ShowXCoordinates = false;
            lineChart.ShowLegendTitle = false;
            lineChart.LayoutPanel.Margin = new Margins(0, 0, 20, 0);

            lineChart.XAxis.Title = "Time";
            lineChart.XAxis.MinValue = 0;
            lineChart.XAxis.MaxValue = 120;
            lineChart.XAxis.Interval = 10;

            lineChart.YAxis.MinValue = 0;
            lineChart.YAxis.MaxValue = 100;
            lineChart.YAxis.Interval = 10;
            lineChart.YAxis.Title = "Áp suất (Kpa)";
            //
            List<Brush> brushes = new List<Brush>()
            {
                new SolidBrush(Color.Red)
            };

            List<double> thicknesses = new List<double>() { 2 };

            PerSeriesStyle style = new PerSeriesStyle(brushes, brushes, thicknesses, null);
            lineChart.Plot.SeriesStyle = style;
            lineChart.Theme.PlotBackground = new SolidBrush(Color.White);
            lineChart.Theme.GridLineColor = Color.LightGray;
            lineChart.TitleMargin = new Margins(10);
            lineChart.GridType = GridType.Horizontal;

            
            lineChart.GridType = GridType.Horizontal;
            lineChart.LineType = LineType.Polyline;

            // Time tick
            Device.StartTimer(TimeSpan.FromMilliseconds(3000), () =>
            {
                
                Device.BeginInvokeOnMainThread(() =>
                { 
                    Task task3 = Parent.FindTask("Task_3");
                    if (task3 != null)
                    {
                        Task task2 = Parent.FindTask("Task_2");
                        Tag tag2;
                        if (task2 != null)
                        {
                            tag2 = task2.FindTag("level");

                            if (tag2 != null)
                            {
                                ushort pressure = ((ushort)tag2.Value);
                                LineLevel.addValue(pressure);
                            }
                        }                        
                    }

                });
                return true; // runs again, or false to stop
            });
            
        }

    }
    
}