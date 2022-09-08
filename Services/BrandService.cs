using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class BrandService : IBrandService
    {
        public Brand Add(Brand entity)
        {
            Brand? brand = null;
            using (var context = new DatabaseContext())
            {
                var addBrand = context.Entry(entity);
                addBrand.State = EntityState.Added;
                context.SaveChanges();
                brand = entity;
            }
            return brand;
        }

        public bool Delete(Brand entity)
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

        public void Update(Brand entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateBrand = context.Entry(entity);
                updateBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Brand GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Brand>()
                    .Where(brand => brand.Id == id)
                    .Include(iProducts => iProducts.Products)
                    .FirstOrDefault();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Brand>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Brand> GetList(Expression<Func<Brand, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }
    }
}
