using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AppDataIntigrity.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _config;

        public AccountService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> CreateAccountAsync(int customerId, decimal initialBalance)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            parameters.Add("@InitialBalance", initialBalance);

            try
            {
                await connection.ExecuteAsync("CreateAccount", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (SqlException ex)
            {
                // Log error if needed
                return false;
            }
        }
    }

}
