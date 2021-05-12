using Microsoft.EntityFrameworkCore;
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

        public LineItemCharge Update(LineItemCharge lineItemChargeChanges)
        {
            var lineItemCharge = _context.LineItemCharges.Attach(lineItemChargeChanges);
            lineItemCharge.State = EntityState.Modified;
            _context.SaveChanges();
            return lineItemChargeChanges;
        }
    }
}
