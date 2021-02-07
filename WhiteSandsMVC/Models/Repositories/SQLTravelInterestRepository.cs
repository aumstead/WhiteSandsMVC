using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLTravelInterestRepository : ITravelInterestRepository
    {
        private readonly AppDbContext context;

        public SQLTravelInterestRepository(AppDbContext context)
        {
            this.context = context;
        }

        public TravelInterest GetTravelInterestById(int id)
        {
            var interest = context.TravelInterests.Find(id);
            return interest;
        }

        public IEnumerable<TravelInterest> GetAllTravelInterests()
        {
            return context.TravelInterests;
        }
    }
}
