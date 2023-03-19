using Microsoft.EntityFrameworkCore;
using MyPersonalFinanceApp.Domain.Entities;
using MyPersonalFinanceApp.Infra.Data;
using MyPersonalFinanceApp.Infra.Interfaces;

namespace MyPersonalFinanceApp.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            var entry = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
