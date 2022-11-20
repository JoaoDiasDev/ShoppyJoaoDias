using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class BankInstallmentBL : IBankInstallmentBL
    {
        private IBankInstallmentService _bankInstallmentService;
        private IMapper _mapper;

        public BankInstallmentBL(IServiceProvider serviceProvider)
        {
            _bankInstallmentService = serviceProvider.GetRequiredService<IBankInstallmentService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BankInstallmentDO Add(BankInstallmentDO model)
        {
            BankInstallmentDO result = model;
            BankInstallment entity;
            try
            {
                entity = _mapper.Map<BankInstallmentDO, BankInstallment>(model);
                _bankInstallmentService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(BankInstallmentDO model)
        {
            try
            {
                BankInstallment entity = _mapper.Map<BankInstallmentDO, BankInstallment>(model);
                bool result = _bankInstallmentService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BankInstallmentDO Get(Expression<Func<BankInstallmentDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public BankInstallmentDO GetById(int id)
        {
            BankInstallmentDO result;
            try
            {
                BankInstallment admin = _bankInstallmentService.GetById(id);
                result = _mapper.Map<BankInstallment, BankInstallmentDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<BankInstallmentDO> GetList(Expression<Func<BankInstallmentDO, bool>> filter = null)
        {
            List<BankInstallmentDO> result;
            try
            {
                List<BankInstallment> admins = _bankInstallmentService.GetList();
                result = _mapper.Map<List<BankInstallment>, List<BankInstallmentDO>>(admins);
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

        public BankInstallmentDO Update(BankInstallmentDO model)
        {
            BankInstallmentDO result = new();
            BankInstallment entity;
            try
            {
                entity = _mapper.Map<BankInstallmentDO, BankInstallment>(model);
                _bankInstallmentService.Update(entity);
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
