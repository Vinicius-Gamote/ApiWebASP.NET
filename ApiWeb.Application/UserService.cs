using ApiWeb.Application.Contracts;
using ApiWeb.Persistence;
using ApiWeb.Domain;
using System;
using System.Threading.Tasks;
using ApiWeb.Persistence.Contracts;

namespace ApiWeb.Application
{
    public class UserService : IUserService
    {
        private readonly IGeneralPersistence _generalPersistence;

        private readonly IUserPersistence _userPersistence;
        public UserService(IGeneralPersistence generalPersistence, IUserPersistence userPersistence)
        {
            _generalPersistence = generalPersistence;
            _userPersistence = userPersistence;
        }
        public async Task<User> AddUsers(User model)
        {
            try
            {
                _generalPersistence.Add<User>(model);
                if (await _generalPersistence.SaveChangesAsync()) 
                {
                    return await _userPersistence.GetUserByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<User> UpdateUser(int userId, User model)
        {
            try
            {
                var user = await _userPersistence.GetUserByIdAsync(userId, false);
                if (user == null) return null;

                model.Id = user.Id;

                _generalPersistence.Update(model);
                if (await _generalPersistence.SaveChangesAsync()) 
                {
                    return await _userPersistence.GetUserByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await _userPersistence.GetUserByIdAsync(userId, false);
                if (user == null) throw new Exception("Delete user not found!");

                _generalPersistence.Delete<User>(user);
                return await _generalPersistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User[]> GetAllUsersAsync(bool includePositions = false)
        {
            try
            {
                var users = await _userPersistence.GetAllUsersAsync(includePositions);
                if (users == null) return null;

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User[]> GetAllUsersByNameAsync(string name, bool includePositions = false)
        {
            try
            {
                var users = await _userPersistence.GetAllUsersByNameAsync(name, includePositions);
                if (users == null) return null;

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserByIdAsync(int userId, bool includePositions = false)
        {
            try
            {
                var users = await _userPersistence.GetUserByIdAsync(userId, includePositions);
                if (users == null) return null;

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
