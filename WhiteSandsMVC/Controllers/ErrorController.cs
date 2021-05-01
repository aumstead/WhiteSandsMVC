using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;

namespace WhiteSandsMVC.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested cannot be found";
                    
                    break;
            }

            return View("NotFound");
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return View("Error");
        }

        [Route("/error/construction")]
        public IActionResult UnderConstruction()
        {
            return View("UnderConstruction");
        }

       
    }
}
