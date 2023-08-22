using AsnwersApp_DanielRG.Services;
using AsnwersApp_DanielRG.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsnwersApp_DanielRG
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AppWelcomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
