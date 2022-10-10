using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class ProductImageService : IProductImageService
    {
        public ProductImage Add(ProductImage entity)
        {
            ProductImage? productImage = null;
            using (var context = new DatabaseContext())
            {
                var addProductImage = context.Entry(entity);
                addProductImage.State = EntityState.Added;
                context.SaveChanges();
                productImage = entity;
            }
            return productImage;
        }

        public bool Delete(ProductImage entity)
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

        public void Update(ProductImage entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateProductImage = context.Entry(entity);
                updateProductImage.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public ProductImage GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<ProductImage>()
                    .Where(address => address.Id == id)
                    .Include(iProd => iProd.Product)
                    .FirstOrDefault();
            }
        }

        public ProductImage Get(Expression<Func<ProductImage, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<ProductImage>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<ProductImage> GetList(Expression<Func<ProductImage, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<ProductImage>().ToList()
                    : context.Set<ProductImage>().Where(filter).ToList();
            }
        }
    }
}
