using Application.Dtos;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJwtService
    {
        Task<AuthResponse> GenerateToken(User user);
        Task<AuthResponse> GenerateRefreshToken(string token, string refreshToken);
    }
}
