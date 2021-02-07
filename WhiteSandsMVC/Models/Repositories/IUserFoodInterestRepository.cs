using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface IUserFoodInterestRepository
    {
        void Create(UserFoodInterest userFoodInterest);
        void DeleteById(int id);
        IEnumerable<UserFoodInterest> GetAllUserFoodInterestsByUserId(string id);
        UserFoodInterest GetByUserAndInterestId(string userId, int interestId);
    }
}
