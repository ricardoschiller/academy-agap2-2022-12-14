using Agap2IT.Academy.SuperMarket.Dal;
using Agap2IT.Academy.SuperMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Agap2IT.Academy.SuperMarket.Business
{
    public class BaseBO
    {


        public async Task<OpResult<T>> GetResult<T>(Func<Task<T>> annonymousFunc) where T : class
        {
            try
            {
                var transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = IsolationLevel.RepeatableRead;
                transactionOptions.Timeout = TimeSpan.FromSeconds(30);
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    T result = await annonymousFunc.Invoke();

                    transactionScope.Complete();

                    return new OpResult<T>(result);

                }

            }
            catch (Exception ex)
            {
                return new OpResult<T>(ex);
            }


        }


    }
}
