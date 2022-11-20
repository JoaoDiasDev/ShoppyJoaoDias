using System.Linq.Expressions;
using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class UnitBL : IUnitBL
    {
        private IUnitService _unitService;
        private IMapper _mapper;

        public UnitBL(IServiceProvider serviceProvider)
        {
            _unitService = serviceProvider.GetRequiredService<IUnitService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public UnitDO Add(UnitDO model)
        {
            UnitDO result = model;
            Unit entity;
            try
            {
                entity = _mapper.Map<UnitDO, Unit>(model);
                _unitService.Add(entity);
                result.Id = entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Delete(UnitDO model)
        {
            try
            {
                Unit entity = _mapper.Map<UnitDO, Unit>(model);
                bool result = _unitService.Delete(entity);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UnitDO Get(Expression<Func<UnitDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public UnitDO GetById(int id)
        {
            UnitDO result;
            try
            {
                Unit admin = _unitService.GetById(id);
                result = _mapper.Map<Unit, UnitDO>(admin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<UnitDO> GetList(Expression<Func<UnitDO, bool>> filter = null)
        {
            List<UnitDO> result;
            try
            {
                List<Unit> admins = _unitService.GetList();
                result = _mapper.Map<List<Unit>, List<UnitDO>>(admins);
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

        public UnitDO Update(UnitDO model)
        {
            UnitDO result = new();
            Unit entity;
            try
            {
                entity = _mapper.Map<UnitDO, Unit>(model);
                _unitService.Update(entity);
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
