using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface ITravelInterestRepository
    {
        IEnumerable<TravelInterest> GetAllTravelInterests();
        TravelInterest GetTravelInterestById(int id);
    }
}
