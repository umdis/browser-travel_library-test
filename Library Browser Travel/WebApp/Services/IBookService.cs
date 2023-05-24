using BrowserTravel.Library.Entities.Dto.Library;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IBookService
    {
        Task<BookResponseDto> Get(int id);
        Task<ICollection<BookResponseDto>> GetAll();
        Task<ICollection<BookResponseDto>> GetAll(string parameter);
    }
}
