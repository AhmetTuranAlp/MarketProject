using MarketProject.Data.Model;
using MarketProject.Data.Repositories;
using MarketProject.Data.UnitOfWork;
using MarketProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Service
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Basket> _basketRepository;
        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = unitOfWork.GetRepository<Basket>();
        }
        public bool Create(Basket entity)
        {
            try
            {
                _basketRepository.Create(entity);
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
                Basket basket = _basketRepository.Find(id);
                basket.Status = ModelEnums.Status.Deleted;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Basket Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Basket> GetAll()
        {
            try
            {
                return _basketRepository.GetAll();
            }
            catch (Exception)
            {
                return new List<Basket>();
            }
        }

        public bool Update(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
