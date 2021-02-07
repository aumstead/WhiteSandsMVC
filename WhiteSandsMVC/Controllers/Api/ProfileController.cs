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
    public class ProfileController : ControllerBase
    {
        private readonly IUserTravelInterestRepository userTravelInterestRepository;
        private readonly IUserHealthInterestRepository userHealthInterestRepository;
        private readonly IUserFoodInterestRepository userFoodInterestRepository;

        public ProfileController(IUserTravelInterestRepository userTravelInterestRepository, IUserHealthInterestRepository userHealthInterestRepository, IUserFoodInterestRepository userFoodInterestRepository)
        {
            this.userTravelInterestRepository = userTravelInterestRepository;
            this.userHealthInterestRepository = userHealthInterestRepository;
            this.userFoodInterestRepository = userFoodInterestRepository;
        }

        [HttpPost]
        public IActionResult AddInterest(string userId, int interestId, string type)
        {
            if (type == "TravelAndLife")
            {
                var userTravelInterest = new UserTravelInterest
                {
                    UserId = userId,
                    TravelInterestId = interestId
                };

                userTravelInterestRepository.Create(userTravelInterest);
                return Ok();
            }
            else if (type == "HealthAndWellness")
            {
                var userHealthInterest = new UserHealthInterest
                {
                    UserId = userId,
                    HealthInterestId = interestId
                };

                userHealthInterestRepository.Create(userHealthInterest);
                return Ok();
            }
            else if (type == "FoodAndDrink")
            {
                var userFoodInterest = new UserFoodInterest
                {
                    UserId = userId,
                    FoodInterestId = interestId
                };

                userFoodInterestRepository.Create(userFoodInterest);
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpDelete]
        public IActionResult RemoveInterest(string userId, int interestId, string type)
        {
            if (type == "TravelAndLife")
            {
                var interestToRemove = userTravelInterestRepository.GetByUserAndInterestId(userId, interestId);

                userTravelInterestRepository.DeleteById(interestToRemove.Id);
                return Ok();
            }
            else if (type == "HealthAndWellness")
            {
                var interestToRemove = userHealthInterestRepository.GetByUserAndInterestId(userId, interestId);

                userHealthInterestRepository.DeleteById(interestToRemove.Id);
                return Ok();
            }
            else if (type == "FoodAndDrink")
            {
                var interestToRemove = userFoodInterestRepository.GetByUserAndInterestId(userId, interestId);

                userFoodInterestRepository.DeleteById(interestToRemove.Id);
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
