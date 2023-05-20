using BrowserTravel.Library.Entities.Dto.Library;
using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Repository.Interfaces;
using BrowserTravel.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Services.Areas.Library
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// Allows registration of new Author
        /// </summary>
        /// <param name="authorDto"></param>
        /// <returns>AuthorResponseDto</returns>
        public async Task<AuthorResponseDto> Add(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name,
                LastName = authorDto.LastName
            };

            await _authorRepository.Add(author);

            return new AuthorResponseDto
            {
                Id = author.Id,
                Name = author.Name,
                LastName = author.LastName
            };
        }

        /// <summary>
        /// Return o sets an instance of author
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AuthorResponseDto</returns>
        public async Task<AuthorResponseDto> Get(int id)
        {
            var author = await _authorRepository.Get(id);
            return new AuthorResponseDto
            {
                Id = author.Id,
                Books = author.Books,
                LastName = author.LastName,
                Name = author.Name
            };
        }

        /// <summary>
        /// Returns a collection of authors
        /// </summary>
        /// <returns>ICollection<AuthorResponseDto></returns>
        public async Task<ICollection<AuthorResponseDto>> GetAll()
        {
            var response = _authorRepository.GetAll();
            return await response.Select(e => new AuthorResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                Books = e.Books,
                LastName = e.LastName
            }).ToListAsync();
        }
    }
}
