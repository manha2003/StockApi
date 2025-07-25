﻿using ApplicationLayer.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Users.RegisterUser
{
    public record RegisterUserCommand(RegisterUserDto UserDto) : IRequest<string>;
}
