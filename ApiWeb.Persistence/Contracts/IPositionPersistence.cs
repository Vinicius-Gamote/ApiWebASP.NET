using ApiWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb.Persistence.Contracts
{
    public interface IPositionPersistence
    {
        Task<Position[]> GetAllPositionsByNameAsync(string name, bool includeUsers = false);

        Task<Position[]> GetAllPositionsAsync(bool includeUsers = false);

        Task<Position> GetPositionByIdAsync(int positionId, bool includeUsers = false);
    }
}
