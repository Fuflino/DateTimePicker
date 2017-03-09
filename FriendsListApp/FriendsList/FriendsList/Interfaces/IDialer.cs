using System.Diagnostics.Contracts;

namespace FriendsList.Interfaces
{
    public interface IDialer
    {
        void call(string number);
        void startDialer(string number);
    }
}