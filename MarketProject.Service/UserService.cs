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

        #region Constructor
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private Data.Repositories.IRepository<User> _userRepository
        {
            get
            {
                return _unitOfWork.GetRepository<User>();
            }
        }
        #endregion


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
