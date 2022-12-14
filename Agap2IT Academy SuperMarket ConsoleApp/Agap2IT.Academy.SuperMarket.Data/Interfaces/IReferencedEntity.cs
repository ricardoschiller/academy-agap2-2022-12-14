using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Data.Interfaces
{
    public interface IReferencedEntity
    {
        public Guid Uuid { get; set; }
    }
}
