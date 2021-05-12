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
    public class BillingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(new { data = await _unitOfWork.Booking.GetAll(null, null, "Guest,BillOfSale") });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLineItemCharge(int id)
        {
            var chargeFromDb = await _unitOfWork.LineItemCharge.Get(id);
            if (chargeFromDb == null)
            {
                return Json(new { success = false, message = "Server error while deleting" });
            }
            _unitOfWork.LineItemCharge.Remove(chargeFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
