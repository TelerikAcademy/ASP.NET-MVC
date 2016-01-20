namespace WorkingWithDataMvc.Models
{
    public class PersonWithAddressViewModel
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }

        public string Country { get; set; }
    }
}