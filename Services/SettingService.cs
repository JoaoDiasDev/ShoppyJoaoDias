using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class SettingService : ISettingService
    {
        public Setting Add(Setting entity)
        {
            Setting? setting = null;
            using (var context = new DatabaseContext())
            {
                var addSetting = context.Entry(entity);
                addSetting.State = EntityState.Added;
                context.SaveChanges();
                setting = entity;
            }
            return setting;
        }

        public bool Delete(Setting entity)
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

        public void Update(Setting entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateSetting = context.Entry(entity);
                updateSetting.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Setting GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Setting>()
                    .Where(setting => setting.Id == id)
                    .FirstOrDefault();
            }
        }

        public Setting Get(Expression<Func<Setting, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Setting>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Setting> GetList(Expression<Func<Setting, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Setting>().ToList()
                    : context.Set<Setting>().Where(filter).ToList();
            }
        }
    }
}
