using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace BL
{
    public class ProductBL : IProductBL
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductBL(IServiceProvider serviceProvider)
        {
            _productService = serviceProvider.GetRequiredService<IProductService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ProductDO Add(ProductDO model)
        {
            ProductDO result = model;
            Product entity;
            try
            {
                entity = _mapper.Map<ProductDO, Product>(model);
                _productService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(ProductDO model)
        {
            try
            {
                Product entity = _mapper.Map<ProductDO, Product>(model);
                bool result = _productService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductDO Get(Expression<Func<ProductDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public ProductDO GetById(int id)
        {
            ProductDO result;
            try
            {
                Product admin = _productService.GetById(id);
                result = _mapper.Map<Product, ProductDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ProductDO> GetList(Expression<Func<ProductDO, bool>> filter = null)
        {
            List<ProductDO> result;
            try
            {
                List<Product> admins = _productService.GetList();
                result = _mapper.Map<List<Product>, List<ProductDO>>(admins);
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

        public ProductDO Update(ProductDO model)
        {
            ProductDO result = new();
            Product entity;
            try
            {
                entity = _mapper.Map<ProductDO, Product>(model);
                _productService.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
