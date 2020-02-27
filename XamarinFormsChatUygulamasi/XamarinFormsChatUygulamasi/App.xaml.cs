using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsChatUygulamasi.Views;

namespace XamarinFormsChatUygulamasi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PageRoom());
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
