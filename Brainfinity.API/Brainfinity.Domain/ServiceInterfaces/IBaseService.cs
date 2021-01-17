using Brainfinity.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ServiceInterfaces
{
    public interface IBaseService<TDto>
        where TDto : BaseDto
    {
        public Task<Guid> InsertEntity(TDto dto);

        public Task<TDto> GetEntityById(Guid id);

        public Task<List<TDto>> GetEntitiesPaginated(int page, int pageItemCount);

        public Task<int> RemoveEntity(Guid id);

        public Task<int> UpdateEntity(Guid id);
    }
}