using MANDO.Services;
using MANDO.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MANDO
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new Kaizen();
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
