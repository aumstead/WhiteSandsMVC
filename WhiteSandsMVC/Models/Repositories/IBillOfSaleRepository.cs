﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface IBillOfSaleRepository : IGenericRepository<BillOfSale>
    {
        BillOfSale Update(BillOfSale billOfSaleChanges);
    }
}
