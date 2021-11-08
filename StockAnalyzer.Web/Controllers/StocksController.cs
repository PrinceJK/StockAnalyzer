using StockAnalyzer.Core;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;

namespace StockAnalyzer.Web.Controllers
{
    public class StocksController : ApiController
    {
        [Route("api/stocks/{ticker}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string ticker)
        {
            var store = new DataStore(HostingEnvironment.MapPath("~/bin"));

            var data = await store.LoadStocks();

            if (!data.ContainsKey(ticker)) return NotFound();

            return Json(data[ticker]);
        }
    }
}