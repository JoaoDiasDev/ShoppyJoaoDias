using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class BrandBL : IBrandBL
    {
        private IBrandService _brandService;
        private IMapper _mapper;

        public BrandBL(IServiceProvider serviceProvider)
        {
            _brandService = serviceProvider.GetRequiredService<IBrandService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BrandDO Add(BrandDO model)
        {
            BrandDO result = model;
            Brand entity;
            try
            {
                entity = _mapper.Map<BrandDO, Brand>(model);
                _brandService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(BrandDO model)
        {
            try
            {
                Brand entity = _mapper.Map<BrandDO, Brand>(model);
                bool result = _brandService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BrandDO Get(Expression<Func<BrandDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public BrandDO GetById(int id)
        {
            BrandDO result;
            try
            {
                Brand admin = _brandService.GetById(id);
                result = _mapper.Map<Brand, BrandDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<BrandDO> GetList(Expression<Func<BrandDO, bool>> filter = null)
        {
            List<BrandDO> result;
            try
            {
                List<Brand> admins = _brandService.GetList();
                result = _mapper.Map<List<Brand>, List<BrandDO>>(admins);
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

        public BrandDO Update(BrandDO model)
        {
            BrandDO result = new();
            Brand entity;
            try
            {
                entity = _mapper.Map<BrandDO, Brand>(model);
                _brandService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
