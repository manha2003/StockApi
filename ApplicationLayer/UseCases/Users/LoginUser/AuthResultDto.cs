﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Users.LoginUser
{
    public record AuthResultDto(string token, Guid userId, string userName);

}
