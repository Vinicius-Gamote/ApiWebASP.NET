using ApiWeb.Domain;
using ApiWeb.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb.Persistence
{
    public class PositionPersistence : IPositionPersistence
    {
        private readonly ApiWebContext _context;
        public PositionPersistence(ApiWebContext context)
        {
            _context = context;
        }
        public async Task<Position[]> GetAllPositionsAsync(bool includeUsers)
        {
            IQueryable<Position> query;

            if (includeUsers)
            {
                query = _context.Positions.Include(p => p.UsersPositions).ThenInclude(up => up.User);
            }

            query = _context.Positions.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Position[]> GetAllPositionsByNameAsync(string name, bool includeUsers)
        {
            IQueryable<Position> query;

            if (includeUsers)
            {
                query = _context.Positions.Include(p => p.UsersPositions).ThenInclude(up => up.User);
            }

            query = _context.Positions.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int positionId, bool includeUsers)
        {
            IQueryable<Position> query;

            if (includeUsers)
            {
                query = _context.Positions.Include(p => p.UsersPositions).ThenInclude(up => up.User);
            }

            query = _context.Positions.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == positionId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
