using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface IFoodInterestRepository
    {
        IEnumerable<FoodInterest> GetAllFoodInterests();
        FoodInterest GetFoodInterestById(int id);
    }
}
