using CarWorkshopAPI.Dtos;
using MediatR;

namespace CarWorkshopAPI.Commands.Login;

public record LoginCommand(LoginDto Dto) : IRequest<string?>;
