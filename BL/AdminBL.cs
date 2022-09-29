using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class AdminBL : IAdminBL
    {
        private IAdminService _adminService;
        private IMapper _mapper;

        public AdminBL(IServiceProvider serviceProvider)
        {
            _adminService = serviceProvider.GetRequiredService<IAdminService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public AdminDO Add(AdminDO model)
        {
            AdminDO result = model;
            Admin entity;
            try
            {
                entity = _mapper.Map<AdminDO, Admin>(model);
                _adminService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(AdminDO model)
        {
            try
            {
                Admin entity = _mapper.Map<AdminDO, Admin>(model);
                bool result = _adminService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AdminDO Get(Expression<Func<AdminDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public AdminDO GetById(int id)
        {
            AdminDO result;
            try
            {
                Admin admin = _adminService.GetById(id);
                result = _mapper.Map<Admin, AdminDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<AdminDO> GetList(Expression<Func<AdminDO, bool>> filter = null)
        {
            List<AdminDO> result;
            try
            {
                List<Admin> admins = _adminService.GetList();
                result = _mapper.Map<List<Admin>, List<AdminDO>>(admins);
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

        public AdminDO Login(AdminDO model)
        {
            AdminDO result;
            try
            {
                Admin admin = _adminService.Get(admin => admin.Username == model.Username);
                result = _mapper.Map<Admin, AdminDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public AdminDO Update(AdminDO model)
        {
            AdminDO result = model;
            Admin entity;
            try
            {
                entity = _mapper.Map<AdminDO, Admin>(model);
                _adminService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
