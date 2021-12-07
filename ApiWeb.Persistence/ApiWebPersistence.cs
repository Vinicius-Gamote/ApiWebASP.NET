using ApiWeb.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb.Persistence
{
    public class ApiWebPersistence : IApiWebPersistence
    {
        private readonly ApiWebContext _context;
        public ApiWebPersistence(ApiWebContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<User[]> GetAllUsersAsync(bool includePositions = false)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Positions).Include(e => e.SocialMedias);

            if (includePositions) 
            {
                query = query.Include(u => u.UsersPositions).ThenInclude(up => up.Position);
            }

            query = query.OrderBy(u => u.Id);

            return await query.ToArrayAsync();
        }

        public async Task<User[]> GetAllUsersByNameAsync(string name, bool includePositions = false)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Positions).Include(e => e.SocialMedias);

            if (includePositions)
            {
                query = query.Include(u => u.UsersPositions).ThenInclude(up => up.Position);
            }

            query = query.OrderBy(u => u.Id).Where(e => e.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId, bool includePositions = false)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Positions).Include(u => u.SocialMedias);

            if (includePositions)
            {
                query = query.Include(u => u.UsersPositions).ThenInclude(up => up.Position);
            }

            query = query.OrderBy(u => u.Id).Where(e => e.Id == userId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Position[]> GetAllPositionsAsync(bool includeUsers)
        {
            IQueryable<Position> query;

            if (includeUsers)
            {
                query = _context.Positions.Include(p => p.UsersPositions).ThenInclude(up => up.User);
            }

            query = _context.Positions.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Position[]> GetAllPositionsByNameAsync(string name, bool includeUsers)
        {
            IQueryable<Position> query;

            if (includeUsers)
            {
                query = _context.Positions.Include(p => p.UsersPositions).ThenInclude(up => up.User);
            }

            query = _context.Positions.OrderBy(p => p.Id).Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int positionId, bool includeUsers)
        {
            IQueryable<Position> query;

            if (includeUsers)
            {
                query = _context.Positions.Include(p => p.UsersPositions).ThenInclude(up => up.User);
            }

            query = _context.Positions.OrderBy(p => p.Id).Where(p => p.Id == positionId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
