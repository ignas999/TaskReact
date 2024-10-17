namespace TaskApi.Dto
{
	public class CreateBooksDto
	{
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public int Year { get; set; }
		public string Picture { get; set; } = string.Empty;
	}
}
