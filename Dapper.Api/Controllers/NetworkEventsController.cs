using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Core.Abstraction;
using Dapper.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dapper.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkEventsController : ControllerBase
    {
        private readonly ILogger<NetworkEventsController> _logger;
        private readonly INetworkEventsService _dapperCtx;


        public NetworkEventsController(ILogger<NetworkEventsController> logger, INetworkEventsService repo)
        {
            _logger = logger;
            _dapperCtx = repo;
        }





        [HttpGet]
        public async Task<IEnumerable<NetworkEvent>> GetAllAsync()
        {
            IEnumerable<NetworkEvent> res = new List<NetworkEvent>();
            try
            {
                res = await _dapperCtx.GetAllEventsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return res;
        }



        [HttpGet("{id}")]
        public async Task<NetworkEvent> GetByIdAsync(int id)
        {
            var res = new NetworkEvent();
            try
            {
                res = await _dapperCtx.GetEventByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return res;
        }
    }
}
