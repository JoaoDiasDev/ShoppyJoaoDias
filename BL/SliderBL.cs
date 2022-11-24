using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class SliderBL : ISliderBL
    {
        private ISliderService _sliderService;
        private IMapper _mapper;

        public SliderBL(IServiceProvider serviceProvider)
        {
            _sliderService = serviceProvider.GetRequiredService<ISliderService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public SliderDO Add(SliderDO model)
        {
            SliderDO result = model;
            Slider entity;
            try
            {
                entity = _mapper.Map<SliderDO, Slider>(model);
                _sliderService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(SliderDO model)
        {
            try
            {
                Slider entity = _mapper.Map<SliderDO, Slider>(model);
                bool result = _sliderService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SliderDO Get(Expression<Func<Slider, bool>> predicate = null)
        {
            SliderDO result;
            try
            {
                Slider slider = _sliderService.Get(predicate);
                result = _mapper.Map<Slider, SliderDO>(slider);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public SliderDO GetById(int id)
        {
            SliderDO result;
            try
            {
                Slider slider = _sliderService.GetById(id);
                result = _mapper.Map<Slider, SliderDO>(slider);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<SliderDO> GetList(Expression<Func<SliderDO, bool>> filter = null)
        {
            List<SliderDO> result;
            try
            {
                List<Slider> admins = _sliderService.GetList();
                result = _mapper.Map<List<Slider>, List<SliderDO>>(admins);
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

        public SliderDO Update(SliderDO model)
        {
            SliderDO result = new();
            Slider entity;
            try
            {
                entity = _mapper.Map<SliderDO, Slider>(model);
                _sliderService.Update(entity);
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
