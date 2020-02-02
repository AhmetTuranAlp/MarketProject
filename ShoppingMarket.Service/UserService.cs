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
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IRepository<User> _userRepository
        {
            get
            {
                return _unitOfWork.GetRepository<User>();
            }
        }
        #endregion


        public Response<UserDTO> Create(UserDTO user)
        {
            try
            {
                user.Status = DTO.Entities.ModelEnums.Status.Active;
                User entity = null;
                entity = Map<User>(user);

                _userRepository.Create(entity);
                _unitOfWork.SaveChanges();

                user.Id = entity.Id;

                return new Response<UserDTO>() { IsSuccess = true, Message = "Kullanıcı eklendi.", Result = user };

            }
            catch (Exception ex)
            {
                return new Response<UserDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }

        public Response<bool> Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return new Response<bool>() { Result = true, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<bool>() { Result = false, IsSuccess = false, Exception = ex };
            }
        }

        public Response<UserDTO> Get(int id)
        {
            try
            {
                var user = _userRepository.Get(x => x.Id == id).FirstOrDefault();
                var dtoUser = new User();
                return new Response<UserDTO>() { Result = Map<UserDTO>(user), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<UserDTO>() { Result = null, IsSuccess = false, Exception = ex };
            }
        }

        public Response<UserDTO> Login(string userName, string password)
        {
            try
            {
                var user = _userRepository.Get(x => x.UserName == userName && x.Password == password && x.Status == Data.Model.ModelEnums.Status.Active).FirstOrDefault();
                var dtoUser = new User();

                return new Response<UserDTO>() { Result = Map<UserDTO>(user), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response<UserDTO>() { Result = null, IsSuccess = false, Exception = ex };
            }
        }

        public Response<UserDTO> Update(UserDTO user)
        {
            try
            {
                User entity = null;
                entity = Map<User>(entity);

                _userRepository.Update(entity);
                _unitOfWork.SaveChanges();

                user.Id = entity.Id;

                return new Response<UserDTO>() { IsSuccess = true, Message = "Kullanıcı Bilgileri Güncellendi.", Result = user };

            }
            catch (Exception ex)
            {
                return new Response<UserDTO>() { IsSuccess = false, Exception = ex, Message = "Hata oluştu." };
            }
        }

   
    }
}
