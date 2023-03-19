using MyPersonalFinanceApp.Application.DTOs;
using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<Response> RegisterUserAsync(UserDTO userDTO);
        Task<UserDTO> GetByEmail(string email);
    }
}
