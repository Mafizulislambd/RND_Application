using HomeRentTracker.Services.Contract;
using System.Data.SqlClient;
using System.Data;
using HomeRentTracker.Models.RenterEntity;
using Dapper;

namespace HomeRentTracker.Services.Repos
{
    public class MemberService : IMemberService
    {
        private readonly IDbConnection _db;

        public MemberService(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("AppConnection"));
        }

        public async Task<IEnumerable<MemberInfo>> GetAllAsync()
        {
            return await _db.QueryAsync<MemberInfo>("sp_GetAllMembers", commandType: CommandType.StoredProcedure);
        }

        public async Task<MemberInfo?> GetByIdAsync(int id)
        {
            var parameters = new { MemberId = id };
            return await _db.QueryFirstOrDefaultAsync<MemberInfo>("sp_GetMemberById", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task AddAsync(MemberInfo member)
        {
            var parameters = new
            {
                member.MemberName,
                member.MemberAge,
                member.MemberPhone,
                member.MemberEmail,
                member.MemberNID,
                member.MemberAddress,
                member.MemberProfession,
                member.GuardianID,
                member.GuardialNID,
                member.RelationWithGuardian
            };

            await _db.ExecuteAsync("sp_AddMember", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync(MemberInfo member)
        {
            var parameters = new
            {
                member.MemberId,
                member.MemberName,
                member.MemberAge,
                member.MemberPhone,
                member.MemberEmail,
                member.MemberNID,
                member.MemberAddress,
                member.MemberProfession,
                member.GuardianID,
                member.GuardialNID,
                member.RelationWithGuardian
            };

            await _db.ExecuteAsync("sp_UpdateMember", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            await _db.ExecuteAsync("sp_DeleteMember", new { MemberId = id }, commandType: CommandType.StoredProcedure);
        }
    }

}
