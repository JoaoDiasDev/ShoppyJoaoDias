using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class SliderService : ISliderService
    {
        public Slider Add(Slider entity)
        {
            Slider? unit = null;
            using (var context = new DatabaseContext())
            {
                var addUnit = context.Entry(entity);
                addUnit.State = EntityState.Added;
                context.SaveChanges();
                unit = entity;
            }
            return unit;
        }

        public bool Delete(Slider entity)
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

        public void Update(Slider entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateUnit = context.Entry(entity);
                updateUnit.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Slider GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Slider>()
                    .Where(unit => unit.Id == id)
                    .FirstOrDefault();
            }
        }

        public Slider Get(Expression<Func<Slider, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Slider>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Slider> GetList(Expression<Func<Slider, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Slider>().ToList()
                    : context.Set<Slider>().Where(filter).ToList();
            }
        }
    }
}
