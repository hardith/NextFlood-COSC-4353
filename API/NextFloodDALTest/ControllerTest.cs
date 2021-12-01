using Moq;
using NextfloodAPI.Models;
using NextfloodAPI.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NextFloodDALTest
{
    public class ControllerTest
    {
        private readonly NextFloodMock _service = new NextFloodMock();
       
     
        [Fact]
        public async void AddMarkerPoint()
        {
            var markerPointID = (int)new Random().Next();

            int expectedResult = 1;

            var markerPointData = new MarkerPoint()
            {
                ID = 6,
                UserID = "User1",
                CreatedDate = DateTime.Now,
                ExpiryDate = DateTime.Now,
                Latitude = "94",
                Longitude = "-95",
                Description = "Mock Data",
                Severity = "1",
                ImageURL = "imageURL",
                VideoURL = "video url"
            };

            int actulaResult = (int) await _service.AddMarkerPoint(markerPointData);

            Assert.Equal(expectedResult, actulaResult);
        }

        [Fact]
        public async void UpdateMarkerPointByID_ShouldUpdateTheMarkerPoint()
        {
            var markerPointID = (int)new Random().Next();

            int expectedResult = 1;

            var markerPointData = new MarkerPoint()
            {
                ID = 2,
                UserID = "User1",
                CreatedDate = DateTime.Now,
                ExpiryDate = DateTime.Now,
                Latitude = "94",
                Longitude = "-95",
                Description = "Mock Data",
                Severity = "1",
                ImageURL = "imageURL",
                VideoURL = "video url"
            };

            int actulaResult = (int)await _service.UpdateMarkerPointByID(markerPointData);

            Assert.Equal(expectedResult, actulaResult);
        }

        [Fact]
        public async void GetAllMarkerPoints_ShouldReturnMarkerPoints()
        {
            Assert.NotEmpty(await _service.GetAllMarkerPoints());
        }

        [Fact]
        public async void GetMarkerPointsBySeverity_ShouldReturnMarkerPoints()
        {
            string severity = "2";
            Assert.NotEmpty(await _service.GetMarkerPointsBySeverity(severity));
        }

        [Fact]
        public async void GetMarkerPointsById_shouldReturnMarkerPoint()
        {
            int id = 4;
            var i = await _service.GetMarkerPointsById(id);
            Assert.NotNull(i);
        }

        [Fact]
        public async void DeleteMarkerPointByID_shouldDeleteMarkerPoint()
        {
            int id = 4;
            int expectedResult = 1;
            var i = await _service.DeleteMarkerPointByID(id);
            Assert.Equal((int) expectedResult, i);
        }

        
    }
}
