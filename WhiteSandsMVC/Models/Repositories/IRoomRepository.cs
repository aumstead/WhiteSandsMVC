using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Models
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Room Update(Room roomChanges);
    }
}
