using AutoMapper;
using ShoppingMarket.Data.Model;
using ShoppingMarket.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Service
{
    public class BaseService
    {
        private static IMapper _mapper;
        public T Map<T>(object objectToMap)
        {

            if (_mapper == null)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<UserDTO, User>();
                    cfg.CreateMap<Product, ProductDTO>();
                    cfg.CreateMap<ProductDTO, Product>();
                    cfg.CreateMap<Basket, BasketDTO>();
                    cfg.CreateMap<BasketDTO, Basket>();
                    cfg.CreateMap<Sales, SalesDTO>();
                    cfg.CreateMap<SalesDTO, Sales>();
                });

                _mapper = Mapper.Configuration.CreateMapper();
                _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }


            return _mapper.Map<T>(objectToMap);
        }
    }
}
