using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsChatUygulamasi.Database;

namespace XamarinFormsChatUygulamasi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAddRoom : ContentPage
    {
        public PageAddRoom()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DbFile db = new DbFile();
            await db.CreateRoomAsync(new Model.Room() { Name = roomName.Text});
             await Navigation.PopAsync();
        }
    }
}