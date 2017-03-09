namespace FriendsList.BE
{
    public class Friend : AbstractEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}