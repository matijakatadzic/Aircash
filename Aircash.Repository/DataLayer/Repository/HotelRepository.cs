using Aircash.Repository.DataLayer.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircash.Repository.DataLayer.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly MainEntities _mainEntities;
        public HotelRepository(MainEntities mainEntities)
        {
            _mainEntities = mainEntities;
        }

        public async Task<IEnumerable<Hotel>> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults, bool available)
        {
            var query = _mainEntities.Hotels
                .Include(i=> i.Address)
                .Include(i => i.Description)
                .Include(i => i.Offers)
                .ThenInclude(i => i.Price)
                .Where(x => x.CityCode == cityCode);

            if (available)
            {
                query = query.Where(x => x.Offers.Any(y => y.CheckInDate >= checkInDate && y.CheckOutDate <= checkOutDate));
            }

            return await query.ToListAsync();
        }

        public async Task SaveHotelsAsync(List<Hotel> mapHotel)
        {
            await _mainEntities.AddRangeAsync(mapHotel);
            await _mainEntities.SaveChangesAsync();
        }
    }
}
