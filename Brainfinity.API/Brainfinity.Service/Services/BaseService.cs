using Brainfinity.Data.Repositories;
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
    public abstract class BaseService<TDto, TRepository> : IBaseService<TDto>
        where TDto : BaseDto
        where TRepository : IBaseRepository<TDto>
    {
        protected readonly TRepository repository;

        protected BaseService(TRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<TDto>> GetEntitiesPaginated(int page, int pageItemCount)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertEntity(TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEntity(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}