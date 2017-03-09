using Android.App;
using Android.Content;
using Android.Telephony;
using FriendsList.Droid;
using FriendsList.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SMSHandlerAndroid))]

namespace FriendsList.Droid
{

    public class SMSHandlerAndroid : ISMSHandler
    {
        public void sendSMS(string number)
        {
            SmsManager.Default.SendTextMessage(number, null, "Body", null, null);
        }

        public void startSMSApp(string number, string body)
        {
            var activity = (Activity)Forms.Context;
            var smsUri = Android.Net.Uri.Parse("smsto:" + number);
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            smsIntent.PutExtra("sms_body", body);
            activity.StartActivity(smsIntent);
        }
    }
}