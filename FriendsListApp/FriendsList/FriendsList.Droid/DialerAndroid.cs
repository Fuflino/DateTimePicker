using Android.App;
using Android.Content;
using FriendsList.Droid;
using FriendsList.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialerAndroid))]

namespace FriendsList.Droid
{
    public class DialerAndroid : IDialer
    {
        public void call(string number)
        {
            Dial(Intent.ActionCall, number);
        }

        public void startDialer(string number)
        {
            Dial(Intent.ActionDial, number);
        }

        private void Dial(string dialMethod, string number)
        {
            var activity = (Activity)Forms.Context;
            var uri = Android.Net.Uri.Parse("tel:" + number);
            var intent = new Intent(dialMethod, uri);
            activity.StartActivity(intent);
        }
    }
}