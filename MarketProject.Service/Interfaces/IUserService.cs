
using MarketProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace MarketProject.Service.Interfaces
{
    public interface IUserService : IService<User>
    {
        User Login(string userName, string password);
    }
}
