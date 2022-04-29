using mStockAPI.DTOs;
using mStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;
using AutoMapper;
using System.Web.Http.Description;

namespace mStockAPI.Controllers
{
    [EnableCors("*", "*", "GET")]
    [RoutePrefix("api/stocks")]
    public class StocksController : ApiController
    {
        private readonly mStockContext context;
        public StocksController()
        {
            context = new mStockContext();
        }
        /// <summary>
        /// Retreives the stock details of selected companies in given date range
        /// </summary>
        /// <returns>An array of stock details</returns>
        /// <response code="200">Stock details of selected companies</response>
        [HttpGet]
        [ResponseType(typeof(StocksResponse[]))]
        public IHttpActionResult Get(int companyCode1, int companyCode2, DateTime fromDate, DateTime toDate)
        {
            var result = from stocks in context.CompanyStocks.Include(c => c.Company)
                         orderby stocks.Date, stocks.StockPrice descending
                         where (stocks.Date >= fromDate.Date &&
                                stocks.Date <= toDate.Date) &&
                               (stocks.CompanyCode == companyCode1 ||
                                stocks.CompanyCode == companyCode2)
                         select stocks;
            var response = Mapper.Map<StocksResponse[]>(result.ToArray());
            return Ok(response);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
