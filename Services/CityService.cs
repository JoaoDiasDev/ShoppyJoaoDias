using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class CityService : ICityService
    {
        public City Add(City entity)
        {
            City? city = null;
            using (var context = new DatabaseContext())
            {
                var addCity = context.Entry(entity);
                addCity.State = EntityState.Added;
                context.SaveChanges();
                city = entity;
            }
            return city;
        }

        public bool Delete(City entity)
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

        public void Update(City entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateCity = context.Entry(entity);
                updateCity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public City GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<City>()
                    .Where(city => city.Id == id)
                    .Include(iProvince => iProvince.Province)
                    .Include(iAddresses => iAddresses.Addresses)
                    .Include(iUsers => iUsers.Users)
                    .FirstOrDefault();
            }
        }

        public City Get(Expression<Func<City, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<City>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<City> GetList(Expression<Func<City, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<City>().Include(x => x.Province).ToList()
                    : context.Set<City>().Include(x => x.Province).Where(filter).ToList();
            }
        }
    }
}
