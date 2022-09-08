using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        public Category Add(Category entity)
        {
            Category? category = null;
            using (var context = new DatabaseContext())
            {
                var addCategory = context.Entry(entity);
                addCategory.State = EntityState.Added;
                context.SaveChanges();
                category = entity;
            }
            return category;
        }

        public bool Delete(Category entity)
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

        public void Update(Category entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateCategory = context.Entry(entity);
                updateCategory.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Category GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Category>()
                    .Where(category => category.Id == id)
                    .Include(iProducts => iProducts.Products)
                    .FirstOrDefault();
            }
        }

        public Category Get(Expression<Func<Category, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Category>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Category>().ToList()
                    : context.Set<Category>().Where(filter).ToList();
            }
        }
    }
}
