using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Models
{
    public class TeamOutputModel
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; }
        public string Email { get; set; }
        public string Mentor { get; set; }
        public string Grade { get; set; }
    }
}