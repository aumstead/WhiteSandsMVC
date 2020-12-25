using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models
{
    public interface IGuestRepository
    {
        Guest GetGuest(int id);
        Guest Create(Guest guest);
    }
}
