using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Entities
{
    public class TeamMember : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid TeamId { get; set; }
        public User Team { get; set; }
    }
}