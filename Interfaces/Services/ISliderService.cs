
using System.Linq.Expressions;
using DAL.MySqlDbContext;

namespace Interfaces.Services
{
    public interface ISliderService
    {
        public Slider Add(Slider entity);
        public bool Delete(Slider entity);
        public void Update(Slider entity);
        public Slider GetById(int id);
        public Slider Get(Expression<Func<Slider, bool>> predicate = null);
        public List<Slider> GetList(Expression<Func<Slider, bool>> filter = null);
    }
}
