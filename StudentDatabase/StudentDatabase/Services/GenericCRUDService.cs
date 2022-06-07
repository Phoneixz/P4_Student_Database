using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentDatabase.Models;

namespace StudentDatabase.Services
{
    public class GenericCRUDService<T> : ICRUDService<T> where T: IDObject
    {
        private readonly StudentDatabaseDbContextFactory _ContextFactory;

        public GenericCRUDService(StudentDatabaseDbContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (StudentDatabaseDbContext context = _ContextFactory.CreateDbContext())
            {
                EntityEntry<T> newEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return newEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (StudentDatabaseDbContext context = _ContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e => e.Id == id));
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (StudentDatabaseDbContext context = _ContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e => e.Id == id));
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (StudentDatabaseDbContext context = _ContextFactory.CreateDbContext())
            {
                IEnumerable<T> allentities = await context.Set<T>().ToListAsync();
                return allentities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (StudentDatabaseDbContext context = _ContextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
                
            }

        }
    }
}
