namespace FriendsList.Interfaces
{
    public interface ISMSHandler
    {
        void sendSMS(string number);
        void startSMSApp(string number, string body);

    }
}