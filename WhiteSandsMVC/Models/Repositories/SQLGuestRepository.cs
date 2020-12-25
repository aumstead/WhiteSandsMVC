using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLGuestRepository : IGuestRepository
    {
        private readonly AppDbContext context;

        public SQLGuestRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Guest Create(Guest guest)
        {
            context.Guests.Add(guest);
            context.SaveChanges();
            return guest;
        }

        public Guest GetGuest(int id)
        {
            return context.Guests.Find(id);
        }
    }
}
