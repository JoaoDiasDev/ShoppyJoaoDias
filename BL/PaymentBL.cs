using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class PaymentBL : IPaymentBL
    {
        private IPaymentService _paymentService;
        private IMapper _mapper;

        public PaymentBL(IServiceProvider serviceProvider)
        {
            _paymentService = serviceProvider.GetRequiredService<IPaymentService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public PaymentDO Add(PaymentDO model)
        {
            PaymentDO result = model;
            Payment entity;
            try
            {
                entity = _mapper.Map<PaymentDO, Payment>(model);
                _paymentService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(PaymentDO model)
        {
            try
            {
                Payment entity = _mapper.Map<PaymentDO, Payment>(model);
                bool result = _paymentService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PaymentDO Get(Expression<Func<Payment, bool>> predicate = null)
        {
            PaymentDO result;
            try
            {
                Payment admin = _paymentService.Get(predicate);
                result = _mapper.Map<Payment, PaymentDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public PaymentDO GetById(int id)
        {
            PaymentDO result;
            try
            {
                Payment admin = _paymentService.GetById(id);
                result = _mapper.Map<Payment, PaymentDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<PaymentDO> GetList(Expression<Func<PaymentDO, bool>> filter = null)
        {
            List<PaymentDO> result;
            try
            {
                List<Payment> admins = _paymentService.GetList();
                result = _mapper.Map<List<Payment>, List<PaymentDO>>(admins);
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

        public PaymentDO Update(PaymentDO model)
        {
            PaymentDO result = new();
            Payment entity;
            try
            {
                entity = _mapper.Map<PaymentDO, Payment>(model);
                _paymentService.Update(entity);
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
