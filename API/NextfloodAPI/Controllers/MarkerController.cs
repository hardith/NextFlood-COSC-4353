using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NextfloodAPI.Services;
using NextfloodAPI.Models;

namespace NextfloodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkerController : ControllerBase
    {
        private IMarkerPointServices markerPointServices;

        public MarkerController(IMarkerPointServices markerPointServices)
        {
            this.markerPointServices = markerPointServices;
        }

        [HttpGet("GetAllMarkerPoints")]
         public Task<List<MarkerPoint>> GetAllMarkerPoints()
        {
            //return null;
            return markerPointServices.GetAllMarkerPoints();
        }

        [HttpGet("GetMarkerPointsBySeverity")]
        public Task<List<MarkerPoint>> GetMarkerPointsBySeverity(string severity)
        {
            return markerPointServices.GetMarkerPointsBySeverity(severity);
        }

        [HttpGet("GetMarkerPointsById")]
        public Task<List<MarkerPoint>> GetMarkerPointsById(int id)
        {
            return markerPointServices.GetMarkerPointsById(id);
        }

        //[HttpPost("")]
        //public Task<MarkerPoint> AddMarkerPoint(MarkerPoint markerPoint)
        //{
        //    var marker = markerPointServices.AddNewMarkerPoint(markerPoint);
        //    return 
        //}

        [HttpPost("AddMarkerPoint")]
        public Task<int> AddMarkerPoint([FromForm] MarkerPoint markerPoint)
        {
            return markerPointServices.AddNewMarkerPoint(markerPoint);
        }

        [HttpDelete("DeleteMarkerPoint")]
        public Task<int> DeleteMarkerPointByID(int id)
        {
            return markerPointServices.DeleteMarkerPointByID(id);
        }

        [HttpPut("UpdateMarkerPointByID")]
        public Task<int> UpdateMarkerPointByID([FromForm] MarkerPoint markerPoint)
        {
            return markerPointServices.UpdateMarkerPointByID(markerPoint);
        }
        
    }
}
