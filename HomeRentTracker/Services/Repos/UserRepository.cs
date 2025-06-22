//using Dapper;
using HomeRentTracker.Models;
using HomeRentTracker.Models.LoginEntity;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Mvc;

//using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace HomeRentTracker.Services.Repos
{
    public class UserRepository : IUserServices
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

        [HttpPost]
      
        public int RegisterUser(string username, string userFirstName, string userMName, string userLName, string userFullName, string userEmail, String userPhone, string password)
        {
            string hashedPassword = PasswordHelper.HashPassword(password);
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_RegisterUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@UserFirstName", userFirstName);
            cmd.Parameters.AddWithValue("@UserMiddleName", userMName);
            cmd.Parameters.AddWithValue("@UserLastName", userLName);
            cmd.Parameters.AddWithValue("@UserFullName", userFullName);
            cmd.Parameters.AddWithValue("@UserEmail", userEmail);
            cmd.Parameters.AddWithValue("@UserPhone", userPhone);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

            conn.Open();
            return (int)cmd.ExecuteNonQuery();
        }
        //public Task<FlatRentTracker.Models.UserLoginResult> CheckLoginAsync(FlatRentTracker.Models.UserLoginRequest request)
        //{
        //    throw new NotImplementedException();
        //}

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

        //public Task<UserLoginResult> CheckLoginAsync(UserLoginRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<FlatRentTracker.Models.UserLoginResult> CheckLoginAsync(FlatRentTracker.Models.UserLoginRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<UserRegistration> UserLogin(string userId, string password)
        //{
        //    UserRegistration userRegistration=null;
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_userLogin", con)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.AddWithValue("@userId", userId);
        //        cmd.Parameters.AddWithValue("@UserPassword", password);
        //        await con.OpenAsync();
        //        SqlDataReader reader = await cmd.ExecuteReaderAsync();
        //        if (await reader.ReadAsync())
        //        {
        //            userRegistration = new UserRegistration
        //            {
        //                UserId = reader["userId"].ToString(),
        //                UserEmail = reader["userName"].ToString(),
        //                UserName = reader["userEmail"]?.ToString(),
        //                UserType = Convert.ToInt16(reader["userType"]),

        //            };
        //            if (!string.IsNullOrEmpty(  userRegistration.UserName))
        //            {
        //                userRegistration.IsSuccess = true;
        //            }
        //            else
        //            {
        //                userRegistration.IsSuccess = false;
        //                userRegistration.ErrorMessage = "Invalid credentials";
        //            }
        //        }
        //         con.Close();
        //        return userRegistration;

        //    }


        //}

        public UserInfo ValidateUser(string username, string password)
        {
            UserInfo user = null;
            using var conn = new SqlConnection(_connectionString);
            //using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("sp_LoginUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Username", username);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string storedHash = reader["UserPassword"].ToString();
                string inputHash = PasswordHelper.HashPassword(password);

                if (storedHash == inputHash)
                {
                    user = new UserInfo
                    {
                        UserId = (reader["UserId"]).ToString(),
                        UserName = (reader["UserName"]).ToString(),
                        UserFirstName = reader["UserFirstName"].ToString(),
                        UserMiddleName = reader["UserMiddleName"].ToString(),
                        UserLastName = reader["UserLastName"].ToString(),
                        FullName = reader["UserFullName"].ToString(),
                        UserPhone = reader["userPhone"].ToString(),
                        UserEmail = reader["userEmail"].ToString(),
                        UserType = Convert.ToInt32(reader["userType"].ToString()),
                        IsUserActive = Convert.ToInt32(reader["userActive"].ToString()),
                        UserPassword = reader["UserPassword"].ToString()

                    };
                }
            }

            return user;
        }

    }
}
