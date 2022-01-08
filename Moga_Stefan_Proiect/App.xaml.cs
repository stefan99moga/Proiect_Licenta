//using Moga_Stefan_Proiect.Services;
using Moga_Stefan_Proiect.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Moga_Stefan_Proiect.Services;

namespace Moga_Stefan_Proiect
{
    public partial class App : Application
    {
        public static OrderListDatabase Database { get; private set; }
        public App()
        {
            InitializeComponent();

            Database = new OrderListDatabase(new RestService());
            MainPage = new AppShell();
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
