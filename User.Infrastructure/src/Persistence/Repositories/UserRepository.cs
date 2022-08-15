using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.Core.src.Entities;
using User.Core.src.Repositories;

namespace User.Infrastructure.src.Persistence.Repositories
{
    public class UserRepository : ICrud<UserEntity>
    {
        private readonly UserDBC _context;

        public UserRepository(UserDBC context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserEntity entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> ReadAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(UserEntity entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(x => x.Id == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserEntity>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}