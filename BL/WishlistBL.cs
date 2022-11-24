using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class WishlistBL : IWishlistBL
    {
        private IWishlistService _wishlistService;
        private IMapper _mapper;

        public WishlistBL(IServiceProvider serviceProvider)
        {
            _wishlistService = serviceProvider.GetRequiredService<IWishlistService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public WishlistDO Add(WishlistDO model)
        {
            WishlistDO result = model;
            Wishlist entity;
            try
            {
                entity = _mapper.Map<WishlistDO, Wishlist>(model);
                _wishlistService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(WishlistDO model)
        {
            try
            {
                Wishlist entity = _mapper.Map<WishlistDO, Wishlist>(model);
                bool result = _wishlistService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public WishlistDO Get(Expression<Func<Wishlist, bool>> predicate = null)
        {
            WishlistDO result;
            try
            {
                Wishlist admin = _wishlistService.Get(predicate);
                result = _mapper.Map<Wishlist, WishlistDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public WishlistDO GetById(int id)
        {
            WishlistDO result;
            try
            {
                Wishlist admin = _wishlistService.GetById(id);
                result = _mapper.Map<Wishlist, WishlistDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<WishlistDO> GetList(Expression<Func<WishlistDO, bool>> filter = null)
        {
            List<WishlistDO> result;
            try
            {
                List<Wishlist> admins = _wishlistService.GetList();
                result = _mapper.Map<List<Wishlist>, List<WishlistDO>>(admins);
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

        public WishlistDO Update(WishlistDO model)
        {
            WishlistDO result = new();
            Wishlist entity;
            try
            {
                entity = _mapper.Map<WishlistDO, Wishlist>(model);
                _wishlistService.Update(entity);
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
