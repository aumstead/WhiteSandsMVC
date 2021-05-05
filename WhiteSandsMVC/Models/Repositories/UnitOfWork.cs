using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteSandsMVC.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IBookingRepository _booking;
        private IGuestRepository _guest;
        private ILineItemChargeRepository _lineItemCharge;
        private IBillOfSaleRepository _billOfSale;
        private IRoomTypeRepository _roomType;
        private IRoomRepository _room;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBookingRepository Booking => _booking ??= new SQLBookingRepository(_context);
        public IGuestRepository Guest => _guest ??= new SQLGuestRepository(_context);
        public ILineItemChargeRepository LineItemCharge => _lineItemCharge ??= new SQLLineItemChargeRepository(_context);
        public IBillOfSaleRepository BillOfSale => _billOfSale ??= new SQLBillOfSaleRepository(_context);
        public IRoomTypeRepository RoomType => _roomType ??= new SQLRoomTypeRepository(_context);
        public IRoomRepository Room => _room ??= new SQLRoomRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
