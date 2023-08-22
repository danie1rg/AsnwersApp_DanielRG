using AsnwersApp_DanielRG.ViewModels;
using AsnwersApp_DanielRG.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AsnwersApp_DanielRG
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
           // Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
