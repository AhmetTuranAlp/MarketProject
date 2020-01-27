using MarketProject.Data.UnitOfWork;
using MarketProject.DTO.Entities;
using MarketProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Service
{
    public class SalesService : BaseService, ISalesService
    {
        private readonly IUnitOfWork _unitOfWork;
        #region Constructor
        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private Data.Repositories.IRepository<Sales> _salesRepository
        {
            get
            {
                return _unitOfWork.GetRepository<Sales>();
            }
        }
        #endregion

        public void Create(Sales entity)
        {
            try
            {
                Data.Model.Sales sales = null;
                sales = Map<Data.Model.Sales>(entity);
                _salesRepository.Create(entity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _salesRepository.Delete(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Sales Get(int id)
        {
            try
            {
                var sales = _salesRepository.Find(id);
                return Map<Sales>(sales);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Sales> GetAll()
        {
            try
            {
                var sales = _salesRepository.GetAll();
                var dtoSales = new List<Sales>();
                return dtoSales;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Sales entity)
        {
            throw new NotImplementedException();
        }
    }
}
