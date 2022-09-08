using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class CityBL : ICityBL
    {
        private ICityService _cityService;
        private IMapper _mapper;

        public CityBL(IServiceProvider serviceProvider)
        {
            _cityService = serviceProvider.GetRequiredService<ICityService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public CityDO Add(CityDO model)
        {
            CityDO result = model;
            City entity;
            try
            {
                entity = _mapper.Map<CityDO, City>(model);
                _cityService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(CityDO model)
        {
            try
            {
                City entity = _mapper.Map<CityDO, City>(model);
                bool result = _cityService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CityDO Get(Expression<Func<CityDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public CityDO GetById(int id)
        {
            CityDO result;
            try
            {
                City admin = _cityService.GetById(id);
                result = _mapper.Map<City, CityDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<CityDO> GetList(Expression<Func<CityDO, bool>> filter = null)
        {
            List<CityDO> result;
            try
            {
                List<City> admins = _cityService.GetList();
                result = _mapper.Map<List<City>, List<CityDO>>(admins);
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

        public CityDO Update(CityDO model)
        {
            CityDO result = new();
            City entity;
            try
            {
                entity = _mapper.Map<CityDO, City>(model);
                _cityService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
