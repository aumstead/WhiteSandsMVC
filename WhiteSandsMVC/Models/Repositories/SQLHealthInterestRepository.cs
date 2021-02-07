using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLHealthInterestRepository : IHealthInterestRepository
    {
        private readonly AppDbContext context;

        public SQLHealthInterestRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<HealthInterest> GetAllHealthInterests()
        {
            return context.HealthInterests;
        }

        public HealthInterest GetHealthInterestById(int id)
        {
            var interest = context.HealthInterests.Find(id);
            return interest;
        }
    }
}
