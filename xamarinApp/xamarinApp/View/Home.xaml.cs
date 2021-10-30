using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Quit", "Bạn có muốn thoát", "OK");
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}