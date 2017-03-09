using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsList.Repository;
using Xamarin.Forms;

namespace FriendsList
{
    public partial class MainPage : ContentPage
    {
        private FriendRepository _repo = new FriendRepository();
        public MainPage()
        {
            InitializeComponent();
            SetupPage();
        }


        private void SetupPage()
        {
            mainLayout.BackgroundColor = Color.Aqua;
            mainLayout.BackgroundColor.AddLuminosity(100);
            mainLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            mainLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;

            img.Source = "x2.png";
            img.HeightRequest = 200;

            title.TextColor = Color.Lime;

            nameLbl.TextColor = Color.Red;
            friendsLbl.TextColor = Color.Red;

            friendsLbl.Text = "Active friends: " + _repo.ReadAll().Count;

            Content = mainLayout;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FriendListView());
        }
    }
}
