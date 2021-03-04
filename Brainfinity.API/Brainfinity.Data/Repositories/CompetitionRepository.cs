using AutoMapper;
using Brainfinity.Data.Entities;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Repositories
{
    public class CompetitionRepository : BaseRepository<Competition, CompetitionDto>, ICompetitionRepository
    {
        public CompetitionRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<List<CompetitionDto>> GetIncomingCompetitionsAsync()
        {
            return mapper.ProjectTo<CompetitionDto>(Entity.Where(c => c.Status.StatusName == StatusNames.Nadolazece)).ToListAsync();
        }
    }
}