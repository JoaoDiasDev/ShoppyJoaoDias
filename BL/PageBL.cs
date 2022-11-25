using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class PageBL : IPageBL
    {
        private IPageService _pageService;
        private IMapper _mapper;

        public PageBL(IServiceProvider serviceProvider)
        {
            _pageService = serviceProvider.GetRequiredService<IPageService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public PageDO Add(PageDO model)
        {
            PageDO result = model;
            Page entity;
            try
            {
                entity = _mapper.Map<PageDO, Page>(model);
                _pageService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(PageDO model)
        {
            try
            {
                Page entity = _mapper.Map<PageDO, Page>(model);
                bool result = _pageService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PageDO Get(Expression<Func<Page, bool>> predicate = null)
        {
            PageDO result;
            try
            {
                Page admin = _pageService.Get(predicate);
                result = _mapper.Map<Page, PageDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public PageDO GetById(int id)
        {
            PageDO result;
            try
            {
                Page admin = _pageService.GetById(id);
                result = _mapper.Map<Page, PageDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<PageDO> GetList(Expression<Func<PageDO, bool>> filter = null)
        {
            List<PageDO> result;
            try
            {
                List<Page> admins = _pageService.GetList();
                result = _mapper.Map<List<Page>, List<PageDO>>(admins);
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

        public PageDO Update(PageDO model)
        {
            PageDO result = new();
            Page entity;
            try
            {
                entity = _mapper.Map<PageDO, Page>(model);
                _pageService.Update(entity);
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
