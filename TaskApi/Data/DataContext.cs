using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data
{

    public class DataContext : DbContext
    {

		public DataContext(DbContextOptions dbContextOptions): base(dbContextOptions)
		{

		}
		public DbSet<Reservations> Reservations { get; set; }

		public DbSet<Books> Books { get; set; }


	}





	}
