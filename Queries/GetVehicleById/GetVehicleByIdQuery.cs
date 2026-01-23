using CarWorkshopAPI.Dtos;
using MediatR;

namespace CarWorkshopAPI.Queries.GetVehicle;

public record GetVehicleByIdQuery(int Id) : IRequest<VehicleInfoDto>;