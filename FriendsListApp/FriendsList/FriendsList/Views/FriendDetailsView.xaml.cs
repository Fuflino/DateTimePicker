using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsList.BE;
using FriendsList.Interfaces;
using FriendsList.Repository;
using Xamarin.Forms;

namespace FriendsList.Views
{
    public partial class FriendDetailsView : ContentPage
    {

        private FriendRepository _repo = new FriendRepository();

        Button updateBtn = new Button()
        {
            Text = "Update friend",
            IsEnabled = false
        };


        public FriendDetailsView(int? id)
        {
            InitializeComponent();
            if (id == null)
            {
                SetupPage(null);
            }
            else
            {
                SetupPage(id);
            }
            
        }

        private void SetupPage(int? id)
        {
            Friend f = _repo.Read(id.Value);

            Switch editBtn = new Switch();

            Label switchLbl = new Label()
            {
                Text = "Edit friend"
            };

            Image friendImage = new Image();
            friendImage.HeightRequest = 120;
            friendImage.Source = "x" + f.Id + ".png";

            editBtn.Toggled += EditBtnOnToggled;
            callBtn.Clicked += (sender, args) => CallOnClick(_repo.Read(id.Value).PhoneNr);
            SMSBtn.Clicked += (sender, args) => SmsOnClick(_repo.Read(id.Value).PhoneNr);
            updateBtn.Clicked += (sender, args) => UpdateBtnClicked(f);

            imageLayout.Children.Add(friendImage);

            switchLayout.Children.Add(switchLbl);
            switchLayout.Children.Add(editBtn);
            switchLayout.Children.Add(updateBtn);

            bottomLayout.Children.Add(callBtn);
            bottomLayout.Children.Add(SMSBtn);

            if (id != null)
            {
                nameEntry.Text = f.Name;
                nameEntry.IsEnabled = false;
                phoneEntry.Text = f.PhoneNr;
                phoneEntry.IsEnabled = false;
                addressEntry.Text = f.Address;
                addressEntry.IsEnabled = false;
                emailEntry.Text = f.Email;
                emailEntry.IsEnabled = false;
                homePageEntry.Text = f.HomePage;
                homePageEntry.IsEnabled = false;

            }
            else
            {
                nameEntry.Placeholder = "Name";
                phoneEntry.Placeholder = "Phone number";
                addressEntry.Placeholder = "Address";
                emailEntry.Placeholder = "E-mail";
                homePageEntry.Placeholder = "Webpage";
            }
        }

        private void UpdateBtnClicked(Friend friend)
        {
            var updatedFriend = new Friend()
            {
                Id = friend.Id,
                Name = nameEntry.Text,
                PhoneNr = phoneEntry.Text,
                Address = addressEntry.Text,
                Email = emailEntry.Text,
                HomePage = homePageEntry.Text,
                
            };

            _repo.Update(updatedFriend);
        }

        private void SmsOnClick(string number)
        {
            ISMSHandler smsHandler = DependencyService.Get<ISMSHandler>();
            smsHandler.startSMSApp(number, "");
        }

        private void CallOnClick(string number)
        {
            IDialer dialer = DependencyService.Get<IDialer>();
            dialer.startDialer(number);
        }

        private void EditBtnOnToggled(object sender, ToggledEventArgs toggledEventArgs)
        {
            nameEntry.IsEnabled = true;
            phoneEntry.IsEnabled = true;
            addressEntry.IsEnabled = true;
            emailEntry.IsEnabled = true;
            homePageEntry.IsEnabled = true;
            updateBtn.IsEnabled = true;
        }

        
    }
}
