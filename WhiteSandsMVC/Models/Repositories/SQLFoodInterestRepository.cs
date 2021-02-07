using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLFoodInterestRepository : IFoodInterestRepository
    {
        private readonly AppDbContext context;

        public SQLFoodInterestRepository(AppDbContext context)
        {
            this.context = context;
        }

        public FoodInterest GetFoodInterestById(int id)
        {
            var interest = context.FoodInterests.Find(id);
            return interest;
        }

        public IEnumerable<FoodInterest> GetAllFoodInterests()
        {
            return context.FoodInterests;
        }
    }
}
