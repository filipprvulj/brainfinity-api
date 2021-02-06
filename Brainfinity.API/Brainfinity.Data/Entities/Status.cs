using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Entities
{
    public class Status : BaseEntity
    {
        [Required]
        public string StatusName { get; set; }
    }
}