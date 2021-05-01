using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;
using WhiteSandsMVC.ViewModels;

namespace WhiteSandsMVC.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IRoomRepository roomRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IBookingRepository bookingRepository;
        private readonly IGuestRepository guestRepository;

        public ReservationsController(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, IBookingRepository bookingRepository, IGuestRepository guestRepository)
        {
            this.roomRepository = roomRepository;
            this.roomTypeRepository = roomTypeRepository;
            this.bookingRepository = bookingRepository;
            this.guestRepository = guestRepository;
        }

        
        public IActionResult SelectDates(CheckRatesViewModel model)
        {
            return View(model);
        }

        public IActionResult ChooseRoom(ChooseRoomViewModel model)
        {
            // get available rooms according to search criteria from db and attach to VM, if I can. Try to not use the viewbag.
            IEnumerable<RoomType> roomTypes = roomTypeRepository.GetRoomTypes();
            ViewBag.roomTypes = roomTypes;

            return View(model);
        }

        [HttpGet]
        public IActionResult ConfirmStay(string checkInDate, string checkOutDate, string adults, string children, string selectedRoomTypeId, string promo)
        {

            DateTime checkIn;
            DateTime checkOut;
            DateTime cancellationDate;
            int roomTypeId;

            var isParsableCheckInDate = DateTime.TryParse(checkInDate, out checkIn);
            var isParsableCheckOutDate = DateTime.TryParse(checkOutDate, out checkOut);
            var isValidRoomId = Int32.TryParse(selectedRoomTypeId, out roomTypeId);
            // converted to bytes so math can be performed in view
            byte adultsByte = Convert.ToByte(adults);
            byte childrenByte = Convert.ToByte(children);

            TimeSpan nights = checkOut.Subtract(checkIn);
            cancellationDate = checkIn.AddDays(-1);

            var room = roomRepository.GetRoomByRoomTypeId(roomTypeId);
            if (room == null)
            {
                return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 404 });
            }
            var roomType = roomTypeRepository.GetRoomTypeById(room.RoomTypeId);

            ConfirmStayViewModel model = new ConfirmStayViewModel
            {
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                Adults = adultsByte,
                Children = childrenByte,
                Room = room,
                RoomId = room.Id,
                RoomType = roomType,
                RoomTypeId = roomTypeId,
                Nights = nights.Days,
                CancellationDate = cancellationDate,
                Promo = promo,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmStay(ConfirmStayViewModel model)
        {
            if (ModelState.IsValid)
            {
                // this guest is strangely initialized in the confirm stay view model
                Guest guest = model.Guest;
                guestRepository.Create(guest);

                // double check total cost by making a calculation on backend too
                RoomType roomType = roomTypeRepository.GetRoomTypeById(model.RoomTypeId);
                var baseTotal = roomType.Price * model.Nights;
                decimal feePercent = .1m;
                var serviceFee = Decimal.Multiply(baseTotal, feePercent);
                var total = baseTotal + serviceFee;

                if (total != model.TotalCost)
                {
                    new Exception("Error calculating total cost");
                }

                Booking booking = new Booking
                {
                    GuestId = guest.Id,
                    RoomId = model.RoomId,
                    RoomTypeId = model.RoomTypeId,
                    TotalCost = model.TotalCost,
                    CheckInDate = model.CheckInDate,
                    CheckOutDate = model.CheckOutDate,
                    Adults = model.Adults,
                    Children = model.Children,
                    Promo = model.Promo
                };

                bookingRepository.Create(booking);

                return RedirectToAction("BookingSuccess", "Reservations", new 
                { 
                    bookingId = booking.Id,
                    guestId = guest.Id,
                    roomTypeId = model.RoomTypeId,
                });

            }
            var roomTypeForError = roomTypeRepository.GetRoomTypeById(model.RoomTypeId);
            model.RoomType = roomTypeForError;
            return View(model);
        }

        public IActionResult BookingSuccess(string bookingId, string guestId, string roomTypeId)
        {
            int bookingIdParsed;
            int guestIdParsed;
            int roomTypeIdParsed;

            var isValidBookingId = Int32.TryParse(bookingId, out bookingIdParsed);
            var isValidGuestId = Int32.TryParse(guestId, out guestIdParsed);
            var isValidRoomTypeId = Int32.TryParse(roomTypeId, out roomTypeIdParsed);

            var booking = bookingRepository.GetBooking(bookingIdParsed);
            var guest = guestRepository.GetGuest(guestIdParsed);
            var roomType = roomTypeRepository.GetRoomTypeById(roomTypeIdParsed);

            BookingSuccessViewModel model = new BookingSuccessViewModel()
            {
                Booking = booking,
                RoomType = roomType,
                Guest = guest
            };

            return View(model);
        }
    }
}
