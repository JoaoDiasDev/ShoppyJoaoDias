using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class ProvinceBL : IProvinceBL
    {
        private IProvinceService _provinceService;
        private IMapper _mapper;

        public ProvinceBL(IServiceProvider serviceProvider)
        {
            _provinceService = serviceProvider.GetRequiredService<IProvinceService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ProvinceDO Add(ProvinceDO model)
        {
            ProvinceDO result = model;
            Province entity;
            try
            {
                entity = _mapper.Map<ProvinceDO, Province>(model);
                _provinceService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(ProvinceDO model)
        {
            try
            {
                Province entity = _mapper.Map<ProvinceDO, Province>(model);
                bool result = _provinceService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProvinceDO Get(Expression<Func<ProvinceDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public ProvinceDO GetById(int id)
        {
            ProvinceDO result;
            try
            {
                Province admin = _provinceService.GetById(id);
                result = _mapper.Map<Province, ProvinceDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ProvinceDO> GetList(Expression<Func<ProvinceDO, bool>> filter = null)
        {
            List<ProvinceDO> result;
            try
            {
                List<Province> admins = _provinceService.GetList();
                result = _mapper.Map<List<Province>, List<ProvinceDO>>(admins);
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

        public ProvinceDO Update(ProvinceDO model)
        {
            ProvinceDO result = new();
            Province entity;
            try
            {
                entity = _mapper.Map<ProvinceDO, Province>(model);
                _provinceService.Update(entity);
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
