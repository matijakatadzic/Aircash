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

        public async Task<IEnumerable<Hotel>> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults)
        {
            var query = _mainEntities.Hotels.Where(x => x.CityCode == cityCode);
            return await query.ToListAsync();
        }

        public async Task SaveHotelsAsync(List<Hotel> mapHotel)
        {
            await _mainEntities.AddRangeAsync(mapHotel);
            await _mainEntities.SaveChangesAsync();
        }
    }
}
