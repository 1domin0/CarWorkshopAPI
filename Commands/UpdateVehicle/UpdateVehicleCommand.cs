using CarWorkshopAPI.Dtos;
using MediatR;

namespace CarWorkshopAPI.Commands.UpdateVehicle;

public record UpdateVehicleCommand(int Id, VehicleInfoDto Dto) : IRequest;