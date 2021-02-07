using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface IUserTravelInterestRepository
    {
        void Create(UserTravelInterest userTravelInterest);
        void DeleteById(int id);
        IEnumerable<UserTravelInterest> GetAllUserTravelInterestsByUserId(string id);
        UserTravelInterest GetByUserAndInterestId(string userId, int interestId);
    }
}
