using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetByEmail(string email);
        Task<bool> EmailExistsAsync(string email);
    }
}
