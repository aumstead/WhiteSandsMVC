using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;
using WhiteSandsMVC.Utility;

namespace WhiteSandsMVC.Pages.Admin.check_in.edit
{
    [Authorize(Roles = "Admin, Employee")]
    public class RoomModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int bookingId)
        {
            var booking = await _unitOfWork.Booking.GetFirstOrDefault((b => b.Id == bookingId), "Room,RoomType");
            if (booking == null)
                return RedirectToAction("NotFound", "Error");

            var roomTypes = await _unitOfWork.RoomType.GetAll();
            var rooms = await _unitOfWork.Room.GetAll();

            List<string> statusTypes = new List<string>();

            statusTypes.Add(BookingStatus.Booked);
            statusTypes.Add(BookingStatus.CheckedIn);
            statusTypes.Add(BookingStatus.CheckedOut);

            Input = new InputModel
            {
                RoomTypeId = booking.RoomType.Id,
                Status = booking.Status,
                Notes = booking.Notes,
                RoomTypes = roomTypes,
                Rooms = rooms,
                StatusTypes = statusTypes,
                BookingId = bookingId
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookingObj = await _unitOfWork.Booking.Get(Input.BookingId);



                if (bookingObj.RoomTypeId != Input.RoomTypeId)
                {
                    var newRoom = await _unitOfWork.Room.GetFirstOrDefault(room => room.RoomTypeId == Input.RoomTypeId);
                    bookingObj.RoomId = newRoom.Id;
                }

                bookingObj.RoomTypeId = Input.RoomTypeId;
                bookingObj.Status = Input.Status;
                bookingObj.Notes = Input.Notes;

                _unitOfWork.Booking.Update(bookingObj);

                return RedirectToPage("/Admin/check-in/StepOneVerifyStay", new { id = Input.BookingId });
            }

            return Page();
        }

        public class InputModel
        {

            [Required]
            [Display(Name = "Room Type")]
            public int RoomTypeId { get; set; }

            [Required]
            public string Status { get; set; }

            public string Notes { get; set; }

            public IEnumerable<RoomType> RoomTypes { get; set; }
            public IEnumerable<Room> Rooms { get; set; }
            public IEnumerable<string> StatusTypes { get; set; }

            public int BookingId { get; set; }
        }
    }
}
