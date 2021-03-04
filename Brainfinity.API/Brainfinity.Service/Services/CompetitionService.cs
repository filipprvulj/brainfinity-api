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
    public class CompetitionService : BaseService<CompetitionDto, ICompetitionRepository>, ICompetitionService
    {
        public CompetitionService(ICompetitionRepository repository) : base(repository)
        {
        }

        public Task<List<CompetitionDto>> GetIncomingCompetitionsAsync()
        {
            return repository.GetIncomingCompetitionsAsync();
        }
    }
}