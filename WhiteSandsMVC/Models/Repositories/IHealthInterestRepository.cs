using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface IHealthInterestRepository
    {
        IEnumerable<HealthInterest> GetAllHealthInterests();
        HealthInterest GetHealthInterestById(int id);
    }
}
