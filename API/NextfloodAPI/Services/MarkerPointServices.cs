using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextfloodAPI.Models;
using NextfloodAPI.Services;

namespace NextfloodAPI.Services
{
    public class MarkerPointServices:IMarkerPointServices
    {
        //hardcoded data
        private List<MarkerPoint> markerMockData = new List<MarkerPoint>
        {
            new MarkerPoint { ID = 1, UserID = "User 1", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL= "video url"},
            new MarkerPoint { ID = 2, UserID = "User 2", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL= "video url"},
            new MarkerPoint { ID = 3, UserID = "User 3", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL= "video url"},
            new MarkerPoint { ID = 4, UserID = "User 4", CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description = "Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL = "video url"},
            new MarkerPoint { ID = 5, UserID = "User 1", CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description = "Mock Data", Severity = "2", ImageURL = "imageURL", VideoURL = "video url"}
        };

        public MarkerPointServices()
        {
        }

        async public Task<List<MarkerPoint>> GetAllMarkerPoints()
        {
            return markerMockData;
        }

        async public Task<List<MarkerPoint>> GetMarkerPointsBySeverity(string severity)
        {
            return markerMockData.Where(m => m.Severity == severity).ToList();
        }

        async public Task<List<MarkerPoint>> GetMarkerPointsById(int id)
        {
            return markerMockData.Where(m => m.ID == id).ToList();
        }

        async public void AddNewMarkerPoint(MarkerPoint markerPoint)
        {
            Console.WriteLine(markerPoint.UserID);
        }
    }
}
