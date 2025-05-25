using Dapper;
using FlatRentTracker.Services;
using FlatRentTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;
using System.Data.SqlClient;

namespace FlatRentTracker.Services
{
    public class UserRepository : IUserServices
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<UserLoginResult> CheckLoginAsync(string email, string password)
        {
            using var connection = _context.CreateConnection();

           // var hashed = HashHelper.HashPassword(password);
            var parameters = new DynamicParameters();
            parameters.Add("@userEmail", email);
            //parameters.Add("@UserPassword", hashed);

            try
            {
                var user = await connection.QueryFirstOrDefaultAsync<UserLoginResult>(
                    "sp_CheckUserLogin", parameters, commandType: CommandType.StoredProcedure);

                return user != null ? user : new UserLoginResult { IsSuccess = false, ErrorMessage = "Invalid credentials" };
            }
            catch (SqlException ex)
            {
                return new UserLoginResult { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        public Task<UserLoginResult> CheckLoginAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
