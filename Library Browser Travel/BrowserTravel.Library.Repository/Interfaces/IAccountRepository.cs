using BrowserTravel.Library.Entities.Dto.Auth;
using BrowserTravel.Library.Entities.Models;
using System.Threading.Tasks;


namespace BrowserTravel.Library.Repository.Interfaces
{
    public interface IAccountRepository: IRepository<User>
    {
        Task<User> SignIn(User user);
    }
}
