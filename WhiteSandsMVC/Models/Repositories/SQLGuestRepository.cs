using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLGuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        private readonly AppDbContext _context;

        public SQLGuestRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Guest Update(Guest guestChanges)
        {
            var guest = _context.Guests.Attach(guestChanges);
            guest.State = EntityState.Modified;
            _context.SaveChanges();
            return guestChanges;
        }

        //public Guest Create(Guest guest)
        //{
        //    context.Guests.Add(guest);
        //    context.SaveChanges();
        //    return guest;
        //}

        //public Guest GetGuest(int id)
        //{
        //    return context.Guests.Find(id);
        //}
    }
}
