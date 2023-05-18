using System.Threading.Tasks;
using BrowserTravel.Library.Entities.Dto.Auth;

namespace BrowserTravel.Library.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> SignIn(UserSignInDto userSignInDto);
    }
}
