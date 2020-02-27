using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsChatUygulamasi.Database;
using XamarinFormsChatUygulamasi.Design;
using XamarinFormsChatUygulamasi.Model;

namespace XamarinFormsChatUygulamasi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageChatRoom : ContentPage
    {
        DbFile db = new DbFile();
        Room rm = new Room();
        public PageChatRoom()
        {

            InitializeComponent();
            MessagingCenter.Subscribe<PageRoom, Room>(this, "RoomProp", (page, data) =>
             {
                 rm = data;
                 lstChat.BindingContext = db.subChat(data.Key);
                 MessagingCenter.Unsubscribe<PageRoom, Room>(this, "RoomProp");
             });
          

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {

            Chat ch = new Chat(){ UserMessage = entMessage.Text, Username = User.UserName } ;

            await db.SaveMessage(ch, rm.Key);
        }
       
    }
}