using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface ISettingBL
    {
        SettingDO Add(SettingDO model);
        SettingDO Update(SettingDO model);
        SettingDO GetById(int id);
        SettingDO Get(Expression<Func<SettingDO, bool>> predicate = null);
        List<SettingDO> GetList(Expression<Func<SettingDO, bool>> filter = null);
        bool Delete(SettingDO model);
    }
}
