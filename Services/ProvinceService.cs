using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class ProvinceService : IProvinceService
    {
        public Province Add(Province entity)
        {
            Province? province = null;
            using (var context = new DatabaseContext())
            {
                var addProvince = context.Entry(entity);
                addProvince.State = EntityState.Added;
                context.SaveChanges();
                province = entity;
            }
            return province;
        }

        public bool Delete(Province entity)
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

        public void Update(Province entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateProvince = context.Entry(entity);
                updateProvince.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Province GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Province>()
                    .Where(province => province.Id == id)
                    .Include(iCities => iCities.Cities)
                    .FirstOrDefault();
            }
        }

        public Province Get(Expression<Func<Province, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Province>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Province> GetList(Expression<Func<Province, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Province>().ToList()
                    : context.Set<Province>().Where(filter).ToList();
            }
        }
    }
}
