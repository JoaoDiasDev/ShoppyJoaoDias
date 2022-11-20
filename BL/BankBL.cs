using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class BankBL : IBankBL
    {
        private IBankService _bankService;
        private IMapper _mapper;

        public BankBL(IServiceProvider serviceProvider)
        {
            _bankService = serviceProvider.GetRequiredService<IBankService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BankDO Add(BankDO model)
        {
            BankDO result = model;
            Bank entity;
            try
            {
                entity = _mapper.Map<BankDO, Bank>(model);
                _bankService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(BankDO model)
        {
            try
            {
                Bank entity = _mapper.Map<BankDO, Bank>(model);
                bool result = _bankService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BankDO Get(Expression<Func<BankDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public BankDO GetById(int id)
        {
            BankDO result;
            try
            {
                Bank admin = _bankService.GetById(id);
                result = _mapper.Map<Bank, BankDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<BankDO> GetList(Expression<Func<BankDO, bool>> filter = null)
        {
            List<BankDO> result;
            try
            {
                List<Bank> admins = _bankService.GetList();
                result = _mapper.Map<List<Bank>, List<BankDO>>(admins);
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

        public BankDO Update(BankDO model)
        {
            BankDO result = new();
            Bank entity;
            try
            {
                entity = _mapper.Map<BankDO, Bank>(model);
                _bankService.Update(entity);
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
