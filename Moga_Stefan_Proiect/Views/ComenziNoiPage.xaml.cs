using Moga_Stefan_Proiect.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Moga_Stefan_Proiect.ViewModels;

namespace Moga_Stefan_Proiect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComenziNoiPage : ContentPage
    {
        public ComenziNoiPage()
        {
            InitializeComponent();
        }

        private void comNoiListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}