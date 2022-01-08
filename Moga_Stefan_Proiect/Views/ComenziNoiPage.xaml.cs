using Moga_Stefan_Proiect.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moga_Stefan_Proiect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComenziNoiPage : ContentPage
    {
        public ComenziNoiPage()
        {
            InitializeComponent();
            comNoiListView.RefreshCommand = new Command(() =>
            {
                RefreshData();
                comNoiListView.IsRefreshing = false;
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
          //  List<Pizza> listaPizza = await App.Database.GetOrderListsAsync();
            comNoiListView.ItemsSource = await App.Database.GetOrderListsAsync();
        }


        public async void RefreshData()
        {
            comNoiListView.ItemsSource = await App.Database.GetOrderListsAsync();
        }
        protected override async void OnBindingContextChanged()
        {
            //  List<Pizza> listaPizza = await App.Database.GetOrderListsAsync();
            comNoiListView.ItemsSource = await App.Database.GetOrderListsAsync();
        }
    }
}