using AutoMapper;
using Brainfinity.Data.Entities;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TDto> : IBaseRepository<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        private readonly ApplicationDbContext context;
        protected readonly IMapper mapper;

        protected DbSet<TEntity> Entity { get; set; }

        protected BaseRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            Entity = context.Set<TEntity>();
        }

        public Task<int> EditEntity(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            Entity.Update(entity);

            return context.SaveChangesAsync();
        }

        public async Task<TDto> GetEntityById(Guid id)
        {
            var entity = await Entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return mapper.Map<TDto>(entity);
        }

        public async Task<List<TDto>> GetEntityPaginated(int page, int pageItemCount)
        {
            var entities = Entity.Skip((page - 1) * pageItemCount).Take(pageItemCount);
            return await mapper.ProjectTo<TDto>(entities).ToListAsync();
        }

        public async Task<Guid> InsertEntity(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            Entity.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public Task<int> RemoveEntity(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            Entity.Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}