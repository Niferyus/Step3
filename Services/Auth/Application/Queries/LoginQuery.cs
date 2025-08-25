using Application.Dtos;
using MediatR;

namespace Application.Queries
{
    public class LoginQuery : IRequest<AuthResponse>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
