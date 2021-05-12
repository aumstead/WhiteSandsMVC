using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Pages.Admin.Rooms
{
    [Authorize(Roles = "Admin, Employee")]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int roomId)
        {
            var room = await _unitOfWork.Room.GetFirstOrDefault(room => room.Id == roomId, "RoomType");

            Input = new InputModel
            {
                Room = room
            };

            return Page();
        }

        public class InputModel
        {
            public Room Room { get; set; }
        }
    }
}
