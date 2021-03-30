using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Aircash.Business.DataServices;
using Aircash.DataContract.DTOs;
using Aircash.Repository.DataLayer.Models.IataCodes;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aircash.API.Controllers
{
    /// <summary>
    /// IATA codes controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class IataController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// DI of IDataService
        /// </summary>
        /// <param name="dataService"></param>
        public IataController(IDataService dataService)
        {
            _dataService = dataService;
        }
        /// <summary>
        /// GetIataDataAsync
        /// </summary>
        /// <returns>List of IataDTO </returns>
        [Route("GetIataDataAsync")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IataDTO>>> GetIataDataAsync()
        {
            try
            {
                //One time populate data from airports.json file!

                //using (StreamReader r = new StreamReader("airports.json"))
                //{
                //    string json = r.ReadToEnd();
                //    var myDeserializedClass = JsonConvert.DeserializeObject<IEnumerable<IATA>>(json);
                //    await _dataService.SaveIATACodesAsync(myDeserializedClass);
                //}

                _logger.Info($"{MethodBase.GetCurrentMethod()} is called");
                var response = await _dataService.GetIataDataAsync();

                if (!string.IsNullOrEmpty(response.ErrorMsg))
                {
                    return BadRequest(response.ErrorMsg);
                }

                var dto = response.Value.GroupBy(g => g.Country)
                    .Select(s => new IataDTO 
                    { 
                        Country = s.Key,
                        IataCityCodeDTO =  s.Select(sel => new IataCityCodeDTO 
                        { 
                            City = sel.City,
                            Code = sel.Code
                        })
                    });

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
