using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Entities
{
    public class AssignmentGroup : BaseEntity
    {
        public Guid CompetitionId { get; set; }
        public Competition Competition { get; set; }


        public Guid GradeId { get; set; }
        public Grade Grade { get; set; }

        
    }
}
