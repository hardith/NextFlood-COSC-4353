using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextfloodAPI.Services;
using NextfloodAPI.Models;

namespace NextFloodDALTest
{
    public class NextFloodMock
    {

        private List<MarkerPoint> markerMockData = new List<MarkerPoint>
        {
            new MarkerPoint { ID = 1, UserID = "User1", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL= "video url"},
            new MarkerPoint { ID = 2, UserID = "User2", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "4", ImageURL = "imageURL", VideoURL= "video url"},
            new MarkerPoint { ID = 3, UserID = "User3", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "3", ImageURL = "imageURL", VideoURL= "video url"},
            new MarkerPoint { ID = 4, UserID = "User4", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description = "Mock Data", Severity = "2", ImageURL = "imageURL", VideoURL = "video url"},
            new MarkerPoint { ID = 5, UserID = "User1", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description = "Mock Data", Severity = "2", ImageURL = "imageURL", VideoURL = "video url"}
        };

        //private IMarkerPointServices markerPointServices = new IMarkerPointServices();

        public NextFloodMock()
        {
            
        }

        public Task<List<MarkerPoint>> GetAllMarkerPoints()
        {
            return Task.Run(() => markerMockData);
        }

        public Task<List<MarkerPoint>> GetMarkerPointsBySeverity(string severity)
        {
            return Task.Run(() => markerMockData.Where(x => x.Severity == severity).ToList());
        }

        public Task<MarkerPoint> GetMarkerPointsById(int id)
        {
            return Task.Run(() => markerMockData.Where(x => x.ID == id).FirstOrDefault());
        }

        public Task<int> AddMarkerPoint(MarkerPoint markerPoint)
        {
            int initialCount = markerMockData.Count();
            markerMockData.Add(markerPoint);
            int count = markerMockData.Count();
            return Task.Run(() => count - initialCount);
        }

        public Task<int> DeleteMarkerPointByID(int id)
        {
            int initialCount = markerMockData.Count();
            markerMockData.Remove(markerMockData.Where(x => x.ID == id).FirstOrDefault());
            int count = markerMockData.Count();
            return Task.Run(() => initialCount - count);
        }

        public Task<int> UpdateMarkerPointByID(MarkerPoint markerPoint)
        {
            var obj = markerMockData.Where(x => x.ID == markerPoint.ID).FirstOrDefault();
            int result = -1;

            if (obj != null)
            {
                obj.Description = markerPoint.Description;
                obj.ExpiryDate = markerPoint.ExpiryDate;
                obj.Latitude = markerPoint.Latitude;
                obj.Longitude = markerPoint.Longitude;
                obj.Severity = markerPoint.Severity;
                obj.ImageURL = markerPoint.ImageURL;
                obj.VideoURL = markerPoint.VideoURL;

                result = 1;
            }

            return Task.Run(() => result);
        }

    }
}