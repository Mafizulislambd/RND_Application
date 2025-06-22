using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using HomeRentTracker.Models;

namespace HomeRentTracker.Services.Repos
{
    public class LocationService : ILocationService
    {
        private readonly IConfiguration _config;

        public LocationService(IConfiguration config)
        {
            _config = config;
        }
       
        private IDbConnection CreateConnection() =>
            new SqlConnection(_config.GetConnectionString("AppConnection")); 
        public async Task<List<SelectListItem>> GetCountriesAsync()
        {
            using var conn = CreateConnection();
            //var result = await conn.QueryAsync<SelectListItem>(
            //    "GetAllCountries",
            //    commandType: CommandType.StoredProcedure
            //);
            //return result.ToList();using var conn = CreateConnection();

            var data = await conn.QueryAsync<DropdownItem>(
                "GetAllCountries",
                commandType: CommandType.StoredProcedure
            );

            // Convert manually to SelectListItem
            return data.Select(d => new SelectListItem
            {
                Value = d.Value,
                Text = d.Text
            }).ToList();

        }

        public async Task<List<SelectListItem>> GetDivisionsByCountryIdAsync(int countryId)
        {
            using var conn = CreateConnection();
            var result = await conn.QueryAsync<SelectListItem>(
                "GetDivisionsByCountryId",
                new { CountryId = countryId },
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

        public async Task<List<SelectListItem>> GetDistrictsByDivisionIdAsync(int divisionId)
        {
            using var conn = CreateConnection();
            var result = await conn.QueryAsync<SelectListItem>(
                "GetDistrictsByDivisionId",
                new { DivisionId = divisionId },
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

        public async Task<List<SelectListItem>> GetSubDistrictsByDistrictIdAsync(int districtId)
        {
            using var conn = CreateConnection();
            var result = await conn.QueryAsync<SelectListItem>(
                "GetSubDistrictsByDistrictId",
                new { DistrictId = districtId },
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

        public async Task<List<SelectListItem>> GetPostOfficesBySubDistrictIdAsync(int subDistrictId)
        {
            using var conn = CreateConnection();
            var result = await conn.QueryAsync<SelectListItem>(
                "GetPostOfficesBySubDistrictId",
                new { SubDistrictId = subDistrictId },
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

     
    }

}
