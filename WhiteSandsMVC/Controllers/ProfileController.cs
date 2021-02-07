using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITravelInterestRepository travelInterestRepository;
        private readonly IUserTravelInterestRepository userTravelInterestRepository;
        private readonly IHealthInterestRepository healthInterestRepository;
        private readonly IUserHealthInterestRepository userHealthInterestRepository;
        private readonly IFoodInterestRepository foodInterestRepository;
        private readonly IUserFoodInterestRepository userFoodInterestRepository;

        public ProfileController(UserManager<ApplicationUser> userManager, ITravelInterestRepository travelInterestRepository, IUserTravelInterestRepository userTravelInterestRepository, IHealthInterestRepository healthInterestRepository, IUserHealthInterestRepository userHealthInterestRepository, IFoodInterestRepository foodInterestRepository, IUserFoodInterestRepository userFoodInterestRepository)
        {
            this.userManager = userManager;
            this.travelInterestRepository = travelInterestRepository;
            this.userTravelInterestRepository = userTravelInterestRepository;
            this.healthInterestRepository = healthInterestRepository;
            this.userHealthInterestRepository = userHealthInterestRepository;
            this.foodInterestRepository = foodInterestRepository;
            this.userFoodInterestRepository = userFoodInterestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User from httpcontext cannot be found";
                return View("NotFound");
            }

            var userTravelInterests = userTravelInterestRepository.GetAllUserTravelInterestsByUserId(user.Id);
            var userHealthInterests = userHealthInterestRepository.GetAllUserHealthInterestsByUserId(user.Id);
            var userFoodInterests = userFoodInterestRepository.GetAllUserFoodInterestsByUserId(user.Id);

            List<TravelInterest> subscribedUserTravelInterests = new List<TravelInterest>();
            List<HealthInterest> subscribedUserHealthInterests = new List<HealthInterest>();
            List<FoodInterest> subscribedUserFoodInterests = new List<FoodInterest>();

            foreach (var userTravelInterest in userTravelInterests)
            {
                subscribedUserTravelInterests.Add(userTravelInterest.Interest);
            }

            foreach (var userHealthInterest in userHealthInterests)
            {
                subscribedUserHealthInterests.Add(userHealthInterest.Interest);
            }

            foreach (var userFoodInterest in userFoodInterests)
            {
                subscribedUserFoodInterests.Add(userFoodInterest.Interest);
            }

            var travelInterests = travelInterestRepository.GetAllTravelInterests();
            var healthInterests = healthInterestRepository.GetAllHealthInterests();
            var foodInterests = foodInterestRepository.GetAllFoodInterests();

            if (travelInterests == null || healthInterests == null || foodInterests == null)
            {
                ViewBag.ErrorMessage = $"Travel or health or food interests cannot be found";
                return View("NotFound");
            }

            var model = new ProfileViewModel
            {
                Id = user.Id,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MattressPreference = user.MattressPreference,
                PillowPreference = user.PillowPreference,
                SmokingPreference = user.SmokingPreference,
                TravelInterests = travelInterests.ToList(),
                SubscribedUserTravelInterests = subscribedUserTravelInterests,
                HealthInterests = healthInterests.ToList(),
                SubscribedUserHealthInterests = subscribedUserHealthInterests,
                FoodInterests = foodInterests.ToList(),
                SubscribedUserFoodInterests = subscribedUserFoodInterests
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User from httpcontext cannot be found";
                return View("NotFound");
            }
            else
            {
                user.MattressPreference = model.MattressPreference;
                user.PillowPreference = model.PillowPreference;
                user.SmokingPreference = model.SmokingPreference;

                var result = await userManager.UpdateAsync(user);

                model = new ProfileViewModel
                {
                    Id = user.Id,
                    Title = user.Title,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MattressPreference = user.MattressPreference,
                    PillowPreference = user.PillowPreference,
                    SmokingPreference = user.SmokingPreference
                };

                if (result.Succeeded)
                {
                    return View(model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

    }
}
