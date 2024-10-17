using TaskApi.Models;

namespace TaskApi.Interfaces
{
	public interface IBookRepository
	{
		public Task<List<Books>> GetAll();

		public Task<Books?> GetBookById(int id);

		public Task<Books> CreateBook(Books bookModel);

	}
}
