using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface IUserHealthInterestRepository
    {
        void Create(UserHealthInterest userHealthInterest);
        void DeleteById(int id);
        IEnumerable<UserHealthInterest> GetAllUserHealthInterestsByUserId(string id);
        UserHealthInterest GetByUserAndInterestId(string userId, int interestId);
    }
}
