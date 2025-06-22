using HomeRentTracker.Models.FlatEntity;
using HomeRentTracker.Models.OwnerEntity;
using HomeRentTracker.Services.Contract;
using System.Data;
using System.Data.SqlClient;

namespace HomeRentTracker.Services.Repos
{
    public class FlatService : IFlatService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IOwnerRepository _ownerRepository;

        public FlatService(IConfiguration configuration, IOwnerRepository ownerRepository   )
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("AppConnection");
            _ownerRepository = ownerRepository;
        }
        public Task<List<OwnerInfo>> GetOwnerList()
        {
           
            return _ownerRepository.GetOwnerList();
        }
        public async Task<IEnumerable<Flat>> GetAllFlatsAsync()
        {
            List<Flat> flats = new List<Flat>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllFlats", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                await con.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    flats.Add(new Flat
                    {
                        FlatId = Convert.ToInt32(reader["FlatId"]),
                        FlatNo = reader["FlatNo"].ToString(),
                        FlatOwener = reader["FlatOwener"]?.ToString(),
                        FlatRent = Convert.ToDouble(reader["FlatRent"]),
                        RentPaidBy = reader["RentPaidBy"].ToString(),
                        RentReceive = Convert.ToBoolean(reader["RentReceive"]),
                        RentReceiverName = reader["RentReceiverName"]?.ToString(),
                        ReceiveDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["ReceiveDate"])),
                        RentMonth = DateOnly.FromDateTime(Convert.ToDateTime(reader["RentMonth"]))
                    });
                }
            }

            return flats;
        }

        public async Task<Flat> GetFlatByIdAsync(int id)
        {
            Flat flat = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetFlatById", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FlatId", id);
                await con.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    flat = new Flat
                    {
                        FlatId = Convert.ToInt32(reader["FlatId"]),
                        FlatNo = reader["FlatNo"].ToString(),
                        FlatOwener = reader["FlatOwener"]?.ToString(),
                        FlatRent = Convert.ToDouble(reader["FlatRent"]),
                        RentPaidBy = reader["RentPaidBy"].ToString(),
                        RentReceive = Convert.ToBoolean(reader["RentReceive"]),
                        RentReceiverName = reader["RentReceiverName"]?.ToString(),
                        ReceiveDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["ReceiveDate"])),
                        RentMonth = DateOnly.FromDateTime(Convert.ToDateTime(reader["RentMonth"]))
                    };
                }
            }

            return flat;
        }

        public async Task InsertFlatAsync(Flat flat)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertFlat", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FlatNo", flat.FlatNo);
                cmd.Parameters.AddWithValue("@FlatOwener", flat.FlatOwener ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FlatRent", flat.FlatRent);
                cmd.Parameters.AddWithValue("@RentPaidBy", flat.RentPaidBy);
                cmd.Parameters.AddWithValue("@RentReceive", flat.RentReceive);
                cmd.Parameters.AddWithValue("@RentReceiverName", flat.RentReceiverName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ReceiveDate", flat.ReceiveDate.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@RentMonth", flat.RentMonth.ToDateTime(TimeOnly.MinValue));
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateFlatAsync(Flat flat)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateFlat", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FlatId", flat.FlatId);
                cmd.Parameters.AddWithValue("@FlatNo", flat.FlatNo);
                cmd.Parameters.AddWithValue("@FlatOwener", flat.FlatOwener ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FlatRent", flat.FlatRent);
                cmd.Parameters.AddWithValue("@RentPaidBy", flat.RentPaidBy);
                cmd.Parameters.AddWithValue("@RentReceive", flat.RentReceive);
                cmd.Parameters.AddWithValue("@RentReceiverName", flat.RentReceiverName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ReceiveDate", flat.ReceiveDate.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@RentMonth", flat.RentMonth.ToDateTime(TimeOnly.MinValue));
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteFlatAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteFlat", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FlatId", id);
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

     
    }
}
