using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class BankInstallmentService : IBankInstallmentService
    {
        public BankInstallment Add(BankInstallment entity)
        {
            BankInstallment? bankInstallment = null;
            using (var context = new DatabaseContext())
            {
                var addBankInstallment = context.Entry(entity);
                addBankInstallment.State = EntityState.Added;
                context.SaveChanges();
                bankInstallment = entity;
            }
            return bankInstallment;
        }

        public bool Delete(BankInstallment entity)
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

        public void Update(BankInstallment entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateBankInstallment = context.Entry(entity);
                updateBankInstallment.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public BankInstallment GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<BankInstallment>()
                    .Where(bankInstallment => bankInstallment.Id == id)
                    .Include(iBank => iBank.Bank)
                    .FirstOrDefault();
            }
        }

        public BankInstallment Get(Expression<Func<BankInstallment, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<BankInstallment>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<BankInstallment> GetList(Expression<Func<BankInstallment, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<BankInstallment>().ToList()
                    : context.Set<BankInstallment>().Where(filter).ToList();
            }
        }
    }
}
