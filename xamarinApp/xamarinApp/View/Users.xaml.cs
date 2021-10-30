using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinApp.Controller;
using xamarinApp.Models;

namespace xamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class Users : ContentPage
    {
        private ObservableCollection<User> items = new ObservableCollection<User>();
        UserController userData = new UserController();
        public Users()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            var sourceData = userData.GetUsers();
            listUser.ItemsSource = sourceData;
        }
        private async void OnDelete(object sender, System.EventArgs e)
        {
            var sourceData = userData.GetUsers();
            var item = (Button)sender;
            var model = (User)item.CommandParameter;
            this.items.Remove(model);
            userData.DeleteUser(model.Id);
            await DisplayAlert("Thông", "Xóa thành công", "Load");
            App.Current.MainPage = new NavigationPage(new MainTabbed());
            
       
        }
    }
}