using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Dtos
{
    public class TeamDto : BaseDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string TeamName { get; set; }
        public byte[] Logo { get; set; }
        public byte[] TeamPicture { get; set; }
        public List<TeamMemberDto> TeamMembers { get; set; }
    }
}