using game_maps.Domain.Base;
using game_maps.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace game_maps.Infrastructure.Base
{
    public class BaseRepository<TEntity, TIdentity>(GameMapsDbContext context) : IRepository<TEntity, TIdentity>
        where TEntity : Entity<TIdentity>, new()
    {
        public IQueryable<TEntity> AsQueryable()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> exp)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(exp);
        }

        public async Task<ICollection<TEntity>> ToListAsync()
        {
            return await AsQueryable().ToListAsync();
        }

        public async Task<ICollection<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> exp)
        {
            return await AsQueryable().Where(exp).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<TEntity>> AddAsync(IList<TEntity> entities)
        {
            var set = context.Set<TEntity>();
            await set.AddRangeAsync(entities);
            await context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<TEntity>> UpdateAsync(IList<TEntity> entity)
        {
            context.Set<TEntity>().UpdateRange(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> AddOrUpdateAsync(Expression<Func<TEntity, bool>> exp, Action<TEntity> updateEntity)
        {
            TEntity entity;
            var existingEntity = await context.Set<TEntity>().FirstOrDefaultAsync(exp);
            if (existingEntity != null)
            {
                entity = existingEntity;
            }
            else
            {
                entity = new TEntity();
                await context.Set<TEntity>().AddAsync(entity);
            }

            updateEntity(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> AddOrUpdateAsync(TEntity entity)
        {
            var existingEntity = await context.Set<TEntity>().FindAsync(entity.Id);
            if (existingEntity is not null)
            {
                var entry = context.Entry(existingEntity);
                var entityType = typeof(TEntity);
                var properties = entityType.GetProperties();

                foreach (var property in properties)
                {
                    var currentValue = property.GetValue(existingEntity);
                    var newValue = property.GetValue(entity);
                    if (newValue != null && !object.Equals(currentValue, newValue))
                    {
                        entry.Property(property.Name).CurrentValue = newValue;
                        entry.Property(property.Name).IsModified = true;
                    }
                }

                //await context.SaveChangesAsync();
                return entry.Entity;
            }
            else
            {
                await context.Set<TEntity>().AddAsync(entity);
                //await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(IList<TEntity> entities)
        {
            var entitySet = context.Set<TEntity>();
            entitySet.RemoveRange(entities);
            await context.SaveChangesAsync();
        }
    }
}

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    private readonly GameMapsDbContext context;

    public BaseRepository(GameMapsDbContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> AddOrUpdateAsync(Expression<Func<TEntity, bool>> exp, Action<TEntity> updateEntity)
    {
        TEntity entity;
        var existingEntity = await context.Set<TEntity>().FirstOrDefaultAsync(exp);
        if (existingEntity != null)
        {
            entity = existingEntity;
        }
        else
        {
            entity = new TEntity();
            await context.Set<TEntity>().AddAsync(entity);
        }

        updateEntity(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return context.Set<TEntity>().AsQueryable();
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> exp)
    {
        var entity = await context.Set<TEntity>().FirstOrDefaultAsync(exp);
        if (entity != null)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> exp)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(exp);
    }

    public async Task<ICollection<TEntity>> ToListAsync()
    {
        return await AsQueryable().ToListAsync();
    }

    public async Task<ICollection<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> exp)
    {
        return await AsQueryable().Where(exp).ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}