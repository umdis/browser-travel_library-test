using BrowserTravel.Library.Entities.Dto.Library;
using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Repository.Interfaces;
using BrowserTravel.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Services.Areas.Library
{
    public class EditorialService : IEditorialService
    {
        private readonly IEdirorialRepository _edirorialRepository;

        public EditorialService(IEdirorialRepository edirorialRepository)
        {
            _edirorialRepository = edirorialRepository;
        }

        /// <summary>
        /// Allows registration of new editorial
        /// </summary>
        /// <param name="editorialDto"></param>
        /// <returns>EditorialResponseDto</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<EditorialResponseDto> Add(EditorialDto editorialDto)
        {
            var editorial = await _edirorialRepository.Add(new Editorial
            {
                Name = editorialDto.Name,
                Site = editorialDto.Site
            });

            return new EditorialResponseDto
            {
                Name = editorial.Name,
                Site = editorial.Site,
            };
        }

        /// <summary>
        /// Returns a collection of editorials
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<EditorialResponseDto>> GetAll()
        {
            var editorials = await _edirorialRepository.GetAll();

            return editorials.Select(e => new EditorialResponseDto { Name = e.Name, Site = e.Site }).ToList();
        }
    }
}
