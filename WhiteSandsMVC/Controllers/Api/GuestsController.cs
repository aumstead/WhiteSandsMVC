using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(new { data = await _unitOfWork.Guest.GetAll() });
        }
    }
}
