using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Interfaces;
using TaskApi.Models;

namespace TaskApi.Repository
{
	public class ReservationRepository : IReservationRepository
	{
		private readonly DataContext _context;

		public ReservationRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<Reservations> CreateReservation(Reservations reservationModel)
		{
			await _context.Reservations.AddAsync(reservationModel);
			await _context.SaveChangesAsync();
			return reservationModel;
		}

		public async Task<List<Reservations>> GetAll()
		{
			return await _context.Reservations.Include(c => c.Book).ToListAsync();
		}

		public async Task<Reservations?> GetReservationById(int id)
		{
			return await _context.Reservations.Include(c => c.Book).Where(r => r.Id == id).FirstOrDefaultAsync();
		}

		public async Task<Reservations> DeleteReservation(int id)
		{
			var reservationModel = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (reservationModel == null)
            {
				return null;
            }

			_context.Reservations.Remove(reservationModel);
			await _context.SaveChangesAsync();
			return reservationModel;
        }

		public Task<bool> BookExists(int id)
		{
			return _context.Books.AnyAsync(s => s.Id == id);
		}

	}
}
