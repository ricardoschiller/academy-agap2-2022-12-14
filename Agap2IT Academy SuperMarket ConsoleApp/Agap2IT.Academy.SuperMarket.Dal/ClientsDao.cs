using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agap2IT.Academy.SuperMarket.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Agap2IT.Academy.SuperMarket.Dal
{
    public class ClientsDao
    {
        public async Task Add(Client client)
        {
            //queremos que o contexto dure pouco
            using (var context = new AcademyAgap213122022Context())
            {
                context.Clients.Add(client);
                await context.SaveChangesAsync();
            }    
        }

        public async Task Delete(int id)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                var client = context.Clients.Find(id);
                context.Clients.Remove(client);
                await context.SaveChangesAsync();
            }   
        }

        public async Task Delete(Client client)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                context.Clients.Remove(client);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Client client)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                context.Clients.Update(client);
                await context.SaveChangesAsync();
            }
                
        }

        public async Task<Client> Get(int id)
        {
            using (var context = new AcademyAgap213122022Context())
            {
                return await context.Clients.FindAsync(id);
            }
                
        }

        public async Task<List<Client>> GetAll()
        {
            using (var context = new AcademyAgap213122022Context())
            {
                return await context.Clients.ToListAsync();
            }
        }
    }
}
