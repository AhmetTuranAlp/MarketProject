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
    public class ProductService : BaseService, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IRepository<Product> _productRepository
        {
            get
            {
                return _unitOfWork.GetRepository<Product>();
            }
        }
        #endregion

        public Response<ProductDTO> Create(ProductDTO product)
        {
            try
            {
                product.Status = DTO.Entities.ModelEnums.Status.Active;
                product.CurrencyType = DTO.Entities.ModelEnums.CurrencyType.TL;
                product.ProductId = "100000"+ _productRepository.GetCount().ToString();
                product.UpdateDate = DateTime.Now;
                product.UploadDate = DateTime.Now;
                product.MarketPrice = product.SalePrice;

                Product entity = null;
                entity = Map<Product>(product);
                _productRepository.Create(entity);
                _unitOfWork.SaveChanges();
                product.Id = entity.Id;
                return new Response<ProductDTO>() { IsSuccess = true, Message = "Ürün Eklendi.", Result = product };
            }
            catch (Exception ex)
            {
                return new Response<ProductDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }

        public Response<ProductDTO> CreateApi(ProductDTO product)
        {
            try
            {
                product.Status = DTO.Entities.ModelEnums.Status.Active;
                product.CurrencyType = DTO.Entities.ModelEnums.CurrencyType.TL;
                product.ProductId = "100000" + _productRepository.GetCount().ToString();
                product.UpdateDate = DateTime.Now;
                product.UploadDate = DateTime.Now;
                product.MarketPrice = product.SalePrice;

                Product entity = null;
                entity = Map<Product>(product);
                _productRepository.Create(entity);
                _unitOfWork.SaveChanges();
                product.Id = entity.Id;
                return new Response<ProductDTO>() { IsSuccess = true, Message = "Ürün Eklendi.", Result = product };
            }
            catch (Exception ex)
            {
                return new Response<ProductDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }

        public Response<bool> Delete(int id)
        {
            try
            {
                _productRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new Response<bool>() { Result = true, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<bool>() { Result = false, IsSuccess = false, Exception = ex };
            }
        }

        public Response<ProductDTO> Get(int id)
        {
            try
            {
                var user = _productRepository.Get(x => x.Id == id).FirstOrDefault();
                var dtoUser = new User();
                return new Response<ProductDTO>() { Result = Map<ProductDTO>(user), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<ProductDTO>() { Result = null, IsSuccess = false, Exception = ex };
            }
        }

        public List<ProductDTO> GetAll()
        {
            try
            {
                List<Product> products= _productRepository.GetAll().Where(x => x.Status != Data.Model.ModelEnums.Status.Deleted).ToList();
                List<ProductDTO> productDTO = new List<ProductDTO>();
                products.ForEach(x =>
                {
                    productDTO.Add(Map<ProductDTO>(x));
                });
                return productDTO;
            }
            catch (Exception)
            {
                return new List<ProductDTO>();
            }
        }

        public Response<ProductDTO> Update(ProductDTO product)
        {
            try
            {
                Product entity = null;
                entity = Map<Product>(product);
                _productRepository.Delete(entity.Id);
                _productRepository.Create(entity);
                _unitOfWork.SaveChanges();
                product.Id = entity.Id;

                return new Response<ProductDTO>() { IsSuccess = true, Message = "Ürün Bilgileri Güncellendi.", Result = product };

            }
            catch (Exception ex)
            {
                return new Response<ProductDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }
    }
}
