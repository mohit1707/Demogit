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
    [EnableCors("*", "*", "GET,POST,DELETE")]
    [RoutePrefix("api/watchlist")]
    public class WatchListController : ApiController
    {
        private readonly mStockContext context;
        public WatchListController()
        {
            context = new mStockContext();
        }

        /// <summary>
        /// Retreives company details from watch list of the user 
        /// </summary>
        /// <param name="userid">UserId whose watch list to be fetched</param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="400">Invalid userid</response>
        [HttpGet]
        [ResponseType(typeof(CompanyDetailsRespone[]))]
        [Route("{userid:int}")]
        public IHttpActionResult Get([FromUri] int userid)
        {
            var user = context.Users.Find(userid);
            if (user == null)
                return BadRequest();
            var result = from item in context.WatchList
                         where item.UserId == userid
                         select item.Company;
            var companiesreponse = Mapper.Map<CompanyDetailsRespone[]>(result);
            return Ok(companiesreponse);
        }

        /// <summary>
        /// Add a company to user's watch list
        /// </summary>
        /// <param name="model">Company and user details to save</param>
        /// <returns></returns>
        /// <response code="201">Added to watch list</response>
        /// <response code="400">Invalid company or user</response>
        /// <response code="409">Already present in watch list</response>
        /// <response code="500">Unable to remove from list</response>
        [HttpPost]
        public IHttpActionResult Post([FromBody] WatchListRequest model)
        {
            if (!context.Users.Any(u => u.UserId == model.UserId))
                return BadRequest();
            if (!context.Companies.Any(c => c.CompanyCode == model.CompanyCode))
                return BadRequest();
            if (context.WatchList.Any(w => w.UserId == model.UserId && w.CompanyCode == model.CompanyCode))
                return Conflict();

            var watch = Mapper.Map<CompanyDetailsWatch>(model);
            context.WatchList.Add(watch);
            var rows = context.SaveChanges();
            if (rows == 1)
                return StatusCode(HttpStatusCode.Created);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Removes a company to user's watch list
        /// </summary>
        /// <param name="model">Company and user details to remove</param>
        /// <returns></returns>
        /// <response code="204">Removed from watch list</response>
        /// <response code="500">Unable to remove from the list</response>
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] WatchListRequest model)
        {
           
            if (!context.WatchList.Any(w => w.UserId == model.UserId && w.CompanyCode == model.CompanyCode))
                return BadRequest();

            var watchitem = context.WatchList.Single(w => w.UserId == model.UserId && w.CompanyCode == model.CompanyCode);
            context.WatchList.Remove(watchitem);
            var rows = context.SaveChanges();
            if (rows == 1)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return InternalServerError();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
