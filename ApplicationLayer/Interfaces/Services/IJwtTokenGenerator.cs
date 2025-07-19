using DomainLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Services
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(User user);
    }
}
