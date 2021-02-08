﻿using Brainfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ServiceInterfaces
{
    public interface ITeamValidationService
    {
        public void ValidateTeamRegistrationModel(RegisterTeamModel team);
    }
}