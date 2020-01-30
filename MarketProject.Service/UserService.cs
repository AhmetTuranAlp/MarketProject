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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public User Login(string userName, string password)
        {
            try
            {
                User user = null;
                user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == userName && x.Password == password);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Create(User entity)
        {
            try
            {      
                _userRepository.Create(entity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User Get(int id)
        {
            try
            {
                return _userRepository.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return new List<User>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(User entity)
        {
            try
            {
                var updateEntity = _userRepository.Find(entity.Id);
                _userRepository.Update(updateEntity);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }





        #endregion
    }
}
