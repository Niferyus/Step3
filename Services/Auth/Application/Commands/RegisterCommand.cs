using Application.Dtos;
using MediatR;

namespace Application.Commands
{
    public class RegisterCommand : IRequest<AuthResponse>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
