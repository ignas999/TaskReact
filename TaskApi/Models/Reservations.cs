using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models
{
	public class Reservations
	{
		[Key]
		public int Id { get; set; }

		public int BookId {  get; set; }

		public Books? Book { get; set; }
		public DateTime StartDate { get; set; } = DateTime.Now;

		public DateTime FinishDate { get; set; }

		public string BookType {  get; set; }

		public double Price { get; set; }

		public string QuickPickup { get; set; }
	}
}
