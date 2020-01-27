using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Service
{
    public class BaseService
    {
        private static AutoMapper.IMapper _mapper;
        public T Map<T>(object objectToMap)
        {

            if (_mapper == null)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Data.Model.User, DTO.Entities.User>();
                    cfg.CreateMap<Data.Model.Product, DTO.Entities.Product>();
                    cfg.CreateMap<DTO.Entities.User, Data.Model.User>();
                    cfg.CreateMap<DTO.Entities.Product, Data.Model.Product>();
                });

                _mapper = Mapper.Configuration.CreateMapper();
                _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }


            return _mapper.Map<T>(objectToMap);
        }
    }
}
