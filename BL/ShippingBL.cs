using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class ShippingBL : IShippingBL
    {
        private IShippingService _shippingService;
        private IMapper _mapper;

        public ShippingBL(IServiceProvider serviceProvider)
        {
            _shippingService = serviceProvider.GetRequiredService<IShippingService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ShippingDO Add(ShippingDO model)
        {
            ShippingDO result = model;
            Shipping entity;
            try
            {
                entity = _mapper.Map<ShippingDO, Shipping>(model);
                _shippingService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(ShippingDO model)
        {
            try
            {
                Shipping entity = _mapper.Map<ShippingDO, Shipping>(model);
                bool result = _shippingService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ShippingDO Get(Expression<Func<ShippingDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public ShippingDO GetById(int id)
        {
            ShippingDO result;
            try
            {
                Shipping admin = _shippingService.GetById(id);
                result = _mapper.Map<Shipping, ShippingDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ShippingDO> GetList(Expression<Func<ShippingDO, bool>> filter = null)
        {
            List<ShippingDO> result;
            try
            {
                List<Shipping> admins = _shippingService.GetList();
                result = _mapper.Map<List<Shipping>, List<ShippingDO>>(admins);
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

        public ShippingDO Update(ShippingDO model)
        {
            ShippingDO result = new();
            Shipping entity;
            try
            {
                entity = _mapper.Map<ShippingDO, Shipping>(model);
                _shippingService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
