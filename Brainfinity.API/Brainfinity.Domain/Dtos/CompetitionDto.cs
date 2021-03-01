using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Dtos
{
    public class CompetitionDto : BaseDto
    {
        public string CompetitionName { get; set; }

        public byte[] CompetitionPicture { get; set; }

        public Guid StatusId { get; set; }

        public ICollection<UserDto> Teams { get; set; }
    }
}