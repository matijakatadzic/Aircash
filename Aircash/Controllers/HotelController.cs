using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aircash.Business.DataServices;
using Aircash.Business.HttpClientService;
using Aircash.Repository.DataLayer.Models.Hotels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aircash.Controllers
{
    /// <summary>
    /// Hotel API
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// DI of IDataService
        /// </summary>
        /// <param name="dataService"></param>
        public HotelController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// GetHotelsAsync
        /// </summary>
        /// <param name="cityCode"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <param name="adults"></param>
        /// <returns>List of Hotels </returns>
        [Route("GetHotelsAsync/{cityCode}/{checkInDate}/{checkOutDate}/{adults}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults)
        {
            var response = await _dataService.GetHotelDataAsync(cityCode, checkInDate, checkOutDate, adults);

            return Ok(response);
        }
    }
}
