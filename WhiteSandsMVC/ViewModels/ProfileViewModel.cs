using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models;

namespace WhiteSandsMVC.ViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Mattress")]
        public string MattressPreference { get; set; }

        [Display(Name = "Pillows")]
        public string PillowPreference { get; set; }

        [Display(Name = "Room")]
        public string SmokingPreference { get; set; }

        public List<TravelInterest> TravelInterests { get; set; }
        public List<TravelInterest> SubscribedUserTravelInterests { get; set; }
        public List<HealthInterest> HealthInterests { get; set; }
        public List<HealthInterest> SubscribedUserHealthInterests { get; set; }
        public List<FoodInterest> FoodInterests { get; set; }
        public List<FoodInterest> SubscribedUserFoodInterests { get; set; }
    }
}
