using CarWorkshopAPI.Services;
using CarWorkshopAPI.Services.Interfaces;
using MediatR;

namespace CarWorkshopAPI.Commands.Login;

public class LoginHandler(IAuthService _authService) : IRequestHandler<LoginCommand, string?>
{
    public async Task<string?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(request.Dto);
    }
}