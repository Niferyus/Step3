using Application.Commands;
using Application.Dtos;
using Application.Interfaces;
using Core;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public RefreshTokenCommandHandler(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.RefreshToken == request.RefreshToken);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new UnauthorizedAccessException("Invalid refresh token");

            return await _jwtService.GenerateToken(user);
        }
    }
}
