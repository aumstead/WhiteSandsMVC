using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Booking { get; }
        IGuestRepository Guest { get; }
        ILineItemChargeRepository LineItemCharge { get; }
        IBillOfSaleRepository BillOfSale { get; }
        IRoomTypeRepository RoomType { get; }
        IRoomRepository Room { get; }
        void Save();
    }
}
