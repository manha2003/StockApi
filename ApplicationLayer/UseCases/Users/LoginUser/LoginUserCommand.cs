using ApplicationLayer.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Users.LoginUser
{
    public record LoginUserCommand(LoginUserDto LoginDto) : IRequest<AuthResultDto>;
}
