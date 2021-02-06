using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Entities
{
    public class Grade : BaseEntity
    {

        public Guid GradeLevelId { get; set; }
        public  GradeLevel GradeLevel { get; set; }

        public string Name { get; set; }
    }
}
