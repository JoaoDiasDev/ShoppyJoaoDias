using Entities;
using System.Linq.Expressions;

namespace Interfaces.BL
{
    public interface IPaymentBL
    {
        PaymentDO Add(PaymentDO model);
        PaymentDO Update(PaymentDO model);
        PaymentDO GetById(int id);
        PaymentDO Get(Expression<Func<PaymentDO, bool>> predicate = null);
        List<PaymentDO> GetList(Expression<Func<PaymentDO, bool>> filter = null);
        bool Delete(PaymentDO model);
    }
}
