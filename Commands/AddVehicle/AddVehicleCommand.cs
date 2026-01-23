using System.Windows.Input;
using CarWorkshopAPI.Dtos;
using MediatR;

namespace CarWorkshopAPI.Commands.AddVehicle;

public record AddVehicleCommand(VehicleInfoDto Dto) : IRequest<int>;
