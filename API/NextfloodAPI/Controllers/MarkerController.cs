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
        public async Task<List<MarkerPoint>> GetAllMarkerPoints()
        {
            return await markerPointServices.GetAllMarkerPoints();
        }

        [HttpGet("GetMarkerPointsBySeverity")]
        public async Task<List<MarkerPoint>> GetMarkerPointsBySeverity(string severity)
        {
            return await markerPointServices.GetMarkerPointsBySeverity(severity);
        }

        [HttpGet("GetMarkerPointsById")]
        public async Task<MarkerPoint> GetMarkerPointsById(int id)
        {
            return await markerPointServices.GetMarkerPointsById(id);
        }

        [HttpPost("AddMarkerPoint")]
        public async Task<int> AddMarkerPoint(MarkerPoint markerPoint)
        {
            return await markerPointServices.AddNewMarkerPoint(markerPoint);
        }

        [HttpDelete("DeleteMarkerPoint")]
        public async Task<int> DeleteMarkerPointByID(int id)
        {
            return await markerPointServices.DeleteMarkerPointByID(id);
        }

        [HttpPut("UpdateMarkerPointByID")]
        public async Task<int> UpdateMarkerPointByID(MarkerPoint markerPoint)
        {
            return await markerPointServices.UpdateMarkerPointByID(markerPoint);
        }

    }
}
