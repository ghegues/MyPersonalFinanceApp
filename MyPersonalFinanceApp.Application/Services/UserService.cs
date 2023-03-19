using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, PasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<Response> RegisterUserAsync(UserDTO userDTO)
        {
            if (await _userRepository.EmailExistsAsync(userDTO.Email))
            {
                return new Response { Success = false, Message = "Email já cadastrado." };
            }

            var hashedPassword = _passwordHasher.HashPassword(userDTO.Password);

            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = hashedPassword
            };

            await _userRepository.AddAsync(user);
            return new Response { Success = true, Message = "Usuário cadastrado com sucesso." };
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

    }
}
