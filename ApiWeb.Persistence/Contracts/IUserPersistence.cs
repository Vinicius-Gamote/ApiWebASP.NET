using ApiWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb.Persistence.Contracts
{
    public interface IUserPersistence
    {
        Task<User[]> GetAllUsersByNameAsync(string name, bool includePositions = false);

        Task<User[]> GetAllUsersAsync(bool includePositions = false);

        Task<User> GetUserByIdAsync(int UserId, bool includePositions = false);
    }
}
