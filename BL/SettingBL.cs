using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class SettingBL : ISettingBL
    {
        private ISettingService _settingService;
        private IMapper _mapper;

        public SettingBL(IServiceProvider serviceProvider)
        {
            _settingService = serviceProvider.GetRequiredService<ISettingService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public SettingDO Add(SettingDO model)
        {
            SettingDO result = model;
            Setting entity;
            try
            {
                entity = _mapper.Map<SettingDO, Setting>(model);
                _settingService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(SettingDO model)
        {
            try
            {
                Setting entity = _mapper.Map<SettingDO, Setting>(model);
                bool result = _settingService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SettingDO Get(Expression<Func<SettingDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public SettingDO GetById(int id)
        {
            SettingDO result;
            try
            {
                Setting admin = _settingService.GetById(id);
                result = _mapper.Map<Setting, SettingDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<SettingDO> GetList(Expression<Func<SettingDO, bool>> filter = null)
        {
            List<SettingDO> result;
            try
            {
                List<Setting> admins = _settingService.GetList();
                result = _mapper.Map<List<Setting>, List<SettingDO>>(admins);
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

        public SettingDO Update(SettingDO model)
        {
            SettingDO result = new();
            Setting entity;
            try
            {
                entity = _mapper.Map<SettingDO, Setting>(model);
                _settingService.Update(entity);
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
