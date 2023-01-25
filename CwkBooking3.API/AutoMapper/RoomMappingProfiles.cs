using AutoMapper;
using CwkBooking3.API.DTOs;
using CwkBooking3.Domain.Models;

namespace CwkBooking3.API.AutoMapper
{
    public class RoomMappingProfiles : Profile
    {
        public RoomMappingProfiles()
        {
            CreateMap<Room, RoomGetDTO>();
            CreateMap<RoomPostDTO, Room>();
        }
        
        
    }
}
