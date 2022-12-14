using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class CategoryBL : ICategoryBL
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryBL(IServiceProvider serviceProvider)
        {
            _categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public CategoryDO Add(CategoryDO model)
        {
            CategoryDO result = model;
            Category entity;
            try
            {
                entity = _mapper.Map<CategoryDO, Category>(model);
                _categoryService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(CategoryDO model)
        {
            try
            {
                Category entity = _mapper.Map<CategoryDO, Category>(model);
                bool result = _categoryService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CategoryDO Get(Expression<Func<Category, bool>> predicate = null)
        {
            var result = new CategoryDO();
            try
            {
                var category = _categoryService.Get(predicate);
                result = _mapper.Map<Category, CategoryDO>(category);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        public CategoryDO GetById(int id)
        {
            CategoryDO result;
            try
            {
                Category admin = _categoryService.GetById(id);
                result = _mapper.Map<Category, CategoryDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<CategoryDO> GetList(Expression<Func<CategoryDO, bool>> filter = null)
        {
            List<CategoryDO> result;
            try
            {
                List<Category> admins = _categoryService.GetList();
                result = _mapper.Map<List<Category>, List<CategoryDO>>(admins);
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

        public CategoryDO Update(CategoryDO model)
        {
            CategoryDO result = new();
            Category entity;
            try
            {
                entity = _mapper.Map<CategoryDO, Category>(model);
                _categoryService.Update(entity);
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
