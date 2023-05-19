using BrowserTravel.Library.Entities.Dto.Library;
using BrowserTravel.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrowserTravel.Library.API.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly IEditorialService _editorialService;

        public EditorialsController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        // GET: api/<EditorialsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _editorialService.GetAll();
            return Ok(response);
        }

        // GET api/<EditorialsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new System.Exception("Excepción de prueba");
        }

        // POST api/<EditorialsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EditorialDto editorialDto)
        {
            var response = await _editorialService.Add(editorialDto);
            return Ok(response);
        }

        // PUT api/<EditorialsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EditorialsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
