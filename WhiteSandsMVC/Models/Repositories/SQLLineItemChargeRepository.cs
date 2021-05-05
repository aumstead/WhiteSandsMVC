using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLLineItemChargeRepository : GenericRepository<LineItemCharge>, ILineItemChargeRepository
    {
        private readonly AppDbContext _context;

        public SQLLineItemChargeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
