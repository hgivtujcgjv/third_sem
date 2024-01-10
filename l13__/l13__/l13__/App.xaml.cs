using l13__.Services;
using l13__.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using l13__.ViewModels;
namespace l13__
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new HomePage());
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
