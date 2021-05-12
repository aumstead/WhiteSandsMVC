using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WhiteSandsMVC.Pages.Admin.Rooms
{
    [Authorize(Roles = "Admin, Employee")]
    public class OccupiedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
