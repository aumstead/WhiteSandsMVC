using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLRoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly AppDbContext _context;

        public SQLRoomRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Room Update(Room roomChanges)
        {
            var room = _context.Rooms.Attach(roomChanges);
            room.State = EntityState.Modified;
            _context.SaveChanges();
            return roomChanges;
        }
    }
}
