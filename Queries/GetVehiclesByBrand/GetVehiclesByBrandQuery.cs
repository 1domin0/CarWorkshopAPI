using CarWorkshopAPI.Dtos;
using MediatR;

namespace CarWorkshopAPI.Queries.GetVehiclesByBrand;

public record GetVehiclesByBrandQuery(string Brand) : IRequest<List<VehicleInfoDto>>;