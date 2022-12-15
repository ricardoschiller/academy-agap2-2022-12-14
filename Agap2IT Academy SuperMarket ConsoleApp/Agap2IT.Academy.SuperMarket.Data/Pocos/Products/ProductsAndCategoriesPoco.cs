using Agap2IT.Academy.SuperMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Data.Pocos.Products
{
    public class ProductsAndCategoriesPoco
    {


        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public Guid ProductUuid { get; set; }

        public string CategoryName { get; set; }

    }
}
