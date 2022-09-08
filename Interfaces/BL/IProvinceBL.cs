using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IProvinceBL
    {
        ProvinceDO Add(ProvinceDO model);
        ProvinceDO Update(ProvinceDO model);
        ProvinceDO GetById(int id);
        ProvinceDO Get(Expression<Func<ProvinceDO, bool>> predicate = null);
        List<ProvinceDO> GetList(Expression<Func<ProvinceDO, bool>> filter = null);
        bool Delete(ProvinceDO model);
    }
}
