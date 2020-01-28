
using MarketProject.Common.Interfaces;
using MarketProject.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MarketProject.Service.Interfaces
{
    public interface IUserService : IService<User>, IMapper
    {
        User Login(string userName, string password);
    }
}
