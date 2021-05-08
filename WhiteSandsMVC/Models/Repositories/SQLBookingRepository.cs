using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Models
{
    public class SQLBookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly AppDbContext _context;

        public SQLBookingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Booking Update(Booking bookingChanges)
        {
            var booking = _context.Bookings.Attach(bookingChanges);
            booking.State = EntityState.Modified;
            _context.SaveChanges();
            return bookingChanges;
        }
    }
}
