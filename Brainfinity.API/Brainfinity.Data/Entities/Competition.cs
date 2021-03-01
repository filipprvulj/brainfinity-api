using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Entities
{
    public class Competition : BaseEntity
    {
        [Required]
        public string CompetitionName { get; set; }

        public byte[] CompetitionPicture { get; set; }

        public Guid StatusId { get; set; }

        public Status Status { get; set; }

        public ICollection<User> Users { get; set; }
    }
}