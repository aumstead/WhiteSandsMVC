using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLRoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        private readonly AppDbContext _context;

        public SQLRoomTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //public RoomType GetRoomTypeById(int id)
        //{
        //    return context.RoomTypes.Find(id);
        //}

        //public IEnumerable<RoomType> GetRoomTypes()
        //{
        //    var roomTypes = context.RoomTypes.Where(roomType => roomType.Id > 1);
        //    return roomTypes;
        //}
    }
}
