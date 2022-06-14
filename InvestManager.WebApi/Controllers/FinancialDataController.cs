namespace InvestManager.WebApi.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using FinancialData.UseCases.GetCurrentPrice;
    using FinancialData.UseCases.GetPriceChart;
    using FinancialData.UseCases.GetStocksList;
    using FinancialData.UseCases.SearchSymbols;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]/[action]")]
    public class FinancialDataController : Controller
    {
        private readonly IMediator _mediator;

        public FinancialDataController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(GetCurrentPriceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCurrentPrice(GetCurrentPriceQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(SearchSymbolsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SearchSymbols(SearchSymbolsQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(GetPriceChartResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPriceChart(GetPriceChartQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(GetStocksListResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStocksList(GetStocksListQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
    }
}