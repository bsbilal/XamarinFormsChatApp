using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsChatUygulamasi.Design;

namespace XamarinFormsChatUygulamasi.Notification
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyNtf : PopupPage
    {
        public MyNtf()
        {
            InitializeComponent();
        }
      public void btn_clicked (object sender,EventArgs t)
        {
            User.UserName = nameLogin.Text;
            Navigation.PopPopupAsync();
        }
      

    }
}