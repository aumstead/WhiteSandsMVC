using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLUserHealthInterestRepository : IUserHealthInterestRepository
    {
        private readonly AppDbContext context;

        public SQLUserHealthInterestRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(UserHealthInterest userHealthInterest)
        {
            context.UserHealthInterests.Add(userHealthInterest);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var interestInDb = context.UserHealthInterests.SingleOrDefault(i => i.Id == id);

            if (interestInDb == null)
                throw new Exception("Not Found 400");

            context.Remove(interestInDb);
            context.SaveChanges();
        }

        public IEnumerable<UserHealthInterest> GetAllUserHealthInterestsByUserId(string id)
        {
             return context.UserHealthInterests.Where(i => i.UserId == id).Include(j=>j.Interest);
        }

        public UserHealthInterest GetByUserAndInterestId(string userId, int interestId)
        {
            return context.UserHealthInterests.Where(i => i.UserId == userId && i.HealthInterestId == interestId).SingleOrDefault();
        }
    }
}
