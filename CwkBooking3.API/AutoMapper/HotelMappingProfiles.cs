using AutoMapper;
using CwkBooking3.API.DTOs;
using CwkBooking3.Domain.Models;

namespace CwkBooking3.API.AutoMapper
{
    public class HotelMappingProfiles : Profile
    {
        public HotelMappingProfiles()
        {
            CreateMap<HotelCreateDTO, Hotel>();
            CreateMap<Hotel, HotelGetDTO>();
        }
    }
}
