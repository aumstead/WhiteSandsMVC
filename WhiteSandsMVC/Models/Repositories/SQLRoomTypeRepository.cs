using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLRoomTypeRepository : IRoomTypeRepository
    {
        private readonly AppDbContext context;

        public SQLRoomTypeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public RoomType GetRoomTypeById(int id)
        {
            return context.RoomTypes.Find(id);
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            var roomTypes = context.RoomTypes.Where(roomType => roomType.Id > 1);
            return roomTypes;
        }
    }
}
