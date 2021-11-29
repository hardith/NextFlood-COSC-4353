using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextfloodAPI.Models;
using NextfloodAPI.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace NextfloodAPI.Services
{
    public class MarkerPointServices:IMarkerPointServices
    {
        private readonly IConfiguration _configuration;
        public MarkerPointServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        ////hardcoded data
        //private List<MarkerPoint> markerMockData = new List<MarkerPoint>
        //{
        //    new MarkerPoint { ID = 1, UserID = "User 1", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL= "video url"},
        //    new MarkerPoint { ID = 2, UserID = "User 2", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL= "video url"},
        //    new MarkerPoint { ID = 3, UserID = "User 3", CreatedDate = DateTime.Now , ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description ="Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL= "video url"},
        //    new MarkerPoint { ID = 4, UserID = "User 4", CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description = "Mock Data", Severity = "1", ImageURL = "imageURL", VideoURL = "video url"},
        //    new MarkerPoint { ID = 5, UserID = "User 1", CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now, Latitude = "94", Longitude = "-95", Description = "Mock Data", Severity = "2", ImageURL = "imageURL", VideoURL = "video url"}
        //};

        public MarkerPointServices()
        {
        }

        async public Task<List<MarkerPoint>> GetAllMarkerPoints()
        {
            string query = @"
                        select * from markerpoints
            ";

            //DataTable table = new DataTable();
            List<MarkerPoint> markerPointsData = new List<MarkerPoint>();
            string sqlDataSource = _configuration.GetConnectionString("dbConnString");
            
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    var reader = await myCommand.ExecuteReaderAsync();
                    
                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            var obj = new MarkerPoint();
                            obj.ID = reader.GetInt32(0);
                            obj.UserID = reader.GetString(1);
                            obj.CreatedDate = reader.GetDateTime(2);
                            obj.ExpiryDate = reader.GetDateTime(3);
                            obj.Latitude = reader.GetString(4);
                            obj.Longitude = reader.GetString(5);
                            if (!reader.IsDBNull(6))
                                obj.Description = reader.GetString(6);
                            if (!reader.IsDBNull(7))
                                obj.Severity = reader.GetString(7);
                            if (!reader.IsDBNull(8))
                                obj.ImageURL = reader.GetString(8);
                            if (!reader.IsDBNull(9))
                                obj.VideoURL = reader.GetString(9);
                            markerPointsData.Add(obj);
                        }
                    }

                    mycon.Close();
                }
            }
            return markerPointsData;
        }

        async public Task<List<MarkerPoint>> GetMarkerPointsBySeverity(string severity)
        {
            string query = @"
                        select * from markerpoints where Severity = @severity
            ";

            //DataTable table = new DataTable();
            List<MarkerPoint> markerPointsData = new List<MarkerPoint>();
            string sqlDataSource = _configuration.GetConnectionString("dbConnString");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@severity", severity);
                    var reader = await myCommand.ExecuteReaderAsync();

                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            var obj = new MarkerPoint();
                            obj.ID = reader.GetInt32(0);
                            obj.UserID = reader.GetString(1);
                            obj.CreatedDate = reader.GetDateTime(2);
                            obj.ExpiryDate = reader.GetDateTime(3);
                            obj.Latitude = reader.GetString(4);
                            obj.Longitude = reader.GetString(5);
                            if (!reader.IsDBNull(6))
                                obj.Description = reader.GetString(6);
                            if (!reader.IsDBNull(7))
                                obj.Severity = reader.GetString(7);
                            if (!reader.IsDBNull(8))
                                obj.ImageURL = reader.GetString(8);
                            if (!reader.IsDBNull(9))
                                obj.VideoURL = reader.GetString(9);
                            markerPointsData.Add(obj);
                            markerPointsData.Add(obj);
                        }
                    }

                    mycon.Close();
                }
            }
            return markerPointsData;
        }

        async public Task<List<MarkerPoint>> GetMarkerPointsById(int id)
        {
            string query = @"
                        select * from markerpoints where ID = @id
            ";

            //DataTable table = new DataTable();
            List<MarkerPoint> markerPointsData = new List<MarkerPoint>();
            string sqlDataSource = _configuration.GetConnectionString("dbConnString");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    var reader = await myCommand.ExecuteReaderAsync();

                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            var obj = new MarkerPoint();
                            obj.ID = reader.GetInt32(0);
                            obj.UserID = reader.GetString(1);
                            obj.CreatedDate = reader.GetDateTime(2);
                            obj.ExpiryDate = reader.GetDateTime(3);
                            obj.Latitude = reader.GetString(4);
                            obj.Longitude = reader.GetString(5);
                            if (!reader.IsDBNull(6))
                                obj.Description = reader.GetString(6);
                            if (!reader.IsDBNull(7))
                                obj.Severity = reader.GetString(7);
                            if (!reader.IsDBNull(8))
                                obj.ImageURL = reader.GetString(8);
                            if (!reader.IsDBNull(9))
                                obj.VideoURL = reader.GetString(9);
                            markerPointsData.Add(obj);
                        }
                    }

                    mycon.Close();
                }
            }
            return markerPointsData;
        }

        async public Task<int> AddNewMarkerPoint(MarkerPoint markerPoint)
        {
            string query = @"
                        INSERT INTO `nextflooddb`.`markerpoints` (`UserID`, `DateAdded`, `ExpiresAfter`, `Latitude`, `Longitude`,`Description`,`Severity`, `ImageURL`, `VideoURL`) 
                        VALUES (@userId, @dateAdded, @expiresAfter, @latitude, @longitude,@description, @severity, @imageURL, @videoURL);
            ";

            int result;
            //DataTable table = new DataTable();
            //List<MarkerPoint> markerPointsData = new List<MarkerPoint>();
            string sqlDataSource = _configuration.GetConnectionString("dbConnString");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@userId", markerPoint.UserID);
                    myCommand.Parameters.AddWithValue("@dateAdded", markerPoint.CreatedDate);
                    myCommand.Parameters.AddWithValue("@expiresAfter", markerPoint.ExpiryDate);
                    myCommand.Parameters.AddWithValue("@latitude", markerPoint.Latitude);
                    myCommand.Parameters.AddWithValue("@longitude", markerPoint.Longitude);
                    myCommand.Parameters.AddWithValue("@description", markerPoint.Description);
                    myCommand.Parameters.AddWithValue("@severity", markerPoint.Severity);
                    myCommand.Parameters.AddWithValue("@imageURL", markerPoint.ImageURL);
                    myCommand.Parameters.AddWithValue("@videoURL", markerPoint.VideoURL);
                    result = (int) await myCommand.ExecuteNonQueryAsync();

                    mycon.Close();
                }
            }
            return result;
        }

        async public Task<int> UpdateMarkerPointByID(MarkerPoint markerPoint)
        {
            string query = @"
                        UPDATE markerpoints SET ExpiresAfter = @expiresAfter, Latitude = @latitude, Longitude = @longitude, Description = @description,Severity = @severity, ImageURL = @imageURL, VideoURL = @videoURL 
                        WHERE ID = @id
            ";

            int result;
            //DataTable table = new DataTable();
            //List<MarkerPoint> markerPointsData = new List<MarkerPoint>();
            string sqlDataSource = _configuration.GetConnectionString("dbConnString");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", markerPoint.ID);
                    myCommand.Parameters.AddWithValue("@expiresAfter", markerPoint.ExpiryDate);
                    myCommand.Parameters.AddWithValue("@latitude", markerPoint.Latitude);
                    myCommand.Parameters.AddWithValue("@longitude", markerPoint.Longitude);
                    myCommand.Parameters.AddWithValue("@description", markerPoint.Description);
                    myCommand.Parameters.AddWithValue("@severity", markerPoint.Severity);
                    myCommand.Parameters.AddWithValue("@imageURL", markerPoint.ImageURL);
                    myCommand.Parameters.AddWithValue("@videoURL", markerPoint.VideoURL);
                    result = (int)await myCommand.ExecuteNonQueryAsync();

                    mycon.Close();
                }
            }
            return result;
        }

        async public Task<int> DeleteMarkerPointByID(int id)
        {
            string query = @"
                        DELETE FROM markerpoints where ID = @id
            ";
            
            int result;
            //DataTable table = new DataTable();
            //List<MarkerPoint> markerPointsData = new List<MarkerPoint>();
            string sqlDataSource = _configuration.GetConnectionString("dbConnString");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    result = (int)await myCommand.ExecuteNonQueryAsync();

                    mycon.Close();
                }
            }
            return result;
        }
    }
}
