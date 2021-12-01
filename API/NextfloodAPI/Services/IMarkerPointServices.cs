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
        Task<List<MarkerPoint>> GetMarkerPointsById(int id);
        void AddNewMarkerPoint(MarkerPoint markerPoint);
    }
}
