using Application.Dtos;
using MediatR;

namespace Application.Commands
{
    public class RefreshTokenCommand : IRequest<AuthResponse>
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }
}
