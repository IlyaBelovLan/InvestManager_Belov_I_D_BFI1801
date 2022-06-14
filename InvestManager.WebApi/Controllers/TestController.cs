/*namespace InvestManager.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using TwelveData.Client;
    using TwelveData.Requests.Common;
    using TwelveData.Requests.TimeSeries;

    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ITwelveDataClient _client;

        public TestController(ITwelveDataClient client)
        {
            _client = client;

        }

        [HttpGet]
        public async Task<IActionResult> GetPrice(string symbol, string exchange, string country)
        {
            var response = await _client.GetRealTimePriceAsync(p => p
                .BySymbol(symbol)
                .ByExchange(exchange)
                .ByCountry(country)).ConfigureAwait(false);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchSymbol(string symbol, int outputSize)
        {
            var response = await _client.SearchSymbolsAsync(s => s
                .BySymbol(symbol)
                .ByOutputSize(outputSize)).ConfigureAwait(false);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTimeSeries(string symbol, string exchange, TwoPointsInterval interval, string country, int outputSize)
        {
            var response = await _client.GetTimeSeriesAsync(s => s
                .BySymbol(symbol)
                .ByExchange(exchange)
                .ByInterval(interval)
                .ByCountry(country)
                .ByOutputSize(outputSize)).ConfigureAwait(false);
            return Ok(response);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> TestAuthorize()
        {
            return Ok("Авторизированно!");
        }
        
    }
}*/