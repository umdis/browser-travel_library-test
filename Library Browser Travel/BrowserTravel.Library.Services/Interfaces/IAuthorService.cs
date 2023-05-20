using BrowserTravel.Library.Entities.Dto.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorResponseDto> Add(AuthorDto authorDto);
        Task<ICollection<AuthorResponseDto>> GetAll();
        Task<AuthorResponseDto> Get(int id);
    }
}
