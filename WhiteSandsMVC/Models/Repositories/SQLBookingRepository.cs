using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public class SQLBookingRepository : IBookingRepository
    {
        private readonly AppDbContext context;

        public SQLBookingRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Booking Create(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
            return booking;
        }

        public Booking Delete(int id)
        {
            Booking bookingFromDb = context.Bookings.Find(id);
            if (bookingFromDb != null)
            {
                context.Bookings.Remove(bookingFromDb);
                context.SaveChanges();
            }
            return bookingFromDb;
        }

        public Booking GetBooking(int id)
        {
            return context.Bookings.Find(id);
        }

        public Booking Update(Booking bookingChanges)
        {
            var booking = context.Bookings.Attach(bookingChanges);
            booking.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookingChanges;
        }
    }
}
