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

        //public Booking Create(Booking booking)
        //{
        //    context.Bookings.Add(booking);
        //    context.SaveChanges();
        //    return booking;
        //}

        //public Booking Delete(int id)
        //{
        //    Booking bookingFromDb = context.Bookings.Find(id);
        //    if (bookingFromDb != null)
        //    {
        //        context.Bookings.Remove(bookingFromDb);
        //        context.SaveChanges();
        //    }
        //    return bookingFromDb;
        //}

        //public Booking GetBooking(int id)
        //{
        //    return context.Bookings.Find(id);
        //}

        public Booking Update(Booking bookingChanges)
        {
            var booking = _context.Bookings.Attach(bookingChanges);
            booking.State = EntityState.Modified;
            _context.SaveChanges();
            return bookingChanges;
        }

        //public IEnumerable<Booking> GetAllBookings()
        //{
        //    return context.Bookings.Include(b => b.Guest);
        //}
    }
}
