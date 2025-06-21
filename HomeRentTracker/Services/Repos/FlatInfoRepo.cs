using System.Data.SqlClient;
using System.Data;
using System.Net;
using HomeRentTracker.Models.FlatInfo;
using HomeRentTracker.Services.Contract;

namespace HomeRentTracker.Services.Repos
{
    public class FlatInfoRepo : IFlatInfo
    {
        private readonly string _connectionString;
        public FlatInfoRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppConnection");
        }

        public async Task<List<FlatInformation>> GetAllAsync()
        {
            var list = new List<FlatInformation>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetAllFlatInformation", conn) { CommandType = CommandType.StoredProcedure };
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new FlatInformation
                {
                    Id = (int)reader["Id"],
                    RoadNo = reader["RoadNo"].ToString(),
                    BlockNo = reader["BlockNo"]?.ToString(),
                    BuildingNo = reader["BuildingNo"]?.ToString(),
                    FlatNo = reader["FlatNo"].ToString(),
                    PlaceName = reader["PlaceName"].ToString(),
                    PostOfficeId = reader["PostOffice"].ToString(),
                    SubDistrictId = reader["SubDistrict"].ToString(),
                    DistrictId = reader["District"]?.ToString(),
                    DivisionId = reader["Division"]?.ToString(),
                    CountryId = reader["Country"]?.ToString()
                });
            }

            return list;
        }

        public async Task<FlatInformation?> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetFlatInformationById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", id);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new FlatInformation
                {
                    Id = (int)reader["Id"],
                    RoadNo = reader["RoadNo"].ToString(),
                    BlockNo = reader["BlockNo"]?.ToString(),
                    BuildingNo = reader["BuildingNo"]?.ToString(),
                    FlatNo = reader["FlatNo"].ToString(),
                    PlaceName = reader["PlaceName"].ToString(),
                    PostOfficeId = reader["PostOffice"].ToString(),
                    SubDistrictId = reader["SubDistrict"].ToString(),
                    DistrictId = reader["District"]?.ToString(),
                    DivisionId = reader["Division"]?.ToString(),
                    CountryId = reader["Country"]?.ToString()
                };
            }

            return null;
        }

        public async Task AddAsync(FlatInformation model)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("InsertFlatInformation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@RoadNo", model.RoadNo);
            cmd.Parameters.AddWithValue("@BlockNo", model.BlockNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BuildingNo", model.BuildingNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@FlatNo", model.FlatNo);
            cmd.Parameters.AddWithValue("@PlaceName", model.PlaceName);
            cmd.Parameters.AddWithValue("@PostOffice", model.PostOfficeId);
            cmd.Parameters.AddWithValue("@SubDistrict", model.SubDistrictId);
            cmd.Parameters.AddWithValue("@District", model.DistrictId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Division", model.DivisionId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", model.CountryId ?? (object)DBNull.Value);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(FlatInformation model)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("UpdateFlatInformation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@RoadNo", model.RoadNo);
            cmd.Parameters.AddWithValue("@BlockNo", model.BlockNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BuildingNo", model.BuildingNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@FlatNo", model.FlatNo);
            cmd.Parameters.AddWithValue("@PlaceName", model.PlaceName);
            cmd.Parameters.AddWithValue("@PostOffice", model.PostOfficeId);
            cmd.Parameters.AddWithValue("@SubDistrict", model.SubDistrictId);
            cmd.Parameters.AddWithValue("@District", model.DistrictId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Division", model.DivisionId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", model.CountryId ?? (object)DBNull.Value);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DeleteFlatInformation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", id);
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
