using BrowserTravel.Library.Entities.Dto.Library;
using BrowserTravel.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrowserTravel.Library.API.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _bookService.GetAll();
            return Ok(response);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _bookService.Get(id);
            return Ok(response);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto bookDto)
        {
            var reponse = await _bookService.Add(bookDto);
            return Ok(reponse);
        }
    }
}
