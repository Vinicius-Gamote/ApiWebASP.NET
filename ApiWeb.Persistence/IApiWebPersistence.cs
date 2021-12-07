using ApiWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb.Persistence
{
    interface IApiWebPersistence
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void DeleteRange<T>(T[] entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<User[]> GetAllUsersByNameAsync(string name, bool includePositions);

        Task<User[]> GetAllUsersAsync(bool includePositions);

        Task<User> GetUserByIdAsync(int UserId, bool includePositions);

        Task<Position[]> GetAllPositionsByNameAsync(string name, bool includeUsers);

        Task<Position[]> GetAllPositionsAsync(bool includeUsers);

        Task<Position> GetPositionByIdAsync(int positionId, bool includeUsers);
    }
}
