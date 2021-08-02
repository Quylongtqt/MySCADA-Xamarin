using MySCADA.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MySCADA.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}