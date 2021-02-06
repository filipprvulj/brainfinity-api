using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Dtos
{
    public class AssignmentGroupDto : BaseDto
    {

        public Guid CompetitionId { get; set; }

        public Guid GradeId { get; set; }
    }
}
