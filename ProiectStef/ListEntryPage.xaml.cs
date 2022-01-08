using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectStef.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectStef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEntryPage : ContentPage
    {

        public ListEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ProduseView.ItemsSource = await App.Database.GetProduseAsync();
        }
        async void OnProduseAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new Produse()
            });
        }
        async void OnProduseItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as Produse
                });
            }
        }
    }
}