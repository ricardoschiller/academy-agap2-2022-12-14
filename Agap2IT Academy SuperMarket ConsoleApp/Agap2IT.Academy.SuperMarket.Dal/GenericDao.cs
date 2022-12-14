using Agap2IT.Academy.SuperMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Dal
{
    public class GenericDao <T> where T : class
    {

        public async Task Add(T obj)
        {
            //queremos que o contexto dure pouco
            using (var context = new AcademyAgap213122022Context())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }


        public async Task Delete(int id)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                var obj = context.Set<T>().Find(id);
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(T obj)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }

        }

        public async Task<T> Get(int id)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                return await context.Set<T>().FindAsync(id);
            }

        }

        public async Task<List<T>> GetAll()
        {
            using (var context = new AcademyAgap213122022Context())
            {
                return await context.Set<T>().ToListAsync();
            }
        }
    

}
}
