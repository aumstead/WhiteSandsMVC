using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class SQLBillOfSaleRepository : GenericRepository<BillOfSale>, IBillOfSaleRepository
    {
        private readonly AppDbContext _context;

        public SQLBillOfSaleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
