using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class BasketBL : IBasketBL
    {
        private IBasketService _basketService;
        private IMapper _mapper;

        public BasketBL(IServiceProvider serviceProvider)
        {
            _basketService = serviceProvider.GetRequiredService<IBasketService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BasketDO Add(BasketDO model)
        {
            BasketDO result = model;
            Basket entity;
            try
            {
                entity = _mapper.Map<BasketDO, Basket>(model);
                _basketService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(BasketDO model)
        {
            try
            {
                Basket entity = _mapper.Map<BasketDO, Basket>(model);
                bool result = _basketService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteID(int basketId)
        {
            try
            {
                bool result = _basketService.DeleteID(basketId);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAll(int userId)
        {
            try
            {
                bool result = _basketService.DeleteAll(userId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BasketDO Get(Expression<Func<Basket, bool>> predicate = null)
        {
            var result = new BasketDO();
            try
            {
                var basket = _basketService.Get(predicate);
                result = _mapper.Map<Basket, BasketDO>(basket);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public BasketDO GetById(int id)
        {
            BasketDO result;
            try
            {
                Basket admin = _basketService.GetById(id);
                result = _mapper.Map<Basket, BasketDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<BasketDO> GetList(Expression<Func<BasketDO, bool>> filter = null)
        {
            List<BasketDO> result;
            try
            {
                List<Basket> admins = _basketService.GetList();
                result = _mapper.Map<List<Basket>, List<BasketDO>>(admins);
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

        public BasketDO Update(BasketDO model)
        {
            BasketDO result = new();
            Basket entity;
            try
            {
                entity = _mapper.Map<BasketDO, Basket>(model);
                _basketService.Update(entity);
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
