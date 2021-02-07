using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Service.Services
{
    public class AssignmentService : BaseService<AssignmentDto, IAssignmentRepository>, IAssignmentService
    {

        public AssignmentService(IAssignmentRepository repository) : base(repository)
        {
        
        }
    }
}
