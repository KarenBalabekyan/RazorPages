using SimpleStore.DataAccess.DbContexts;
using SimpleStore.DataAccess.Entities;
using SimpleStore.DataAccess.Repositories.Interfaces;

namespace SimpleStore.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {

        }


    }
}