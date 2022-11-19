using System.Linq.Expressions;

using AutoMapper;

using DAL.MySqlDbContext;

using Entities;

using Interfaces.BL;
using Interfaces.Services;

using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class AddressBL : IAddressBL
    {
        private IAddressService _AddressService;
        private IMapper _mapper;

        public AddressBL(IServiceProvider serviceProvider)
        {
            _AddressService = serviceProvider.GetRequiredService<IAddressService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public AddressDO Add(AddressDO model)
        {
            AddressDO result = model;
            Address entity;
            try
            {
                entity = _mapper.Map<AddressDO, Address>(model);
                _AddressService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(AddressDO model)
        {
            try
            {
                Address entity = _mapper.Map<AddressDO, Address>(model);
                bool result = _AddressService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AddressDO Get(Expression<Func<Address, bool>> predicate = null)
        {
            AddressDO result;
            try
            {
                Address admin = _AddressService.Get(predicate);
                result = _mapper.Map<Address, AddressDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public AddressDO GetById(int id)
        {
            AddressDO result;
            try
            {
                Address admin = _AddressService.GetById(id);
                result = _mapper.Map<Address, AddressDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<AddressDO> GetList(Expression<Func<AddressDO, bool>> filter = null)
        {
            List<AddressDO> result;
            try
            {
                List<Address> admins = _AddressService.GetList();
                result = _mapper.Map<List<Address>, List<AddressDO>>(admins);
                if (filter != null)
                {
                    result = result.AsQueryable().Where(filter).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public AddressDO Update(AddressDO model)
        {
            AddressDO result = new();
            Address entity;
            try
            {
                entity = _mapper.Map<AddressDO, Address>(model);
                _AddressService.Update(entity);
                result = model;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
