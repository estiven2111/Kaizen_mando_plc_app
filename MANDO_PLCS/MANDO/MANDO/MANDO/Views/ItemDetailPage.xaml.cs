using MANDO.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MANDO.Views
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