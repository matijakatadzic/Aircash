using Aircash.Repository.DataLayer.Models.Hotels;
using Aircash.Repository.DataLayer.Models.IataCodes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircash.Repository.DataLayer.Repository
{
    public class IataRepository : IIataRepository
    {
        private readonly MainEntities _mainEntities;
        public IataRepository(MainEntities mainEntities)
        {
            _mainEntities = mainEntities;
        }

        public async Task<IEnumerable<IATA>> GetIataDataAsync()
        {
            return await _mainEntities.IATA.ToListAsync();
        }

        public async Task SaveIATACodesAsync(IEnumerable<IATA> myDeserializedClass)
        {
            await _mainEntities.AddRangeAsync(myDeserializedClass);
            await _mainEntities.SaveChangesAsync();
        }
    }
}
