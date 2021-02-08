﻿using Brainfinity.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ServiceInterfaces
{
    public interface IAuthService
    {
        public Task<Guid> CreateTeamAsync(UserDto userDto, string password);
    }
}