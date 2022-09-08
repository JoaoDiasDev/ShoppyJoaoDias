using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class AdminService : IAdminService
    {
        public Admin Add(Admin entity)
        {
            Admin? admin = null;
            using (var context = new DatabaseContext())
            {
                var addAdmin = context.Entry(entity);
                addAdmin.State = EntityState.Added;
                context.SaveChanges();
                admin = entity;
            }
            return admin;
        }

        public bool Delete(Admin entity)
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

        public void Update(Admin entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateAdmin = context.Entry(entity);
                updateAdmin.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Admin GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Admin>().Where(admin => admin.Id == id).FirstOrDefault();
            }
        }

        public Admin Get(Expression<Func<Admin, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Admin>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Admin>().ToList()
                    : context.Set<Admin>().Where(filter).ToList();
            }
        }
    }
}
