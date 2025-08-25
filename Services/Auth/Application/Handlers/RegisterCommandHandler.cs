using Application.Commands;
using Application.Dtos;
using Application.Interfaces;
using Core;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public RegisterCommandHandler(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));

            return await _jwtService.GenerateToken(user);
        }
    }
}
