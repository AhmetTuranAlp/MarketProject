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
    public class SaleService : BaseService, ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IRepository<Sales> _saleRepository
        {
            get
            {
                return _unitOfWork.GetRepository<Sales>();
            }
        }
        #endregion
        public Response<SalesDTO> Create(SalesDTO sale)
        {
            try
            {
                sale.Status = DTO.Entities.ModelEnums.Status.Active;
                sale.UpdateDate = DateTime.Now;
                sale.UploadDate = DateTime.Now;

                Sales entity = null;
                entity = Map<Sales>(sale);
                _saleRepository.Create(entity);
                _unitOfWork.SaveChanges();
                sale.Id = entity.Id;
                return new Response<SalesDTO>() { IsSuccess = true, Message = "Eklendi.", Result = sale };
            }
            catch (Exception ex)
            {
                return new Response<SalesDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }

        public Response<bool> Delete(int id)
        {
            try
            {
                _saleRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new Response<bool>() { Result = true, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<bool>() { Result = false, IsSuccess = false, Exception = ex };
            }
        }

        public Response<SalesDTO> Get(int id)
        {
            try
            {
                var sales = _saleRepository.Get(x => x.Id == id).FirstOrDefault();
                return new Response<SalesDTO>() { Result = Map<SalesDTO>(sales), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<SalesDTO>() { Result = null, IsSuccess = false, Exception = ex };
            }
        }

        public List<SalesDTO> GetAll()
        {
            try
            {
                List<Sales> sales = _saleRepository.GetAll().Where(x => x.Status != Data.Model.ModelEnums.Status.Deleted).ToList();
                List<SalesDTO> salesDTO = new List<SalesDTO>();
                sales.ForEach(x =>
                {
                    salesDTO.Add(Map<SalesDTO>(x));
                });
                return salesDTO;
            }
            catch (Exception)
            {
                return new List<SalesDTO>();
            }
        }

        public Response<SalesDTO> Update(SalesDTO sales)
        {
            try
            {
                Sales entity = null;
                entity = Map<Sales>(sales);
                _saleRepository.Delete(entity.Id);
                _saleRepository.Create(entity);
                _unitOfWork.SaveChanges();
                sales.Id = entity.Id;

                return new Response<SalesDTO>() { IsSuccess = true, Message = "Güncellendi.", Result = sales };

            }
            catch (Exception ex)
            {
                return new Response<SalesDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }
    }
}
