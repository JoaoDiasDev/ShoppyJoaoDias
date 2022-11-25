using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

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

        public ProductDO Get(Expression<Func<Product, bool>> predicate = null)
        {
            ProductDO result;
            try
            {
                Product product = _productService.Get(predicate);
                result = _mapper.Map<Product, ProductDO>(product);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ProductDO> GetProductPerPage(int categoryId, int page, bool isParentCategory)
        {
            var result = new List<ProductDO>();
            try
            {
                var products = _productService.GetProductPerPage(categoryId, page, isParentCategory);
                result = _mapper.Map<List<Product>, List<ProductDO>>(products);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public ProductDO GetById(int id)
        {
            ProductDO result;
            try
            {
                Product product = _productService.GetById(id);
                result = _mapper.Map<Product, ProductDO>(product);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ProductDO> GetList(Expression<Func<Product, bool>> filter = null)
        {
            List<ProductDO> result;
            try
            {
                List<Product> admins = _productService.GetList(filter);
                result = _mapper.Map<List<Product>, List<ProductDO>>(admins);
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
