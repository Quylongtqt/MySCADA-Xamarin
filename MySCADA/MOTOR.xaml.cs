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
    public partial class MOTOR : ContentPage
    {
       
        int ID;
        public SCADA Parent;
        public ObservableCollection<string> pItems { get; set; }
        public MOTOR(int id)
        {
            pItems = new ObservableCollection<string>()
            {"AUTO","MANUAL"};

            InitializeComponent();
           
            ID = id;
                      
            pName.BindingContext = this;
           
            Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task task1 = Parent.FindTask("Task_1");
                    Tag temp_tag1;
                    string Prefix = $"Motor_{ID}";
                    if (task1 != null)
                    {
                        temp_tag1 = task1.FindTag($"{Prefix}_Mode");
                        if (temp_tag1 != null)
                        {
                            lName.Text = temp_tag1.Value.ToString();
                        }
                        temp_tag1 = task1.FindTag($"{Prefix}_RunFeedback");
                        if (temp_tag1 != null)
                        {
                            if (Convert.ToBoolean(temp_tag1.Value))
                                iName.Source = "MotorON.png";
                            else iName.Source = "Motor.png";
                        }
                    }

                    Task task5 = Parent.FindTask("Task_5");
                    Tag temp_tag2;
                    if (task5 != null)
                    {
                        temp_tag2 = task5.FindTag($"{Prefix}_Mode");
                        if (temp_tag2 != null)
                        {
                            lName.Text = temp_tag2.Value.ToString();
                        }
                        temp_tag2 = task5.FindTag($"{Prefix}_RunFeedback");
                        if (temp_tag2 != null)
                        {
                            if (Convert.ToBoolean(temp_tag2.Value))
                                iName.Source = "MotorON.png";
                            else iName.Source = "Motor.png";
                        }
                    }

                });
                return true; // runs again, or false to stop
            });
        }

        private void bOnName_Clicked(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{ID}.DBX2.0", true);
            Parent.S71500.WriteBool($"DB{ID}.DBX2.0", false);
        }

        private void bOffName_Clicked(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{ID}.DBX2.1", true);
            Parent.S71500.WriteBool($"DB{ID}.DBX2.1", false);
        }

        private void pName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Name = pName.Items[pName.SelectedIndex];
            if (Name == "AUTO")
            {
                short value = 2; //Khai báo kiểu short ( tương đương int 16 bits của S7)
                Parent.S71500.WriteInt($"DB{ID}.DBW0", value);
            }
            else if (Name == "MANUAL")
            {
                short value = 1; //Khai báo kiểu short ( tương đương int 16 bits của S7)
                Parent.S71500.WriteInt($"DB{ID}.DBW0", value);
            }
            DisplayAlert(Name,"Đã thay đổi chế độ","OK");
           
        }
    }
}