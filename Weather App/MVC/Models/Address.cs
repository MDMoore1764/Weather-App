namespace Weather_App.MVC.Models
{
    public class Address
    {
        public string StreetNumberAndName { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }
        public Address(string streetNumberAndName, string zip)
        {
            StreetNumberAndName = streetNumberAndName;
            Zip = zip;
        }
        public Address(string streetNumberAndName, string city, string state)
        {
            StreetNumberAndName = streetNumberAndName;
            City = city;
            State = state;
        }

    }
}
