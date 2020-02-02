using ShoppingMarket.Common.Interfaces;
using ShoppingMarket.DTO.Common;
using ShoppingMarket.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Service.Base
{
    public interface IUserService : IService<UserDTO>, IMapper
    {
        Response<UserDTO> Login(string userName, string password);
    }
}
