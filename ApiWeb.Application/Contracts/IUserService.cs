using ApiWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb.Application.Contracts
{
    public interface IUserService
    {
        Task<User> AddUsers(User model);

        Task<User> UpdateUser(int userId, User model);

        Task<bool> DeleteUser(int userId);

        Task<User[]> GetAllUsersAsync(bool includePositions = false);

        Task<User[]> GetAllUsersByNameAsync(string name, bool includePositions = false);

        Task<User> GetUserByIdAsync(int userId, bool includePositions = false);
    }
}
