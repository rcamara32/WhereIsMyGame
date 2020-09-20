using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Services
{
    public interface IAuthService
    {
        Task<GetUserLogin> Login(UserLogin userLogin);
        Task<GetUserLogin> Register(RegisterUser registerUser);
        Task<UserDetailsDto> GetUserDetails();
    }
}