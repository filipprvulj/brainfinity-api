using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Entities
{
    public class Assignment : BaseEntity
    {
        public string Name { get; set; }

        public int MaxPoints { get; set; }

        public Guid GradeId { get; set; }

        public Grade Grade { get; set; }

        public Guid UserId { get; set; }

        public User MainExaminer { get; set; }


    }
}
