using System.Collections.Generic;
using System.Linq;
using FriendsList.BE;

namespace FriendsList.Repository
{
    public class FriendRepository : IRepository<Friend, int>
    {
        private List<Friend> friendList = new List<Friend>();

        public FriendRepository()
        {
            PopulateList();
        }

        public void Create(Friend item)
        {
            this.friendList.Add(item);
        }

        public List<Friend> ReadAll()
        {
            return friendList;
        }

        public Friend Read(int id)
        {
            return this.friendList.FirstOrDefault(x => x.Id == id);

        }

        public void Update(Friend item)
        {
            var friendToUpdate = this.friendList.FirstOrDefault(x => x.Id == item.Id);
            friendToUpdate.Id = item.Id;
            friendToUpdate.Name = item.Name;
            friendToUpdate.Address = item.Address;
            friendToUpdate.Email = item.Email;
            friendToUpdate.HomePage = item.HomePage;
            friendToUpdate.PhoneNr = item.PhoneNr;
            
        }

        public bool Delete(Friend item)
        {
            return this.friendList.Remove(item);
        }

        private void PopulateList()
        {
            string[] array = new string[8];

            array[0] = "Thomas Jensen";
            array[1] = "Birger Uttson";
            array[2] = "Morten Warmer";
            array[3] = "Svend Tveskæg";
            array[4] = "Arne Josefsen";
            array[5] = "Blutus Maximus";
            array[6] = "Luna Ludermus";
            array[7] = "Lars Melorm";

            for (int i = 0; i < 8; i++)
            {
                Friend f = new Friend()
                {
                    Id = i + 1,
                    Name = array[i],
                    Address = "Nerdtown " + i + i,
                    Email = "Scrub" + i + "@NerdTown" + i + ".cum",
                    PhoneNr = "12345678" + i,
                    HomePage = "VapeNationZ." + i + i + "com",
                    Latitude = 31123.1 + i + i,
                    Longitude = 32314.23 + i + i

                };
                Create(f);
            }

        }
    }
}