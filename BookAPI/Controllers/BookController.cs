using BookAPI.Models;
using BookAPI.Repositories;
using BookAPI.Repositories.BookRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        [HttpPost]
        [Route("")]
        public async Task  AddBook([FromBody] Book book) => await bookRepository.Insert(book);

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task< IEnumerable<Book>> GetAllBooks() => await bookRepository.GetAll();

        [HttpGet]
        [Route("{bookId}")]
        public async Task<Book> GetBookById(int bookId) => await bookRepository.GetById(bookId);


    }
}
