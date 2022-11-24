using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class ResetPasswordBL : IResetPasswordBL
    {
        private IResetPasswordService _resetPasswordService;
        private IMapper _mapper;

        public ResetPasswordBL(IServiceProvider serviceProvider)
        {
            _resetPasswordService = serviceProvider.GetRequiredService<IResetPasswordService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ResetPasswordDO Add(ResetPasswordDO model)
        {
            ResetPasswordDO result = model;
            ResetPassword entity;
            try
            {
                entity = _mapper.Map<ResetPasswordDO, ResetPassword>(model);
                _resetPasswordService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(ResetPasswordDO model)
        {
            try
            {
                ResetPassword entity = _mapper.Map<ResetPasswordDO, ResetPassword>(model);
                bool result = _resetPasswordService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ResetPasswordDO Get(Expression<Func<ResetPassword, bool>> predicate = null)
        {
            ResetPasswordDO result;
            try
            {
                ResetPassword resetPassword = _resetPasswordService.Get(predicate);
                result = _mapper.Map<ResetPassword, ResetPasswordDO>(resetPassword);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public ResetPasswordDO GetById(int id)
        {
            ResetPasswordDO result;
            try
            {
                ResetPassword admin = _resetPasswordService.GetById(id);
                result = _mapper.Map<ResetPassword, ResetPasswordDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ResetPasswordDO> GetList(Expression<Func<ResetPasswordDO, bool>> filter = null)
        {
            List<ResetPasswordDO> result;
            try
            {
                List<ResetPassword> passwords = _resetPasswordService.GetList();
                result = _mapper.Map<List<ResetPassword>, List<ResetPasswordDO>>(passwords);
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

        public ResetPasswordDO Update(ResetPasswordDO model)
        {
            ResetPasswordDO result = new();
            ResetPassword entity;
            try
            {
                entity = _mapper.Map<ResetPasswordDO, ResetPassword>(model);
                _resetPasswordService.Update(entity);
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
