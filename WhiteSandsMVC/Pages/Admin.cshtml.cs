using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin
{
    [Authorize(Roles = "Admin, Employee")]
    public class AdminModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var today = DateTime.Today;
            var arrivals = await _unitOfWork.Booking.GetAll(booking => booking.CheckInDate == today);
            var departures = await _unitOfWork.Booking.GetAll(booking => booking.CheckOutDate == today);
            // inHouse and stayovers queries are adjusted for dummy data
            var inHouse = await _unitOfWork.Booking.GetAll(booking => booking.Status == "Checked In" && booking.CheckOutDate > today);
            var stayovers = await _unitOfWork.Booking.GetAll(booking => booking.Status == "Checked In" && booking.CheckInDate != today && booking.CheckOutDate > today);
            var allRooms = await _unitOfWork.Room.GetAll();

            var arrived = 0;
            var departed = 0;
            var availableRooms = 18;
            foreach (var guest in arrivals)
            {
                if (guest.Status == "Checked In")
                    arrived += 1;
            }
            foreach (var guest in departures)
            {
                if (guest.Status == "Checked Out")
                    departed += 1;
            }
            // availableRooms is hardcoded for demo
            //foreach (var room in allRooms)
            //{
            //    if (room.Available)
            //        availableRooms += 1;
            //}

            double availablePercentage = (double)availableRooms / allRooms.Count();
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.PercentDecimalDigits = 0;
            
            Input = new InputModel
            {
                Today = today,
                Arrivals = arrivals.Count(),
                Departures = departures.Count(),
                Arrived = arrived,
                Departed = departed,
                InHouse = inHouse.Count(),
                Stayovers = stayovers.Count(),
                TotalRooms = allRooms.Count(),
                Available = availableRooms,
                AvailablePercentage = availablePercentage.ToString("P", nfi),
                Occupied = allRooms.Count() - availableRooms
            };

            return Page();
        }

        public class InputModel
        {
            public DateTime Today { get; set; }
            public int Arrivals { get; set; }
            public int Departures { get; set; }
            public int Arrived { get; set; }
            public int Departed { get; set; }
            public int InHouse { get; set; }
            public int Stayovers { get; set; }
            public int Available { get; set; }
            public string AvailablePercentage { get; set; }
            public int Occupied { get; set; }
            public int TotalRooms { get; set; }
        }
    }
}
