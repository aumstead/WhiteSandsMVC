using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLRoomRepository : IRoomRepository
    {
        private readonly AppDbContext context;

        public SQLRoomRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Room> GetAllAvailableRooms()
        {
            var rooms = context.Rooms.Where(room => room.Id > 3);
            return rooms;
        }

        public Room GetRoomById(int id)
        {
            var room = context.Rooms.Find(id);
            return room;
        }

        public Room GetRoomByRoomTypeId(int id)
        {
            var room = context.Rooms.FirstOrDefault(r => r.RoomTypeId == id);
            return room;
        }
    }
}
