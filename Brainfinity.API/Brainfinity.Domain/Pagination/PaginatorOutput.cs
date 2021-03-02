using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Pagination
{
    public class PaginatorOutput<TDto>
    {
        public PaginatorMetadata Metadata { get; set; }
        public List<TDto> Entities { get; set; }

        public PaginatorOutput(List<TDto> entities, PaginatorMetadata metadata)
        {
            Entities = entities;
            Metadata = metadata;
        }
    }
}