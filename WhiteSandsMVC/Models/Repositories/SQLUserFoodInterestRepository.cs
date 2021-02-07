using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLUserFoodInterestRepository : IUserFoodInterestRepository
    {
        private readonly AppDbContext context;

        public SQLUserFoodInterestRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(UserFoodInterest userFoodInterest)
        {
            context.UserFoodInterests.Add(userFoodInterest);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var interestInDb = context.UserFoodInterests.SingleOrDefault(i => i.Id == id);

            if (interestInDb == null)
                throw new Exception("Not Found 400");

            context.Remove(interestInDb);
            context.SaveChanges();
        }

        public IEnumerable<UserFoodInterest> GetAllUserFoodInterestsByUserId(string id)
        {
             return context.UserFoodInterests.Where(i => i.UserId == id).Include(j=>j.Interest);
        }

        public UserFoodInterest GetByUserAndInterestId(string userId, int interestId)
        {
            return context.UserFoodInterests.Where(i => i.UserId == userId && i.FoodInterestId == interestId).SingleOrDefault();
        }
    }
}
