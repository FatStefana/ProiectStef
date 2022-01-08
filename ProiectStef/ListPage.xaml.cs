using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectStef.Models;

namespace ProiectStef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var rlist = (Produse)BindingContext;

            await App.Database.SaveProduseAsync(rlist);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var rlist = (Produse)BindingContext;
            await App.Database.DeleteProduseAsync(rlist);
            await Navigation.PopAsync();
        }
    }
}