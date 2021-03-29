using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Aircash.Business.DataServices;
using Aircash.Business.HttpClientService;
using Aircash.DataContract.DTOs;
using Aircash.Repository.DataLayer.Models.Hotels;
using AutoMapper;
using log4net;
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
        private readonly IMapper _mapper;
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// DI of IDataService
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="mapper"></param>
        public HotelController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        /// <summary>
        /// GetHotelsAsync
        /// </summary>
        /// <param name="cityCode"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <param name="adults"></param>
        /// <param name="available"></param>
        /// <returns>List of HotelsDTO </returns>
        [Route("GetHotelsAsync/{cityCode}/{checkInDate}/{checkOutDate}/{adults}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotelsWithOffersAsync(string cityCode
            , DateTime checkInDate, DateTime checkOutDate, int adults, bool available = true)
        {
            try
            {
                _logger.Info($"{MethodBase.GetCurrentMethod()} is called");
                var response = await _dataService.GetHotelDataAsync(cityCode, checkInDate, checkOutDate, adults, available);

                if (!string.IsNullOrEmpty(response.ErrorMsg))
                {
                    return BadRequest(response.ErrorMsg);
                }

                var dto = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(response.Value);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.Info($"Error: {ex.Message}");
                return BadRequest(ex);
            }

        }
    }
}
