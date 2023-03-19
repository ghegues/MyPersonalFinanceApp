using MyPersonalFinanceApp.Application.DTOs;
using MyPersonalFinanceApp.Application.Interfaces;
using MyPersonalFinanceApp.Application.Utils;
using MyPersonalFinanceApp.Domain.Entities;
using MyPersonalFinanceApp.Infra.Interfaces;
using System.Threading.Tasks;

namespace MyPersonalFinanceApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Response> RegisterUserAsync(UserDTO userDTO)
        {
            if (await _userRepository.EmailExistsAsync(userDTO.Email))
            {
                return new Response { Success = false, Message = "Email j� cadastrado." };
            }

            var hashedPassword = _passwordHasher.HashPassword(userDTO.Password);

            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = hashedPassword
            };

            await _userRepository.AddAsync(user);
            return new Response { Success = true, Message = "Usu�rio cadastrado com sucesso." };
        }

        // Implemente outros m�todos do servi�o conforme necess�rio
    }
}
