using Xamarin.Forms;
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
    }
}
