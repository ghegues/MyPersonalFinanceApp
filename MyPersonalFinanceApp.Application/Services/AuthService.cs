using MyPersonalFinanceApp.Application.Interfaces;
using MyPersonalFinanceApp.Application.Utils;
using MyPersonalFinanceApp.Infra.Interfaces;
using MyPersonalFinanceApp.JWT.Interfaces;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJWTService _jwtService;
    private readonly PasswordHasher _passwordHasher;
    public AuthService(IUserRepository userRepository, IJWTService jwtService, PasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> Authenticate(LoginDTO loginDTO)
    {
        var user = await _userRepository.GetByEmail(loginDTO.Email);
        if (user == null)
            throw new Exception("Usuário ou senha incorreta");

        if (!_passwordHasher.VerifyPassword(loginDTO.Senha, user.Password))
            throw new Exception("Usuário ou senha incorreta");

        return _jwtService.GenerateToken(user);
    }
}
