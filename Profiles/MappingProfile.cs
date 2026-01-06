using AutoMapper;
using CarWorkshopAPI.Dtos;
using CarWorkshopAPI.Models;

namespace CarWorkshopAPI.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Vehicle, VehicleInfoDto>();
        CreateMap<VehicleInfoDto, Vehicle>();
    }
}