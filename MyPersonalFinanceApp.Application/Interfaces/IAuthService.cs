using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalFinanceApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(LoginDTO loginDTO);
    }
}
