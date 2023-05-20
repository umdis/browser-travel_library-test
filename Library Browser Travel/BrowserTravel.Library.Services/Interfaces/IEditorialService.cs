using BrowserTravel.Library.Entities.Dto.Library;
using BrowserTravel.Library.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Services.Interfaces
{
    public interface IEditorialService
    {
        Task<EditorialResponseDto> Add(EditorialDto editorialDto);
        Task<ICollection<EditorialResponseDto>> GetAll();
        Task<EditorialResponseDto> Get(int id);
    }
}
