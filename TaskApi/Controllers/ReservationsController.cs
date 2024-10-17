using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Dto;
using TaskApi.Interfaces;
using TaskApi.Mapper;
using TaskApi.Models;
using TaskApi.Repository;

namespace TaskApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationsController : ControllerBase
	{
		private readonly IReservationRepository _reservationRepository;

		public ReservationsController(DataContext context, IReservationRepository reservationRepository)
		{
			_reservationRepository = reservationRepository;

		}

		[HttpGet]
		public async Task<IActionResult> GetReservations()
		{
			var reservations = await _reservationRepository.GetAll();
			var reservationdto = reservations.Select(s => s.ToReservationsDto());

			return Ok(reservations);
		}

		// GET: api/Reservations/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetReservationById([FromRoute] int id)
		{
			var reservation = await _reservationRepository.GetReservationById(id);

			if (reservation == null)
			{
				return NotFound();
			}

			return Ok(reservation.ToReservationsDto());
		}

		[HttpPost("{bookId}")]
		public async Task<IActionResult> CreateReservation([FromRoute] int bookId, [FromBody] CreateReservationDto reservationDto)
		{
			if(!await _reservationRepository.BookExists(bookId))
			{
				return BadRequest("book doesn't exist");
			}

			if (!IsValidReservation(reservationDto))
			{
				return BadRequest("Invalid reservation details");
			}

			var reservationModel = reservationDto.ToReservationsFromCreateReservationDto(bookId);
			reservationModel.Price = CalculateReservationPrice(reservationModel);


			await _reservationRepository.CreateReservation(reservationModel);
			return Ok(reservationModel);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteReservation([FromRoute] int id)
		{
			var reservationmodel = await _reservationRepository.DeleteReservation(id);

			if (reservationmodel == null)
			{
				return NotFound();
			}

			return NoContent();
        }

		private bool IsValidReservation(CreateReservationDto reservationDto)
		{
			
			if (reservationDto.BookType != "regular" && reservationDto.BookType != "audiobook")
			{
				return false;
			}

			
			if (reservationDto.StartDate >= reservationDto.FinishDate)
			{
				return false;
			}

			
			if (reservationDto.QuickPickup != "yes" && reservationDto.QuickPickup != "no")
			{
				return false;
			}

			return true;
		}

		private double CalculateReservationPrice(Reservations reservation)
		{
			DateTime startDate = reservation.StartDate;
			DateTime finishDate = reservation.FinishDate;
			string bookType = reservation.BookType;
			string quickPickup = reservation.QuickPickup;

			finishDate = new DateTime(reservation.FinishDate.Year, reservation.FinishDate.Month, reservation.FinishDate.Day, 23, 59, 59);

			
			int daysDifference = (finishDate - startDate).Days;

			
			if (daysDifference <= 0)
			{
				throw new ArgumentException("Reservation must be for at least one day.");
			}

			int dailyRate = bookType == "audiobook" ? 3 : 2; 
			int serviceFee = 3; 
			int quickPickupFee = quickPickup == "yes" ? 5 : 0; 

			
			double totalPrice = daysDifference * dailyRate + serviceFee + quickPickupFee;

												  
			if (daysDifference > 10)
			{
				totalPrice = (double)totalPrice * 0.8; 
			}
			else if (daysDifference > 3)
			{
				totalPrice = (double)totalPrice * 0.9; 
			}



			return totalPrice;
		}
	}


}
