using Agap2IT.Academy.SuperMarket.Dal;
using Agap2IT.Academy.SuperMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Business
{
    public class ClientsBO : BaseBO, IClientsBO
    {
        private IGenericDao _genericDao;
        public ClientsBO(IGenericDao genericDao)
        {
            _genericDao = genericDao;
        }

        public async Task<OpResult<List<Client>>> GetAllClients()
        {
            return await GetResult<List<Client>>(async () =>
            {
                
                var results = await _genericDao.GetAll<Client>();
                return results;
            });
        }
    }
}
