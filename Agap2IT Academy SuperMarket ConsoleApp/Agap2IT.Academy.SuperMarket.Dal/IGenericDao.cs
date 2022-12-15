using Agap2IT.Academy.SuperMarket.Data.Interfaces;

namespace Agap2IT.Academy.SuperMarket.Dal
{
    public interface IGenericDao
    {
        Task Add<T>(T entity) where T : class;
        Task Delete<T>(int id) where T : class;
        Task Delete<T>(T entity) where T : class;
        Task<T> Get<T>(Guid uuid) where T : class, IReferencedEntity;
        Task<T> Get<T>(int id) where T : class;
        Task<List<T>> GetAll<T>() where T : class;
        Task Update<T>(T entity) where T : class;
    }
}