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
    public class UserPersistence : IUserPersistence
    {
        private readonly ApiWebContext _context;
        public UserPersistence(ApiWebContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<User[]> GetAllUsersAsync(bool includePositions = false)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Positions).Include(e => e.SocialMedias);

            if (includePositions) 
            {
                query = query.Include(u => u.UsersPositions).ThenInclude(up => up.Position);
            }

            query = query.AsNoTracking().OrderBy(u => u.Id);

            return await query.ToArrayAsync();
        }

        public async Task<User[]> GetAllUsersByNameAsync(string name, bool includePositions = false)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Positions).Include(e => e.SocialMedias);

            if (includePositions)
            {
                query = query.Include(u => u.UsersPositions).ThenInclude(up => up.Position);
            }

            query = query.AsNoTracking().OrderBy(u => u.Id).Where(e => e.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId, bool includePositions = false)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Positions).Include(u => u.SocialMedias);

            if (includePositions)
            {
                query = query.Include(u => u.UsersPositions).ThenInclude(up => up.Position);
            }

            query = query.AsNoTracking().OrderBy(u => u.Id).Where(e => e.Id == userId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
