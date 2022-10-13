using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class ProductService : IProductService
    {
        public Product Add(Product entity)
        {
            Product? product = null;
            using (var context = new DatabaseContext())
            {
                var addProduct = context.Entry(entity);
                addProduct.State = EntityState.Added;
                context.SaveChanges();
                product = entity;
            }
            return product;
        }

        public bool Delete(Product entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(Product entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateProduct = context.Entry(entity);
                updateProduct.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Product GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Product>()
                    .Where(product => product.Id == id)
                    .Include(iBrand => iBrand.Brand)
                    .Include(iCategory => iCategory.Category)
                    .Include(iBaskets => iBaskets.Baskets)
                    .Include(iOrderitems => iOrderitems.Orderitems)
                    .Include(iProductImages => iProductImages.ProductImages)
                    .Include(iWishlists => iWishlists.Wishlists)
                    .FirstOrDefault();
            }
        }

        public Product Get(Expression<Func<Product, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Product>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Product>().Include(x => x.Category).Include(x => x.Brand).ToList()
                    : context.Set<Product>().Include(x => x.Category).Include(x => x.Brand).Where(filter).ToList();
            }
        }
    }
}
