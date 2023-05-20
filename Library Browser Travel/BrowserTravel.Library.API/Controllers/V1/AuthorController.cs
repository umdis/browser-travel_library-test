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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _authorService.GetAll();
            return Ok(response);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = await _authorService.Get(id);
            return Ok(response);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorDto authorDto)
        {
            var response = await _authorService.Add(authorDto);
            return Ok(response);
        }
    }
}
