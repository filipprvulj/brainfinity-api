using Brainfinity.Data.Repositories;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ServiceInterfaces;
using Brainfinity.Service.ErrorHandling;
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
            return repository.GetEntityPaginated(page, pageItemCount);
        }

        public async Task<TDto> GetEntityById(Guid id)
        {
            var entity = await repository.GetEntityById(id);

            if (entity == null)
            {
                throw new NotFoundException("Not found exception occured.");
            }

            return entity;
        }

        public async Task<Guid> InsertEntity(TDto dto)
        {
            return await repository.InsertEntity(dto);
        }

        public async Task<int> RemoveEntity(Guid id)
        {
            var entity = await GetEntityById(id);
            return await repository.RemoveEntity(entity);
        }

        public Task<int> UpdateEntity(TDto dto)
        {
            return repository.EditEntity(dto);
        }
    }
}