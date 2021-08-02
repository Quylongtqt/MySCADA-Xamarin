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
            {  "Auto","Manual"};

            InitializeComponent();
           
            ID = id;
           
            //lName.Text = Convert.ToString(ID);
           
            pName.BindingContext = this;
           
            Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task task = Parent.FindTask("Task_1");
                    Tag tag;
                    if (ID == 3)
                    {
                        if (task != null)
                        {

                            tag = task.FindTag("Valve_Mode");
                            if (tag != null)
                            {
                                lName.Text = tag.Value.ToString();
                            }
                            tag = task.FindTag("Valve_RunFeedback");
                            if (tag != null)
                            {

                                if (Convert.ToBoolean(tag.Value))
                                    iName.Source = "on.png";
                                else iName.Source = "off.png";
                            }

                        }

                    }
                    else
                    {
                        string Prefix = $"Motor_{ID}";
                        if (task != null)
                        {

                            tag = task.FindTag($"{Prefix}_Mode");
                            if (tag != null)
                            {
                                lName.Text = tag.Value.ToString();
                            }
                            tag = task.FindTag($"{Prefix}_RunFeedback");
                            if (tag != null)
                            {

                                if (Convert.ToBoolean(tag.Value))
                                    iName.Source = "on.png";
                                else iName.Source = "off.png";
                            }

                        }
                    }


                    // interact with UI elements
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
            if (Name == "Auto")
            {
                Parent.S71500.WriteInt($"DB{ID}.DBW0", 2);
            }
            else if (Name == "Manual")
            {
                Parent.S71500.WriteInt($"DB{ID}.DBW0", 1);
            }
            DisplayAlert(Name,"Ok","Cancel");
           
        }
    }
}