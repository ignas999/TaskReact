using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models
{
	public class Books
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int Year { get; set; }
		public string Picture { get; set; }

	}
}
