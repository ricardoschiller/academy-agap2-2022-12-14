using Agap2IT.Academy.SuperMarket.Dal;
using Agap2IT.Academy.SuperMarket.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Agap2IT.Academy.SuperMarket.Business
{
    public class ProductsBO
    {
        public async Task RegisterClientAndAddProductToCart(Client client, Cart cart, Guid productUuid)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.RepeatableRead;
            transactionOptions.Timeout = TimeSpan.FromSeconds(30);
            using(var transactionScope = new TransactionScope(TransactionScopeOption.Required,transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                var dao = new GenericDao();

                var product = await dao.Get<Product>(productUuid);

                await dao.Add(client);

                cart.ProductId = product.Id;

                await dao.Add(cart);

                transactionScope.Complete();
            }             
        }
    }
}
