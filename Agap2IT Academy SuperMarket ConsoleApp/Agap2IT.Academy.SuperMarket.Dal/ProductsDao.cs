using Agap2IT.Academy.SuperMarket.Data.Models;
using Agap2IT.Academy.SuperMarket.Data.Pocos.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Dal
{
    public class ProductsDao : BaseDao
    {
        public async Task<List<Product>> GetProductsByCategoryName(string category)
        {
            using(var context = CreateContext())
            {
                var result = await (from p in context.Products
                        join c in context.Categories on p.CategoryId equals c.Id
                        where c.Name == category
                        select p).ToListAsync();

                return result;
            }
        }

        public async Task<List<Product>> GetProductsInClientShoppingCart(int clientId)
        {
            using(var context = CreateContext())
            {
                var query = (from client in context.Clients
                             join cart in context.Carts on client.Id equals cart.ClientId
                             join product in context.Products on cart.ProductId equals product.Id
                             where client.Id == clientId
                             select product);

                query = query.OrderBy(p => p.CreatedAt);

                query = query.Take(10);

                var result = await query.ToListAsync();

                
                
                return result;
                
            }
        }

        public async Task<List<Category>> GetClientChosenCategories(int clientId)
        {
            using (var context = CreateContext())
            {

                context.ChangeTracker.AutoDetectChangesEnabled = false; 
                
                var query = (from client in context.Clients
                             join cart in context.Carts on client.Id equals cart.ClientId
                             join product in context.Products on cart.ProductId equals product.Id
                             join category in context.Categories on product.CategoryId equals category.Id
                             where client.Id == clientId
                             select category);


                var result = await query.ToListAsync();

                return result;

            }
        }


        public async Task<List<Category>> GetCategoriesFromProductsInCart(int cartId)
        {
            using (var context = CreateContext())
            {
                var query = (from c in context.Carts
                             join p in context.Products on cartId equals p.CategoryId
                             join category in context.Categories on p.CategoryId equals category.Id
                             where c.Id == cartId
                             select category);

                var result = await query.ToListAsync();
                return result;
            }

        }

        public async Task<List<ProductsAndCategoriesPoco>> GetAllProductsAndTheirCategories()
        {
            using (var context = CreateContext())
            {
                var query = (from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.Id
                             select new ProductsAndCategoriesPoco
                             {
                                 CategoryName = c.Name,
                                 ProductName = p.Name,
                                 ProductPrice = p.Price,
                                 ProductUuid = p.Uuid
                             });

                var result = await query.ToListAsync();

                return result;
            }
        }
    }
}
