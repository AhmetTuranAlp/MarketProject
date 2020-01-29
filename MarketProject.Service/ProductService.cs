using MarketProject.Data.Model;
using MarketProject.Data.Repositories;
using MarketProject.Data.UnitOfWork;
using MarketProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MarketProject.Data.Model.ModelEnums;

namespace MarketProject.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _productRepository;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = unitOfWork.GetRepository<Product>();
        }
        public bool Create(Product entity)
        {
            try
            {
                _productRepository.Create(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        Product IProductService.Create(Product product)
        {
            try
            {
                _productRepository.Create(product);
                _unitOfWork.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return new Product();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Product product = _productRepository.Find(id);
                product.Status = ModelEnums.Status.Deleted;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product Get(int id)
        {
            try
            {
                return _productRepository.GetAll().FirstOrDefault(x => x.Id == id && x.Status != Status.Deleted);
            }
            catch (Exception)
            {
                return new Product();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _productRepository.GetAll();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public bool Update(Product entity)
        {
            try
            {
                Product product = _productRepository.Find(entity.Id);
                product.Price = entity.Price;
                product.Stock = entity.Stock;
                product.Name = entity.Name;
                product.ProductType = entity.ProductType;
                product.UpdateDate = entity.UpdateDate;
                product.Status = Status.Active;
                _productRepository.Update(product);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

     
    }
}
