using CarWorkshopAPI.Services;
using CarWorkshopAPI.Services.Interfaces;
using MediatR;

namespace CarWorkshopAPI.Commands.Register;

public class RegisterHandler(IAuthService _authService) : IRequestHandler<RegisterCommand>
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        
        await _authService.RegisterAsync(request.Dto);
    }
}