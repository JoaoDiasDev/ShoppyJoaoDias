using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class BankService : IBankService
    {
        public Bank Add(Bank entity)
        {
            Bank? bank = null;
            using (var context = new DatabaseContext())
            {
                var addBank = context.Entry(entity);
                addBank.State = EntityState.Added;
                context.SaveChanges();
                bank = entity;
            }
            return bank;
        }

        public bool Delete(Bank entity)
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

        public void Update(Bank entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateBank = context.Entry(entity);
                updateBank.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Bank GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Bank>()
                    .Where(bank => bank.Id == id)
                    .Include(iBankInstallments => iBankInstallments.BankInstallments)
                    .FirstOrDefault();
            }
        }

        public Bank Get(Expression<Func<Bank, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Bank>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Bank> GetList(Expression<Func<Bank, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Bank>().ToList()
                    : context.Set<Bank>().Where(filter).ToList();
            }
        }
    }
}
