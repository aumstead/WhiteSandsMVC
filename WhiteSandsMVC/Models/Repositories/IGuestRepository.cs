using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteSandsMVC.Models.Repositories;

namespace WhiteSandsMVC.Models
{
    public interface IGuestRepository : IGenericRepository<Guest>
    {
        Guest Update(Guest guestChanges);
    }
}
