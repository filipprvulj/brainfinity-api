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
    public class BaseRepository<TEntity, TDto> : IBaseRepository<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public Task<int> EditEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDto>> GetEntityPaginated(int page, int pageItemCount)
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
    }
}