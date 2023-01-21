namespace CwkBooking3.API.DTOs
{
    public class CreateHotelDTO
    {
        public string Name { get; set; }
        public int stars { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
