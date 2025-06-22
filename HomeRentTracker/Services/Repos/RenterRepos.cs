using HomeRentTracker.Models.RenterEntity;
using HomeRentTracker.Services.Contract;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace HomeRentTracker.Services.Repos
{
    public class RenterRepos : IRenterService
    {
        private readonly IDbConnection _db;
        private readonly IMemberService _memberService;

        public RenterRepos(IConfiguration config, IMemberService memberService  )
        {
            _db = new SqlConnection(config.GetConnectionString("AppConnection"));
            _memberService = memberService;
        }

        public async Task<IEnumerable<RenterInfo>> GetAllAsync()
        {
            return await _db.QueryAsync<RenterInfo>("sp_GetAllRenters", commandType: CommandType.StoredProcedure);
        }

        public async Task<RenterInfo?> GetByIdAsync(int id)
        {
            return await _db.QueryFirstOrDefaultAsync<RenterInfo>(
                "sp_GetRenterById", new { RenterID = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task AddAsync(RenterInfo renter)
        {
            await _db.ExecuteAsync("sp_AddRenter", new
            {
                renter.GuradianName,
                renter.GuradianPhone,
                renter.GuradianEmail,
                renter.GuardialNID,
                renter.GuardialProfession,
                renter.GuradianAddress,
                renter.RenterName,
                renter.RenterPhone,
                renter.RenterEmail,
                renter.RenterNID,
                renter.RenterAddress,
                renter.TotalMember
            }, commandType: CommandType.StoredProcedure);
            if (renter.MemberInfo.Count() > 0) 
            {
                foreach (var member in renter.MemberInfo)
                {
                    _memberService.AddAsync(member);
                }
            }
        }

        public async Task UpdateAsync(RenterInfo renter)
        {
            await _db.ExecuteAsync("sp_UpdateRenter", new
            {
                renter.RenterID,
                renter.GuradianName,
                renter.GuradianPhone,
                renter.GuradianEmail,
                renter.GuardialNID,
                renter.GuardialProfession,
                renter.GuradianAddress,
                renter.RenterName,
                renter.RenterPhone,
                renter.RenterEmail,
                renter.RenterNID,
                renter.RenterAddress,
                renter.TotalMember
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            await _db.ExecuteAsync("sp_DeleteRenter", new { RenterID = id }, commandType: CommandType.StoredProcedure);
        }
    }

}
