using AutoMapper;
using Brainfinity.Data.Entities;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Repositories
{
    public class AssignmentGroupRepository : BaseRepository<AssignmentGroup, AssignmentGroupDto>, IAssignmentGroupRepository
    {

        public AssignmentGroupRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) 
        {
        
        }
    }
}
