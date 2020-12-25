using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public interface IRoomRepository
    {
        //Room GetAllAvailableRooms(DateTime checkInDate, DateTime checkOutDate);
        IEnumerable<Room> GetAllAvailableRooms();
        Room GetRoomById(int id);
        Room GetRoomByRoomTypeId(int id);

    }
}
