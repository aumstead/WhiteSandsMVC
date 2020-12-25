using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public interface IBookingRepository
    {
        Booking GetBooking(int id);
        Booking Create(Booking booking);
        Booking Update(Booking bookingChanges);
        Booking Delete(int id);
    }
}
