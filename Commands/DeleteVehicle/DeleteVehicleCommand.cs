using MediatR;

namespace CarWorkshopAPI.Commands.DeleteVehicle;

public record DeleteVehicleCommand(int Id) : IRequest;