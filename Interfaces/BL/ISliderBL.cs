using System.Linq.Expressions;
using DAL.MySqlDbContext;
using Entities;

namespace Interfaces.BL
{
    public interface ISliderBL
    {
        SliderDO Add(SliderDO model);
        SliderDO Update(SliderDO model);
        SliderDO GetById(int id);
        SliderDO Get(Expression<Func<Slider, bool>> predicate = null);
        List<SliderDO> GetList(Expression<Func<SliderDO, bool>> filter = null);
        bool Delete(SliderDO model);
    }
}
