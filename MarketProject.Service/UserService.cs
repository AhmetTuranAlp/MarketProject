using MarketProject.Data.Repositories;
using MarketProject.Data.UnitOfWork;
using MarketProject.DTO.Entities;
using MarketProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketProject.Service
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = repository;
        }
        
        public User Login(string userName, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == userName && x.Password == password);
            var dtoUser = Map<User>(user);
            return dtoUser;
        }

        public void Create(User entity)
        {
            try
            {
                Data.Model.User user = null;
                user = Map<Data.Model.User>(user);
                _userRepository.Create(entity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User Get(int id)
        {
            try
            {
                var user = _userRepository.Find(id);
                return Map<User>(user);
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

        public void Update(User entity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
