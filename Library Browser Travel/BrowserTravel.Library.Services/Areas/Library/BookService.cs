using BrowserTravel.Library.Entities.Dto.Library;
using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Repository.Interfaces;
using BrowserTravel.Library.Repository.Repositories;
using BrowserTravel.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Services.Areas.Library
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IEdirorialRepository _editorialRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IEdirorialRepository edirorialRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _editorialRepository = edirorialRepository;
        }

        /// <summary>
        /// Allows registration of new Book
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns>BookResponseDto</returns>
        public async Task<BookResponseDto> Add(BookDto bookDto)
        {
            var authors = await _authorRepository.GetItems(r => bookDto.Authors.Contains(r.Id));

            var book = new Book
            {
                IdEditorial = bookDto.IdEditorial,
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                NumberPages = bookDto.NumberPages,
                Synopsis = bookDto.Synopsis,
                Authors = authors
            };

            await _bookRepository.Add(book);

            book.Authors.ToList().ForEach(a => a.Books = null);

            return new BookResponseDto
            {
                Authors = book.Authors,
                Id = book.Id,
                ISBN = book.ISBN,
                NumberPages = book.NumberPages,
                Synopsis = book.Synopsis,
                Title = book.Title,
                Editorial = book.Editorial
            };
        }

        /// <summary>
        /// Return o sets an instance of book
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BookResponseDto</returns>
        public async Task<BookResponseDto> Get(int id)
        {
            var book = await _bookRepository.Get(b => b.Id == id, new string[] { "Editorial", "Authors" });
            
            if(book == null)
                return null;
            
            book.Authors.ToList().ForEach(a => a.Books = null);
            return new BookResponseDto
            {
                Id = book.Id,
                Authors = book.Authors,
                Editorial = book.Editorial,
                ISBN = book.ISBN,
                NumberPages = book.NumberPages,
                Synopsis = book.Synopsis,
                Title = book.Title
            };
        }

        /// <summary>
        /// Returns a collection of books
        /// </summary>
        /// <returns>ICollection<BookResponseDto></returns>
        public async Task<ICollection<BookResponseDto>> GetAll()
        {
            var response = _bookRepository.GetAll();
            return await response.Select(e => new BookResponseDto
            {
                Id = e.Id,
                Authors = e.Authors,
                Editorial = e.Editorial,
                ISBN = e.ISBN,
                NumberPages = e.NumberPages,
                Synopsis = e.Synopsis,
                Title = e.Title
            }).ToListAsync();
        }

        /// <summary>
        /// Returns a collection of books according to the received parameter
        /// </summary>
        /// <returns>ICollection<BookResponseDto></returns>
        public async Task<ICollection<BookResponseDto>> GetAll(string parameter)
        {
            var response = await _bookRepository.GetItems(b => b.Title.StartsWith(parameter), new string[] { "Editorial", "Authors" });

            response.ToList().ForEach(b => b.Authors.ToList().ForEach(a => a.Books = null));

            return response.Select(b => new BookResponseDto
            {
                Authors = b.Authors,
                Editorial = b.Editorial,
                Id = b.Id,
                ISBN = b.ISBN,
                NumberPages = b.NumberPages,
                Synopsis = b.Synopsis,
                Title = b.Title
            }).ToList();
        }
    }
}
