//using Dapper;
using HomeRentTracker.Models;
using HomeRentTracker.Models.LoginEntity;
using Microsoft.Extensions.Configuration;


//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;
using System.Data.SqlClient;

namespace HomeRentTracker.Services
{
    public class UserRepository : IUserRepository
    {
        //private readonly DapperContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("AppConnection");
         //   _context = context;
        }
        //public async Task<UserLoginResult> CheckLoginAsync(string email, string password)
        //{
        //    using var connection = _context.CreateConnection();

        //    var hashed = HashHelper.HashPassword(password);
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@userEmail", email);
        //    parameters.Add("@UserPassword", hashed);

        //    try
        //    {
        //        var user = await connection.QueryFirstOrDefaultAsync<UserLoginResult>(
        //            "sp_CheckUserLogin", parameters, commandType: CommandType.StoredProcedure);

        //        return user != null ? user : new UserLoginResult { IsSuccess = false, ErrorMessage = "Invalid credentials" };
        //    }
        //    catch (SqlException ex)
        //    {
        //        return new UserLoginResult { IsSuccess = false, ErrorMessage = ex.Message };
        //    }
        //}

        public Task<UserLoginResult> CheckLoginAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<UserRegistration> UserLogin(string userId, string password)
        {
            UserRegistration userRegistration=null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_userLogin", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@UserPassword", password);
                await con.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    userRegistration = new UserRegistration
                    {
                        UserId = reader["userId"].ToString(),
                        UserEmail = reader["userName"].ToString(),
                        UserName = reader["userEmail"]?.ToString(),
                        UserType = Convert.ToInt16(reader["userType"]),
                   
                    };
                    if (!string.IsNullOrEmpty(  userRegistration.UserName))
                    {
                        userRegistration.IsSuccess = true;
                    }
                    else
                    {
                        userRegistration.IsSuccess = false;
                        userRegistration.ErrorMessage = "Invalid credentials";
                    }
                }
                 con.Close();
                return userRegistration;
                
            }


        }

    }
}
