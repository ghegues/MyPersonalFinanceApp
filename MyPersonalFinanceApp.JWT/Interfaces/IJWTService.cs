using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.JWT.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}
