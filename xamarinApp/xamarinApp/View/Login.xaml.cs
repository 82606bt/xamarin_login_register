using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinApp.Controller;

namespace xamarinApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        UserController userData;
        public Login()
        {
            InitializeComponent();
            userData = new UserController();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            firstPassword.ReturnCommand = new Command(() => secondPassword.Focus());
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);

        }

        async void btn_Register(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Register());
        }
        private async void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            popupLoadingView.IsVisible = true;
        }
        string logesh;
        private async void userIdCheckEvent(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(useridValidationEntry.Text)) || (string.IsNullOrWhiteSpace(useridValidationEntry.Text)))
            {
                await DisplayAlert("Thông báo", "Nhập tài khoản", "OK");
            }
            else
            {
                logesh = useridValidationEntry.Text;
                var textresult = userData.updateUserValidation(useridValidationEntry.Text);
                if (textresult)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("Thông báo", "Tài khoản không tồn tại", "OK");
                }
            }
        }
        private async void Password_ClickedEvent(object sender, EventArgs e)
        {
            if (!string.Equals(firstPassword.Text, secondPassword.Text))
            {
                warningLabel.Text = "Đặt cùng mật khẩu";
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) || (string.IsNullOrWhiteSpace(secondPassword.Text)))
            {
                await DisplayAlert("Thông báo", "Nhập mật khẩu", "OK");
            }
            else
            {
                try
                {
                    var return1 = userData.updateUser(logesh, firstPassword.Text);
                    passwordView.IsVisible = false;
                    if (return1)
                    {
                        await DisplayAlert("Thông báo", "Mật khẩu đã cập nhật mới", "OK");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        private async void btn_Login(object sender, EventArgs e)
        {

            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = userData.LoginValidate(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    popupLoadingView.IsVisible = false;
                    App.Current.MainPage = new NavigationPage(new MainTabbed());

                }
                else
                {
                    popupLoadingView.IsVisible = false;
                    await DisplayAlert("Đăng nhập thất bại", "Tài khoản hoặc mật khẩu sai", "OK");
                }
            }
            else
            {
                popupLoadingView.IsVisible = false;
                await DisplayAlert("Thông báo", "Hãy nhập tài khoản và mật khẩu", "OK");
            }
        }
    }

}
