using BrowserTravel.Library.Entities.Dto.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookResponseDto> Add(BookDto bookDto);
        Task<ICollection<BookResponseDto>> GetAll();
        Task<BookResponseDto> Get(int id);
    }
}
