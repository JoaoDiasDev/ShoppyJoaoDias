using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        private IOrderService _orderService;
        private IMapper _mapper;

        public OrderBL(IServiceProvider serviceProvider)
        {
            _orderService = serviceProvider.GetRequiredService<IOrderService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public OrderDO Add(OrderDO model)
        {
            OrderDO result = model;
            Order entity;
            try
            {
                entity = _mapper.Map<OrderDO, Order>(model);
                _orderService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(OrderDO model)
        {
            try
            {
                Order entity = _mapper.Map<OrderDO, Order>(model);
                bool result = _orderService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OrderDO Get(Expression<Func<Order, bool>> predicate = null)
        {
            OrderDO result;
            try
            {
                Order admin = _orderService.Get(predicate);
                result = _mapper.Map<Order, OrderDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public OrderDO GetById(int id)
        {
            OrderDO result;
            try
            {
                Order admin = _orderService.GetById(id);
                result = _mapper.Map<Order, OrderDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<OrderDO> GetList(Expression<Func<OrderDO, bool>> filter = null)
        {
            List<OrderDO> result;
            try
            {
                List<Order> admins = _orderService.GetList();
                result = _mapper.Map<List<Order>, List<OrderDO>>(admins);
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

        public OrderDO Update(OrderDO model)
        {
            OrderDO result = new();
            Order entity;
            try
            {
                entity = _mapper.Map<OrderDO, Order>(model);
                _orderService.Update(entity);
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
