namespace CwkBooking3.API.DTOs
{
    public class RoomGetDTO
    {
            public int Id { get; set; }
            public int RoomNumber { get; set; }
            public double Surface { get; set; }
            public bool NeedsRepair { get; set; }
    }
}
