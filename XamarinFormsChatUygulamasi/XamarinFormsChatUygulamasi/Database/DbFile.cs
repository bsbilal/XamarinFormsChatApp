using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsChatUygulamasi.Model;

namespace XamarinFormsChatUygulamasi.Database
{
   public class DbFile
    {
        FirebaseClient fbClient;

        public DbFile()
        {

            fbClient = new FirebaseClient("https://xamarinchatapp.firebaseio.com/");
        }
        public async Task<List<Room>> GetRoomListAsync()
        {
            return (await fbClient
                .Child("ChApp")
                .OnceAsync<Room>())
                .Select((item) =>
                 new Room { Key = item.Key, Name = item.Object.Name })
             .ToList();

        }
        public async Task CreateRoomAsync(Room Oda)
        {
           await fbClient
                .Child("ChApp")
                .PostAsync(Oda);
        }
        public async Task SaveMessage(Chat cht,string room)
        {
            await fbClient
                 .Child("ChApp"+"/"+room+"/Message")
                 .PostAsync(cht);
        }
        public ObservableCollection<Chat> subChat(string roomKey)
        {
            string path = "ChApp" + "/" + roomKey + "/Message";
            return fbClient.Child(path)
                .AsObservable<Chat>()
                .AsObservableCollection<Chat>();
                


        }
    }
}
