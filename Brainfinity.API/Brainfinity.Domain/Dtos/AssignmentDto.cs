using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Dtos
{
    public class AssignmentDto : BaseDto
    {
        public string Name { get; set; }

        public int MaxPoints { get; set; }

        public Guid MainExaminerId { get; set; }

        public Guid AssignmentGroupId { get; set; }
    }
}
