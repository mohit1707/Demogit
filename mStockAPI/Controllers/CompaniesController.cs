using AutoMapper;
using mStockAPI.DTOs;
using mStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace mStockAPI.Controllers
{
    [EnableCors("*", "*", "GET")]
    [RoutePrefix("api/companies")]
    public class CompaniesController : ApiController
    {
        private readonly mStockContext context;
        public CompaniesController()
        {
            context = new mStockContext();
        }

        /// <summary>
        /// Retreives all companies details
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet]
        [ResponseType(typeof(CompanyDetailsRespone[]))]
        public IHttpActionResult Get()
        {
            var result = context.Companies.ToArray();
            var companiesresponse = Mapper.Map<CompanyDetailsRespone[]>(result);
            return Ok(companiesresponse);
        }

       

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
