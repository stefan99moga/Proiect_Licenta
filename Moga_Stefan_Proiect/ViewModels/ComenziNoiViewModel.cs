

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Moga_Stefan_Proiect.Views;
using System.Collections.Generic;
using Moga_Stefan_Proiect.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Threading.Tasks;

namespace Moga_Stefan_Proiect.ViewModels
{
    public class ComenziNoiViewModel : BaseViewModel
    {
        public ObservableRangeCollection<NewOrder> NewOrderList { get; set; }
        public AsyncCommand RefreshComd { get; }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await Refresh();
                    IsRefreshing = false;
                });
            }
        }
        public ComenziNoiViewModel()
        {
            Title = "Comenzi noi";
            NewOrderList = new ObservableRangeCollection<NewOrder>();
            _ = Refresh();
            RefreshComd = new AsyncCommand(Refresh);
        }

        private async Task Refresh()
        {
            NewOrderList.Clear();
            var orders = await App.Database.GetOrderListsAsync();
            NewOrderList.AddRange(orders);
            
        }
    }
}