
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskApi.Dto;
using TaskApi.Models;
using System.Linq;
using System.Collections.Generic;


namespace TaskApi.Mapper
{
	public static class MappingProfiles
	{

		public static BooksDto ToBookDto(this Books bookModel)
		{
			return new BooksDto
			{
				Id = bookModel.Id,
				Title = bookModel.Title,
				Author = bookModel.Author,
				Year = bookModel.Year,
				Picture = bookModel.Picture,
			};
		}

		public static Books ToBookFromCreateBookDto(this CreateBooksDto bookDto)
		{
			return new Books
			{
				Title = bookDto.Title,
				Author = bookDto.Author,
				Year = bookDto.Year,
				Picture = bookDto.Picture
			};
		}

		public static ReservationsDto ToReservationsDto(this Reservations reservationModel)
		{
			return new ReservationsDto
			{
				Id = reservationModel.Id,
				BookId = reservationModel.BookId,
				StartDate = reservationModel.StartDate,
				FinishDate = reservationModel.FinishDate,
				BookType = reservationModel.BookType,
				Price = reservationModel.Price,
				QuickPickup = reservationModel.QuickPickup
			};
		}

		public static Reservations ToReservationsFromCreateReservationDto(this CreateReservationDto reservationDto, int bookId)
		{
			return new Reservations
			{
				BookId = bookId,
				StartDate = reservationDto.StartDate,
				FinishDate = reservationDto.FinishDate,
				BookType = reservationDto.BookType,
				Price = reservationDto.Price,
				QuickPickup = reservationDto.QuickPickup
			};
		}
	}
}
