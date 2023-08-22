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
    public partial class QuestionsPage : ContentPage
    {
        AskViewModel askviewModel;
        public QuestionsPage()
        {
            InitializeComponent();
            BindingContext = askviewModel = new AskViewModel();
            LoadAsks();
        }

        private async void LoadAsks() 
        {
            LvList.ItemsSource = await askviewModel.GetAsksByAsync();
        }
    }
}