using TaskApi.Models;

namespace TaskApi.Dto
{
	public class ReservationsDto
	{
		public int Id { get; set; }

		public int BookId { get; set; }
		
		public BooksDto Book { get; set; }
		public DateTime StartDate { get; set; }

		public DateTime FinishDate { get; set; }

		public string BookType { get; set; }

		public double Price { get; set; }

		public string QuickPickup { get; set; }
	}
}
