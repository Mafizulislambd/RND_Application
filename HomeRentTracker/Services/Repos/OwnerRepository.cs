using HomeRentTracker.Models.OwnerEntity;
using HomeRentTracker.Services.Contract;
using System.Data.SqlClient;
using System.Data;

namespace HomeRentTracker.Services.Repos
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly string _connectionString;
        public OwnerRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("AppConnection");
        }
        public async Task<List<OwnerInfo>> GetOwnerList()
        {
            List<OwnerInfo> owners = new List<OwnerInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetOwnerList", conn)
            {
                CommandType = CommandType.StoredProcedure
            };          
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                owners.Add(new OwnerInfo
                {
                    OwnerID = (int)reader.GetInt32(0),
                    OwnerName = reader.GetString(1),                   
                });
            }
            return owners;
        }
        public async Task<List<OwnerInfo>> GetOwnerListAll()
        {
            List<OwnerInfo> owners = new List<OwnerInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetOwnersWithAdvancedFilters", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                owners.Add(new OwnerInfo
                {
                    OwnerID = (int)reader.GetInt32(1),
                    OwnerName = reader.GetString(2),
                    OwnerEmail = reader.GetString(3),
                    OwnerPhone = reader.GetString(4),
                    OwnerNID = reader.GetString(5),
                    OwnerAddress = reader.GetString(6),
                    OwernerImage = reader.IsDBNull(7) ? null : reader.GetString(7),
                    CreatedDate = reader.GetDateTime(8),
                    UpdatedDate = reader.GetDateTime(9)
                });
            }
         
            return owners;
        }   
        public async Task<List<OwnerInfo>> GetAllOwnersAsync(OwnerFilterViewModel filter)
        {
            List<OwnerInfo> owners = new List<OwnerInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetOwnersWithAdvancedFilters", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@SearchText", (object)filter.SearchText ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PageNumber", filter.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", filter.PageSize);
            cmd.Parameters.AddWithValue("@SortColumn", filter.SortColumn);
            cmd.Parameters.AddWithValue("@SortDirection", filter.SortDirection);
            cmd.Parameters.AddWithValue("@CreatedDateFrom", (object)filter.CreatedDateFrom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDateTo", (object)filter.CreatedDateTo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsExport", filter.IsExport);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                owners.Add(new OwnerInfo
                {
                    OwnerID = (int)reader.GetInt32(1),
                    OwnerName = reader.GetString(2),
                    OwnerEmail = reader.GetString(3),
                    OwnerPhone = reader.GetString(4),
                    OwnerNID = reader.GetString(5),
                    OwnerAddress = reader.GetString(6),
                    OwernerImage = reader.IsDBNull(7) ? null : reader.GetString(7),
                    CreatedDate = reader.GetDateTime(8),
                    UpdatedDate = reader.GetDateTime(9)
                });
            }
            if (await reader.NextResultAsync() && await reader.ReadAsync())
            {
                filter.TotalCount =  (int)reader.GetInt32(0);
            }

            filter.Owners = owners;
            return owners;
        }

        public async Task<OwnerInfo> GetOwnerByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetOwnerById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@OwnerID", id);
            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new OwnerInfo
                {
                    OwnerID = reader.GetInt32(0),
                    OwnerName = reader.GetString(1),
                    OwnerEmail = reader.GetString(2),
                    OwnerPhone = reader.GetString(3),
                    OwnerNID = reader.GetString(4),
                    OwnerAddress = reader.GetString(5),
                    OwernerImage = reader.IsDBNull(6) ? null : reader.GetString(6),
                    CreatedDate = reader.GetDateTime(7),
                    UpdatedDate = reader.GetDateTime(8)
                };
            }
            return null;
        }

        public async Task<bool> CreateOwnerAsync(OwnerInfo owner)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("InsertOwner", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@OwnerName", owner.OwnerName);
            cmd.Parameters.AddWithValue("@OwnerEmail", owner.OwnerEmail);
            cmd.Parameters.AddWithValue("@OwnerPhone", owner.OwnerPhone);
            cmd.Parameters.AddWithValue("@OwnerNID", owner.OwnerNID);
            cmd.Parameters.AddWithValue("@OwnerAddress", owner.OwnerAddress);
            cmd.Parameters.AddWithValue("@OwernerImage", (object)owner.OwernerImage ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDate", owner.CreatedDate);
            cmd.Parameters.AddWithValue("@UpdatedDate", owner.UpdatedDate);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> UpdateOwnerAsync(OwnerInfo owner)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("UpdateOwner", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@OwnerID", owner.OwnerID);
            cmd.Parameters.AddWithValue("@OwnerName", owner.OwnerName);
            cmd.Parameters.AddWithValue("@OwnerEmail", owner.OwnerEmail);
            cmd.Parameters.AddWithValue("@OwnerPhone", owner.OwnerPhone);
            cmd.Parameters.AddWithValue("@OwnerNID", owner.OwnerNID);
            cmd.Parameters.AddWithValue("@OwnerAddress", owner.OwnerAddress);
            cmd.Parameters.AddWithValue("@OwernerImage", (object)owner.OwernerImage ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedDate", owner.UpdatedDate);
            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> DeleteOwnerAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DeleteOwner", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@OwnerID", id);
            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }
    }

}
