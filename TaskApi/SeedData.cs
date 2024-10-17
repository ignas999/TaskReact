using TaskApi.Models;
using DataContext = TaskApi.Data.DataContext;

namespace TaskApi
{
    public class SeedData : IStartupFilter
	{
		private readonly IServiceProvider _serviceProvider;
		public SeedData(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
		{
			LoadData();
			return next;
		}

		private void LoadData()
		{
			using (var scope = _serviceProvider.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<DataContext>();

				
				context.Database.EnsureCreated();

				
				if (!context.Books.Any())
				{
					context.Books.AddRange(
						new Books
						{
							Id = 1,
							Title = "The Road",
							Author = "Cormac McCarthy",
							Year = 2006,
							Picture = "https://m.media-amazon.com/images/I/51URLMJvQ7L._AC_UF1000,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 2,
							Title = "The Girl with the Dragon Tattoo",
							Author = "Stieg Larsson",
							Year = 2005,
							Picture = "https://m.media-amazon.com/images/I/8133MFwkxOL._AC_UF1000,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 3,
							Title = "The Hunger Games",
							Author = "Suzanne Collins",
							Year = 2008,
							Picture = "https://m.media-amazon.com/images/I/71un2hI4mcL._AC_UF1000,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 4,
							Title = "The Night Circus",
							Author = "Erin Morgenstern",
							Year = 2011,
							Picture = "https://m.media-amazon.com/images/I/61Pqqc4muHL._AC_UF1000,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 5,
							Title = "Gone Girl",
							Author = "Gillian Flynn",
							Year = 2012,
							Picture = "https://m.media-amazon.com/images/I/71+khXHbe5L._AC_UF894,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 6,
							Title = "The Fault in Our Stars",
							Author = "John Green",
							Year = 2012,
							Picture = "https://m.media-amazon.com/images/I/61fbVx3W5cL._AC_UF1000,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 7,
							Title = "The Goldfinch",
							Author = "Donna Tartt",
							Year = 2013,
							Picture = "https://m.media-amazon.com/images/I/81QxwwBNU9L._AC_UF1000,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 8,
							Title = "The Underground Railroad",
							Author = "Colson Whitehead",
							Year = 2016,
							Picture = "https://m.media-amazon.com/images/I/91JaRsb1pDL.jpg"
						},
						new Books
						{
							Id = 9,
							Title = "Where the Crawdads Sing",
							Author = "Delia Owens",
							Year = 2018,
							Picture = "https://m.media-amazon.com/images/I/81F0NTrPdCL._AC_UF1000,1000_QL80_.jpg"
						},
						new Books
						{
							Id = 10,
							Title = "The Testaments",
							Author = "Margaret Atwood",
							Year = 2019,
							Picture = "https://m.media-amazon.com/images/I/61Q2TeT5FgL._AC_UF1000,1000_QL80_.jpg"
						}
					);


					context.SaveChanges();
				}
			}
		}
	}
}
