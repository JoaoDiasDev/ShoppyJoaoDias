using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class PageService : IPageService
    {
        public Page Add(Page entity)
        {
            Page? page = null;
            using (var context = new DatabaseContext())
            {
                var addPage = context.Entry(entity);
                addPage.State = EntityState.Added;
                context.SaveChanges();
                page = entity;
            }
            return page;
        }

        public bool Delete(Page entity)
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

        public void Update(Page entity)
        {
            using (var context = new DatabaseContext())
            {
                var updatePage = context.Entry(entity);
                updatePage.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Page GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Page>()
                    .Where(page => page.Id == id)
                    .FirstOrDefault();
            }
        }

        public Page Get(Expression<Func<Page, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Page>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Page> GetList(Expression<Func<Page, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Page>().ToList()
                    : context.Set<Page>().Where(filter).ToList();
            }
        }
    }
}
