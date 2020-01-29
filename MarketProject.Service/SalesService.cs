using MarketProject.Data.Model;
using MarketProject.Data.UnitOfWork;
using MarketProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Service
{
    public class SalesService : ISalesService
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

        public bool Create(Sales entity)
        {
            try
            {
                _salesRepository.Create(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _salesRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Sales Get(int id)
        {
            try
            {
                return _salesRepository.Find(id);
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
                return _salesRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Sales entity)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
