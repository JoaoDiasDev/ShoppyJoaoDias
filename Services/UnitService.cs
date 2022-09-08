using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class UnitService : IUnitService
    {
        public Unit Add(Unit entity)
        {
            Unit? unit = null;
            using (var context = new DatabaseContext())
            {
                var addUnit = context.Entry(entity);
                addUnit.State = EntityState.Added;
                context.SaveChanges();
                unit = entity;
            }
            return unit;
        }

        public bool Delete(Unit entity)
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

        public void Update(Unit entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateUnit = context.Entry(entity);
                updateUnit.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Unit GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Unit>()
                    .Where(unit => unit.Id == id)
                    .Include(iProducts => iProducts.Products)
                    .FirstOrDefault();
            }
        }

        public Unit Get(Expression<Func<Unit, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Unit>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Unit> GetList(Expression<Func<Unit, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Unit>().ToList()
                    : context.Set<Unit>().Where(filter).ToList();
            }
        }
    }
}
