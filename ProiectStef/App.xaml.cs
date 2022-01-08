using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectStef.Data;
using System.IO;

namespace ProiectStef
{
    public partial class App : Application
    {

        static ProduseDatabase database;
        public static ProduseDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProduseDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "Produse.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

    }

}
