using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLUserTravelInterestRepository : IUserTravelInterestRepository
    {
        private readonly AppDbContext context;

        public SQLUserTravelInterestRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(UserTravelInterest userTravelInterest)
        {
            context.UserTravelInterests.Add(userTravelInterest);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var interestInDb = context.UserTravelInterests.SingleOrDefault(i => i.Id == id);

            if (interestInDb == null)
                throw new Exception("Not Found 400");

            context.Remove(interestInDb);
            context.SaveChanges();
        }

        public IEnumerable<UserTravelInterest> GetAllUserTravelInterestsByUserId(string id)
        {
             return context.UserTravelInterests.Where(i => i.UserId == id).Include(j=>j.Interest);
        }

        public UserTravelInterest GetByUserAndInterestId(string userId, int interestId)
        {
            return context.UserTravelInterests.Where(i => i.UserId == userId && i.TravelInterestId == interestId).SingleOrDefault();
        }
    }
}
