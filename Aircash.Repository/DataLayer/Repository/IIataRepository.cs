using Aircash.Repository.DataLayer.Models.Hotels;
using Aircash.Repository.DataLayer.Models.IataCodes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircash.Repository.DataLayer.Repository
{
    public interface IIataRepository
    {
        Task<IEnumerable<IATA>> GetIataDataAsync();
        Task SaveIATACodesAsync(IEnumerable<IATA> myDeserializedClass);
    }
}