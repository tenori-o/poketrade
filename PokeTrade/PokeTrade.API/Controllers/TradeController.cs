using Microsoft.AspNetCore.Mvc;
using PokeTrade.Application.IService;
using PokeTrade.Domain.Dtos;
using PokeTrade.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeTrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpPost]
        [Route("MakeTrade")]
        public ActionResult<bool> MakeTrade([FromBody] TradeViewModel trade)
        {
            try
            {
                return _tradeService.MakeTrade(trade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTradeHistory")]
        public ActionResult<IEnumerable<TradeViewModel>> GetTradeHistory()
        {
            try
            {
                return Ok(_tradeService.GetHistory());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
