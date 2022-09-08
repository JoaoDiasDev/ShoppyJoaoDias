using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class UserBL : IUserBL
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserBL(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public UserDO Add(UserDO model)
        {
            UserDO result = model;
            User entity;
            try
            {
                entity = _mapper.Map<UserDO, User>(model);
                _userService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(UserDO model)
        {
            try
            {
                User entity = _mapper.Map<UserDO, User>(model);
                bool result = _userService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserDO Get(Expression<Func<UserDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public UserDO GetById(int id)
        {
            UserDO result;
            try
            {
                User admin = _userService.GetById(id);
                result = _mapper.Map<User, UserDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<UserDO> GetList(Expression<Func<UserDO, bool>> filter = null)
        {
            List<UserDO> result;
            try
            {
                List<User> admins = _userService.GetList();
                result = _mapper.Map<List<User>, List<UserDO>>(admins);
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

        public UserDO Update(UserDO model)
        {
            UserDO result = new();
            User entity;
            try
            {
                entity = _mapper.Map<UserDO, User>(model);
                _userService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
