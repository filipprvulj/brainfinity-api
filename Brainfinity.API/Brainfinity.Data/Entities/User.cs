﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamName { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public byte[] Logo { get; set; }
    }
}