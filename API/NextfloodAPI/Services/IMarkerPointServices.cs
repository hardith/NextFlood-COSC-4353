using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextfloodAPI.Models;

namespace NextfloodAPI.Services
{
    public interface IMarkerPointServices
    {
        Task<List<MarkerPoint>> GetAllMarkerPoints();
        Task<List<MarkerPoint>> GetMarkerPointsBySeverity(string severity);
        Task<MarkerPoint> GetMarkerPointsById(int id);
        Task<int> AddNewMarkerPoint(MarkerPoint markerPoint);
        Task<int> DeleteMarkerPointByID(int id);
        Task<int> UpdateMarkerPointByID(MarkerPoint markerPoint);
    }
}
