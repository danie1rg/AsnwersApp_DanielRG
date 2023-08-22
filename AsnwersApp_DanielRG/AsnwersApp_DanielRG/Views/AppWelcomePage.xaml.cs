using AsnwersApp_DanielRG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsnwersApp_DanielRG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppWelcomePage : ContentPage
    {
        UserViewModel viewModel;
        public AppWelcomePage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserViewModel();
        }


        private async void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            //GlobalObject.MyLocalUser = await viewModel.GetUserDataAsync(); 
            GlobalObject.MyLocalUsuario = await viewModel.GetUsuarioDataAsync();
            await Navigation.PushAsync(new MainPage());
        }
    }
}