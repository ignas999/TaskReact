using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Interfaces;
using TaskApi.Models;

namespace TaskApi.Repository
{
    public class BookRepository :IBookRepository
	{
		private readonly DataContext _context;
		public BookRepository(DataContext context) 
		{
			_context = context;
		}

		public async Task<Books?> GetBookById(int id)
		{
			return await _context.Books.Where(p => p.Id == id).FirstOrDefaultAsync();
		}

		public async Task<List<Books>> GetAll()
		{
			return await _context.Books.ToListAsync();
		}

		public async Task<Books> CreateBook(Books bookModel)
		{
			await _context.Books.AddAsync(bookModel);
			await _context.SaveChangesAsync();
			return bookModel;
		}

	}
}
