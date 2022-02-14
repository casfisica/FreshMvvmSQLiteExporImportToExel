using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using FreshMvvmSQLiteExporImportToExel.PageModels;



namespace FreshMvvmSQLiteExporImportToExel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
            var navegationPage = new FreshNavigationContainer(page);

            MainPage = navegationPage;
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
