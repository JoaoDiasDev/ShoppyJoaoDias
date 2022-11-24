using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ResetPasswordService : IResetPasswordService
    {
        public ResetPassword Add(ResetPassword entity)
        {
            ResetPassword? result = null;
            using (var context = new DatabaseContext())
            {
                var addProvince = context.Entry(entity);
                addProvince.State = EntityState.Added;
                context.SaveChanges();
                result = entity;
            }
            return result;
        }

        public bool Delete(ResetPassword entity)
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

        public void Update(ResetPassword entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateProvince = context.Entry(entity);
                updateProvince.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public ResetPassword GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<ResetPassword>()
                    .Where(x => x.Id == id)
                    .Include(i => i.User)
                    .FirstOrDefault();
            }
        }

        public ResetPassword Get(Expression<Func<ResetPassword, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<ResetPassword>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<ResetPassword> GetList(Expression<Func<ResetPassword, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<ResetPassword>().ToList()
                    : context.Set<ResetPassword>().Where(filter).ToList();
            }
        }
    }
}
