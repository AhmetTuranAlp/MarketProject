using Microsoft.EntityFrameworkCore;
using ShoppingMarket.Data.Model;
using ShoppingMarket.Data.Repositories;
using ShoppingMarket.Data.UnitOfWork;
using ShoppingMarket.DTO.Common;
using ShoppingMarket.DTO.Entities;
using ShoppingMarket.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingMarket.Service
{
    public class BasketService : BaseService, IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IRepository<Basket> _basketRepository
        {
            get
            {
                return _unitOfWork.GetRepository<Basket>();
            }
        }
        #endregion
        public Response<BasketDTO> Create(BasketDTO basket)
        {
            try
            {
                basket.Status = DTO.Entities.ModelEnums.Status.Active;
                basket.UpdateDate = DateTime.Now;
                basket.UploadDate = DateTime.Now;

                Basket entity = null;
                entity = Map<Basket>(basket);
                _basketRepository.Create(entity);
                _unitOfWork.SaveChanges();
                basket.Id = entity.Id;
                return new Response<BasketDTO>() { IsSuccess = true, Message = "Ürün Sepete Eklendi.", Result = basket };
            }
            catch (Exception ex)
            {
                return new Response<BasketDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }

        public Response<bool> Delete(int id)
        {
            try
            {
                _basketRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new Response<bool>() { Result = true, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<bool>() { Result = false, IsSuccess = false, Exception = ex };
            }
        }

        public Response<BasketDTO> Get(int id)
        {
            try
            {
                var user = _basketRepository.Get(x => x.Id == id).FirstOrDefault();            
                return new Response<BasketDTO>() { Result = Map<BasketDTO>(user), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<BasketDTO>() { Result = null, IsSuccess = false, Exception = ex };
            }
        }

        public List<BasketDTO> GetAll()
        {
            try
            {
                List<Basket> baskets = _basketRepository.GetAll().Where(x => x.Status == Data.Model.ModelEnums.Status.Active).ToList();
                List<BasketDTO> basketDTO = new List<BasketDTO>();
                baskets.ForEach(x =>
                {
                    basketDTO.Add(Map<BasketDTO>(x));
                });
                return basketDTO;
            }
            catch (Exception)
            {
                return new List<BasketDTO>();
            }
        }

        public Response<BasketDTO> GetBasket(int userId, int productId)
        {
            try
            {
                var basket = _basketRepository.GetAll().Where(x => x.Status != Data.Model.ModelEnums.Status.Deleted && x.UserCode == userId.ToString() && x.ProductCode == productId.ToString()).FirstOrDefault();

                return new Response<BasketDTO>() { Result = Map<BasketDTO>(basket), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<BasketDTO>() { Result = null, IsSuccess = false, Exception = ex };
            }
        }

        public Response<BasketDTO> Update(BasketDTO basket)
        {
            try
            {
                Basket entity = null;
                entity = Map<Basket>(basket);
                _basketRepository.Delete(entity.Id);                  
                _basketRepository.Create(entity);
                _unitOfWork.SaveChanges();
                basket.Id = entity.Id;
                return new Response<BasketDTO>() { IsSuccess = true, Message = "Sepet Güncellendi.", Result = basket };
            }
            catch (Exception ex)
            {
                return new Response<BasketDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }
    }
}
