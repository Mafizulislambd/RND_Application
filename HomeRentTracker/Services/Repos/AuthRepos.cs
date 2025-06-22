using Dapper;
using HomeRentTracker.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Data.SqlClient;

namespace HomeRentTracker.Services.Repos
{
    public class AuthRepos : IUserStore<UserInfo>, IUserPasswordStore<UserInfo>
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;


        public AuthRepos(IConfiguration configuration, IConfiguration config)
        {
            _connectionString = configuration.GetConnectionString("AppConnection");
            _config = config;
        }
        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("AppConnection"));
        public async Task<UserInfo?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("[sp_GetUserInofByUsername]", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserName", normalizedUserName);
            await conn.OpenAsync(cancellationToken);
            var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (await reader.ReadAsync())
            {
                return new UserInfo
                {
                    Id = reader["UserId"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    NormalizedUserName = reader["UserName"].ToString(),
                    PasswordHash = reader["UserPassword"].ToString(),
                    UserFirstName = reader["UserFirstName"].ToString(),
                    UserMiddleName = reader["UserMiddleName"].ToString(),
                    UserLastName = reader["UserLastName"].ToString(),
                    FullName = reader["UserFullName"].ToString(),
                    Email = reader["userEmail"].ToString(),
                    PhoneNumber = reader["UserPhone"].ToString(),
                };
            }

            return null;
        }
        //Same as above but with a different method name with dapper
        public async Task<IdentityUser> FindByNameAsyncByDepper(string normalizedUserName, CancellationToken cancellationToken)
        {
            using var conn = Connection;
            return await conn.QuerySingleOrDefaultAsync<UserInfo>(
                "sp_GetUserByUsername",
                new { UserName = normalizedUserName },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<IdentityResult> CreateAsync(UserInfo user, CancellationToken cancellationToken)
        {
            //using var conn = Connection;
            //await conn.ExecuteAsync("sp_CreateUser", new
            //{
            //    user.Id,
            //    user.UserName,
            //    user.PasswordHash,
            //    user.Email,


            //}, commandType: CommandType.StoredProcedure);

            RegisterUser(user.UserName, user.UserFirstName, user.UserMiddleName, user.UserLastName, user.FullName, user.Email, user.PhoneNumber, user.PasswordHash);
            return IdentityResult.Success;
        }
        //same as above but with a different method name
        //public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken) => Task.FromResult(IdentityResult.Success);


        public Task<string> GetPasswordHashAsync(UserInfo user, CancellationToken cancellationToken) =>
        Task.FromResult(user.PasswordHash);

        public Task<bool> HasPasswordAsync(UserInfo user, CancellationToken cancellationToken) =>
            Task.FromResult(user.PasswordHash != null);
        // Implement other required members, e.g.:
        public Task<IdentityResult> DeleteAsync(UserInfo user, CancellationToken cancellationToken) => Task.FromResult(IdentityResult.Success);
        public Task<IdentityResult> UpdateAsync(UserInfo user, CancellationToken cancellationToken) => Task.FromResult(IdentityResult.Success);
        public Task<string> GetUserIdAsync(UserInfo user, CancellationToken cancellationToken) => Task.FromResult(user.Id);
        public Task<string> GetUserNameAsync(UserInfo user, CancellationToken cancellationToken) => Task.FromResult(user.UserName);
        public Task SetUserNameAsync(UserInfo user, string userName, CancellationToken cancellationToken) { user.UserName = userName; return Task.CompletedTask; }
        public Task SetNormalizedUserNameAsync(UserInfo user, string normalizedName, CancellationToken cancellationToken) { user.NormalizedUserName = normalizedName; return Task.CompletedTask; }
        public Task<string> GetNormalizedUserNameAsync(UserInfo user, CancellationToken cancellationToken) => Task.FromResult(user.NormalizedUserName);
        public void Dispose() { }

        public async Task<UserInfo?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            UserInfo user =await FindByNameAsync(userId, cancellationToken);
            return user;
        }

        public Task SetPasswordHashAsync(UserInfo user, string? passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }
        public int RegisterUser(string username, string userFirstName, string userMName, string userLName, string userFullName, string userEmail, String userPhone, string password)
        {
            //string hashedPassword = PasswordHelper.HashPassword(password);
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
            cmd.Parameters.AddWithValue("@PasswordHash", password);

            conn.Open();
            return (int)cmd.ExecuteNonQuery();
        }

    }
}
