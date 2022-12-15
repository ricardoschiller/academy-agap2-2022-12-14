using Agap2IT.Academy.SuperMarket.Dal;
using Agap2IT.Academy.SuperMarket.Data.Models;
using System.Transactions;

namespace Agap2IT.Academy.SuperMarket.Business
{
    public class ProductsBO : BaseBO
    {
        public async Task<OpResult> RegisterClientAndAddProductToCart(Client client, Cart cart, Guid productUuid)
        {
            try
            {
                var transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = IsolationLevel.RepeatableRead;
                transactionOptions.Timeout = TimeSpan.FromSeconds(30);
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var dao = new GenericDao();

                    var product = await dao.Get<Product>(productUuid);

                    await dao.Add(client);

                    cart.ProductId = product.Id;

                    await dao.Add(cart);

                    transactionScope.Complete();
                    return new OpResult();
                }
            }
            catch(Exception ex)
            {
                return new OpResult(ex);
            }
        }

        public async Task<OpResult<Client>> GetClientAsync(Guid uuid)
        {
            var opResult = await GetResult(async () =>
            {
                var dao = new GenericDao();
                var result = await dao.Get<Client>(uuid);
                return result;
            });

            return opResult;
        }
    }
}
