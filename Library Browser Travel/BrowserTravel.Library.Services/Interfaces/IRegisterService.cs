using System.Threading.Tasks;
using BrowserTravel.Library.Entities.Dto.Auth;

namespace BrowserTravel.Library.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<RegisterResponseDto> Register(RegisterDto registerDto);
    }
}
