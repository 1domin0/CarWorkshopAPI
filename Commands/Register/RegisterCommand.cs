using CarWorkshopAPI.Dtos;
using MediatR;

namespace CarWorkshopAPI.Commands.Register;

public record RegisterCommand(RegisterDto Dto) : IRequest;