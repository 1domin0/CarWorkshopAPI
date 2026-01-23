using CarWorkshopAPI.Dtos;
using MediatR;

namespace CarWorkshopAPI.Queries.GetVehicles;

public record GetVehiclesQuery : IRequest<List<VehicleInfoDto>>;