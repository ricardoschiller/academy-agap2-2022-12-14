using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Business
{
    public class OpResult
    {
        public bool HasSucceeded { get; set; }
        public Exception Exception { get; set; }

        public OpResult()
        {
            HasSucceeded = true;
        }

        public OpResult(Exception ex)
        {
            HasSucceeded = false;
            Exception = ex;
        }
    }

    public class OpResult<T> : OpResult
    {
        public T Result { get; set; }

        public OpResult(T result)
        {
            Result = result;
        }

        public OpResult(Exception ex) : base(ex)
        {
        }
    }
}
