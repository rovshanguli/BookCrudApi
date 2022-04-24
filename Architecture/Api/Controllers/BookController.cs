using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] BookCreateDto bookCreateDto)
        {
            await _service.CreateAsync(bookCreateDto);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(int id,[FromBody] BookUpdateDto bookUpdateDto)
        {
            await _service.UpdateAsync(id, bookUpdateDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await  _service.DeleteAsync(id);

            return Ok();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            return Ok(await _service.GetAllByConditionsAsync(search));
        }
    }
}
