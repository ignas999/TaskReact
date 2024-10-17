using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Dto;
using TaskApi.Interfaces;
using TaskApi.Mapper;
using TaskApi.Models;
using TaskApi.Repository;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
		private readonly IBookRepository _bookRepository;

		public BooksController(DataContext context ,IBookRepository bookRepository)
        {
			_bookRepository = bookRepository;

		}

        // GET: api/Books
        [HttpGet]
		public async Task<IActionResult> GetBooks()
        {
            var books2 = await _bookRepository.GetAll();
            var books2Dto = books2.Select(s => s.ToBookDto());
		

			return Ok(books2Dto);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBooksDto bookDto)
        {
            var bookModel = bookDto.ToBookFromCreateBookDto();
            await _bookRepository.CreateBook(bookModel);
        	return Ok(bookModel);
		}

    }
}
