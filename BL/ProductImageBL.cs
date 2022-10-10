using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class ProductImageBL : IProductImageBL
    {
        private IProductImageService _productImageService;
        private IMapper _mapper;

        public ProductImageBL(IServiceProvider serviceProvider)
        {
            _productImageService = serviceProvider.GetRequiredService<IProductImageService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ProductImageDO Add(ProductImageDO model)
        {
            ProductImageDO result = model;
            ProductImage entity;
            try
            {
                entity = _mapper.Map<ProductImageDO, ProductImage>(model);
                _productImageService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(ProductImageDO model)
        {
            try
            {
                ProductImage entity = _mapper.Map<ProductImageDO, ProductImage>(model);
                bool result = _productImageService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductImageDO Get(Expression<Func<ProductImageDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public ProductImageDO GetById(int id)
        {
            ProductImageDO result;
            try
            {
                ProductImage admin = _productImageService.GetById(id);
                result = _mapper.Map<ProductImage, ProductImageDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ProductImageDO> GetList(Expression<Func<ProductImageDO, bool>> filter = null)
        {
            List<ProductImageDO> result;
            try
            {
                List<ProductImage> productImages = _productImageService.GetList();
                result = _mapper.Map<List<ProductImage>, List<ProductImageDO>>(productImages);
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

        public ProductImageDO Update(ProductImageDO model)
        {
            ProductImageDO result = model;
            ProductImage entity;
            try
            {
                entity = _mapper.Map<ProductImageDO, ProductImage>(model);
                _productImageService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
