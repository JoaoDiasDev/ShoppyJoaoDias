using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services
{
    public class AddressService : IAddressService
    {
        public Address Add(Address entity)
        {
            Address? address = null;
            using (var context = new DatabaseContext())
            {
                var addAddress = context.Entry(entity);
                addAddress.State = EntityState.Added;
                context.SaveChanges();
                address = entity;
            }
            return address;
        }

        public bool Delete(Address entity)
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

        public void Update(Address entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateAddress = context.Entry(entity);
                updateAddress.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Address GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Address>()
                    .Where(address => address.Id == id)
                    .Include(iUser => iUser.User)
                    .Include(iCity => iCity.City)
                    .Include(iOrderDeliveryAddress => iOrderDeliveryAddress.OrderDeliveryAddresses)
                    .Include(iOrderInvoiceAddress => iOrderInvoiceAddress.OrderInvoiceAddresses)
                    .FirstOrDefault();
            }
        }

        public Address Get(Expression<Func<Address, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Address>().FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Address> GetList(Expression<Func<Address, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Address>().ToList()
                    : context.Set<Address>().Where(filter).ToList();
            }
        }
    }
}
