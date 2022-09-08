using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class OrderitemBL : IOrderitemBL
    {
        private IOrderitemService _orderItemService;
        private IMapper _mapper;

        public OrderitemBL(IServiceProvider serviceProvider)
        {
            _orderItemService = serviceProvider.GetRequiredService<IOrderitemService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public OrderitemDO Add(OrderitemDO model)
        {
            OrderitemDO result = model;
            Orderitem entity;
            try
            {
                entity = _mapper.Map<OrderitemDO, Orderitem>(model);
                _orderItemService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(OrderitemDO model)
        {
            try
            {
                Orderitem entity = _mapper.Map<OrderitemDO, Orderitem>(model);
                bool result = _orderItemService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OrderitemDO Get(Expression<Func<OrderitemDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public OrderitemDO GetById(int id)
        {
            OrderitemDO result;
            try
            {
                Orderitem admin = _orderItemService.GetById(id);
                result = _mapper.Map<Orderitem, OrderitemDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<OrderitemDO> GetList(Expression<Func<OrderitemDO, bool>> filter = null)
        {
            List<OrderitemDO> result;
            try
            {
                List<Orderitem> admins = _orderItemService.GetList();
                result = _mapper.Map<List<Orderitem>, List<OrderitemDO>>(admins);
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

        public OrderitemDO Update(OrderitemDO model)
        {
            OrderitemDO result = new();
            Orderitem entity;
            try
            {
                entity = _mapper.Map<OrderitemDO, Orderitem>(model);
                _orderItemService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
