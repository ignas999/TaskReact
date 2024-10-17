using TaskApi.Models;

namespace TaskApi.Interfaces
{
	public interface IReservationRepository
	{
		public Task<List<Reservations>> GetAll();

		public Task<Reservations?> GetReservationById(int id);

		public Task<Reservations> CreateReservation(Reservations reservationModel);

		public Task<Reservations> DeleteReservation(int id);

		public Task<bool> BookExists(int id);
	}
}
