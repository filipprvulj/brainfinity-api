using Brainfinity.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Models
{
    public class RegisterTeamModel
    {
        public string TeamName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public List<TeamMemberModel> TeamMembers { get; set; }
    }
}