using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsChatUygulamasi.Design
{
    public class User
    {
        private static string uID;
        public static string UserName
        {
            get
            {
                return uID;
            }
            set
            {
                uID = value;
            }

        }

        private User()
        {
        }


    }
}
