using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;
using WhiteSandsMVC.Utility;
using WhiteSandsMVC.ViewModels;

namespace WhiteSandsMVC.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IRoomRepository roomRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationsController(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork)
        {
            this.roomRepository = roomRepository;
            this.roomTypeRepository = roomTypeRepository;
            _unitOfWork = unitOfWork;
        }

        
        public IActionResult SelectDates(CheckRatesViewModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> ChooseRoom(ChooseRoomViewModel model)
        {
            // get available rooms according to search criteria from db and attach to VM, if I can. Try to not use the viewbag.
            IEnumerable<RoomType> roomTypes = await _unitOfWork.RoomType.GetAll();
            ViewBag.roomTypes = roomTypes;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmStay(string checkInDate, string checkOutDate, string adults, string children, string selectedRoomTypeId, string promo)
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

            var room = await _unitOfWork.Room.GetFirstOrDefault(room => room.RoomTypeId == roomTypeId);
            if (room == null)
            {
                return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 404 });
            }
            var roomType = await _unitOfWork.RoomType.Get(room.RoomTypeId);

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
        public async Task<IActionResult> ConfirmStay(ConfirmStayViewModel model)
        {
            if (ModelState.IsValid)
            {
                // this guest is strangely initialized in the confirm stay view model
                Guest guest = model.Guest;
                await _unitOfWork.Guest.Add(guest);
                _unitOfWork.Save();

                // double check total cost by making a calculation on backend too
                RoomType roomType = await _unitOfWork.RoomType.Get(model.RoomTypeId);
                var baseTotal = roomType.Price * model.Nights;

                Booking booking = new Booking
                {
                    GuestId = guest.Id,
                    RoomId = model.RoomId,
                    RoomTypeId = model.RoomTypeId,
                    CheckInDate = model.CheckInDate,
                    CheckOutDate = model.CheckOutDate,
                    Adults = model.Adults,
                    Children = model.Children,
                    Promo = model.Promo,
                    Status = Status.Paid
                };

                await _unitOfWork.Booking.Add(booking);
                _unitOfWork.Save();

                //BillOfSale bill = new BillOfSale
                //{
                //    BookingId = booking.Id
                //};

                //await _unitOfWork.BillOfSale.Add(bill);
                //_unitOfWork.Save();

                //LineItemCharge roomCharge = new LineItemCharge
                //{
                //    Name = $"{roomType.Price} x {model.Nights} nights",
                //    Amount = baseTotal,
                //    BillOfSaleId = bill.Id
                //};

                //await _unitOfWork.LineItemCharge.Add(roomCharge);
                //_unitOfWork.Save();

                decimal feePercent = .1m;
                var serviceFee = Decimal.Multiply(baseTotal, feePercent);

                //LineItemCharge serviceCharge = new LineItemCharge
                //{
                //    Name = "Service Fee",
                //    Amount = serviceFee,
                //    BillOfSaleId = bill.Id
                //};

                //await _unitOfWork.LineItemCharge.Add(serviceCharge);
                //_unitOfWork.Save();

                return RedirectToAction("BookingSuccess", "Reservations", new 
                { 
                    bookingId = booking.Id,
                    guestId = guest.Id,
                    roomTypeId = model.RoomTypeId,
                    //billOfSaleId = bill.Id
                });

            }
            var roomTypeForError = await _unitOfWork.RoomType.Get(model.RoomTypeId);
            model.RoomType = roomTypeForError;
            return View(model);
        }

        public async Task<IActionResult> BookingSuccess(int bookingId, int guestId, int roomTypeId, int billOfSaleId)
        {
            var booking = await _unitOfWork.Booking.Get(bookingId);
            var guest = await _unitOfWork.Guest.Get(guestId);
            var roomType = await _unitOfWork.RoomType.Get(roomTypeId);
            var listOfCharges = await _unitOfWork.LineItemCharge.GetAll(charge => charge.BillOfSaleId == billOfSaleId);
            decimal totalCost = 0;

            foreach (var charge in listOfCharges)
            {
                totalCost += charge.Amount;
            }

            BookingSuccessViewModel model = new BookingSuccessViewModel()
            {
                Booking = booking,
                RoomType = roomType,
                Guest = guest,
                TotalCost = totalCost
            };

            return View(model);
        }
    }
}
