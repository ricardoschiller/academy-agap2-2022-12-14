using Agap2IT.Academy.SuperMarket.Data.Interfaces;
using Agap2IT.Academy.SuperMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Dal
{
    public class GenericDao : IGenericDao
    {
        public async Task Add<T>(T entity) where T : class
        {
            //queremos que o contexto dure pouco
            using (var context = new AcademyAgap213122022Context())
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete<T>(int id) where T : class
        {
            using (var context = new AcademyAgap213122022Context())
            {
                var entity = context.Set<T>().Find(id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete<T>(T entity) where T : class
        {
            using (var context = new AcademyAgap213122022Context())
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update<T>(T entity) where T : class
        {
            using (var context = new AcademyAgap213122022Context())
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }

        }

        public async Task<T> Get<T>(int id) where T : class
        {
            using (var context = new AcademyAgap213122022Context())
            {
                return await context.Set<T>().FindAsync(id);
            }

        }

        public async Task<T> Get<T>(Guid uuid) where T : class, IReferencedEntity
        {
            using (var context = new AcademyAgap213122022Context())
            {
                return await context.Set<T>().Where(i => i.Uuid == uuid).SingleOrDefaultAsync();
            }

        }



        public async Task<List<T>> GetAll<T>() where T : class
        {
            using (var context = new AcademyAgap213122022Context())
            {
                return await context.Set<T>().ToListAsync();
            }
        }
    }
}
