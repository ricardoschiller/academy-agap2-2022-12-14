using Agap2IT.Academy.SuperMarket.Data.Models;

namespace Agap2IT.Academy.SuperMarket.Business
{
    public interface IClientsBO
    {
        Task<OpResult<List<Client>>> GetAllClients();
    }
}