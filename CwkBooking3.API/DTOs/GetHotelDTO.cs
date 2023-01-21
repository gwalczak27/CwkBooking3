namespace CwkBooking3.API.DTOs
{
    public class GetHotelDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
