using TaskApi.Models;

namespace TaskApi.Dto
{
	public class CreateReservationDto
	{

		public DateTime StartDate { get; set; }

		public DateTime FinishDate { get; set; }

		public string BookType { get; set; }

		public double Price { get; set; }

		public string QuickPickup { get; set; }
	}
}
