using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsChatUygulamasi.Database;
using XamarinFormsChatUygulamasi.Design;
using XamarinFormsChatUygulamasi.Model;
using XamarinFormsChatUygulamasi.Notification;

namespace XamarinFormsChatUygulamasi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRoom : ContentPage
    {
        DbFile db = new DbFile();
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await db.GetRoomListAsync();
            ListRooms.BindingContext = list;
            try
            {
                if (User.UserName.Length < 1)
                    await Navigation.PushPopupAsync(new MyNtf());
            }
            catch
            {
                await Navigation.PushPopupAsync(new MyNtf());
            }


        }
        public PageRoom()
        {
            InitializeComponent();
        }

        private void ToolbarItemAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddRoom());
        }

        private async void ListRooms_Refreshing(object sender, EventArgs e)
        {

            ListRooms.BindingContext = await db.GetRoomListAsync();
            ListRooms.IsRefreshing = false;
        }
        private void ToolbarItemInfo_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Current User", User.UserName, "OK");
        }

        private void ListRooms_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ListRooms.SelectedItem != null)
            {

                var selectedRoom = (Room)ListRooms.SelectedItem;

                Navigation.PushAsync(new PageChatRoom());

                MessagingCenter.Send<PageRoom, Room>(this, "RoomProp", selectedRoom);

            }

        }
    }
}