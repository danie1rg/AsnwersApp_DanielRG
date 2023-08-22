using AsnwersApp_DanielRG.Models;
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
    public partial class AskPage : ContentPage
    {
        AskViewModel viewModel;
        public AskPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AskViewModel();
            Cargar();
            LoadUserName();
        }
        private void LoadUserName()
        {
            LblUserName.Text = GlobalObject.MyLocalUsuario.FirstName;
        }

        private async void Cargar() 
        {
            PkrAskStatus.ItemsSource = await viewModel.GetAksStatusAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            AskStatus Selected = PkrAskStatus.SelectedItem as AskStatus;

            bool r = await viewModel.AddUserAsync(DateTime.Now, TxtAsk.Text.Trim(), GlobalObject.MyLocalUsuario.UserId,Selected.AskStatusId, TxtImagen.Text.Trim(), TxtAskDetail.Text.Trim());

            if (r)
            {
                await DisplayAlert(":)", "Question created succesfully", "OK");
                TxtAsk.Text = null;
                TxtAskDetail.Text = null;
                TxtImagen.Text = null;
                Selected = null;
            }
            else
            {
                await DisplayAlert(":(", $"Something went wrong{Selected.AskStatusId}", "OK");
            }

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}