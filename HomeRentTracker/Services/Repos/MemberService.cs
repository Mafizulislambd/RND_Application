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

        public async Task<int> AddAsync(MemberInfo member,int renterID,string renterNID)
        {
            if (string.IsNullOrEmpty(member.RenterID) || string.IsNullOrEmpty(member.RenterNID))
            {
                member.RenterID = renterID.ToString();
                member.RenterNID = renterNID;
            }         

            var parameters = new DynamicParameters();
            parameters.Add("MemberName", member.MemberName);
            parameters.Add("MemberAge", member.MemberAge);
            parameters.Add("MemberPhone", member.MemberPhone);
            parameters.Add("MemberEmail", member.MemberEmail);
            parameters.Add("MemberNID", member.MemberNID);
            parameters.Add("MemberAddress", member.MemberAddress);
            parameters.Add("MemberProfession", member.MemberProfession);
            parameters.Add("RenterID", member.RenterID);
            parameters.Add("RenterNID", member.RenterNID);
            parameters.Add("RelationWithRenter", member.RelationWithRenter);

            // Add output parameter
            parameters.Add("MemberID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _db.ExecuteAsync("sp_AddMember", parameters, commandType: CommandType.StoredProcedure);

            int newMemberId = parameters.Get<int>("MemberID");
            return newMemberId;
            //return newMemberId;
            //member.RenterID = renterID.ToString();
            //member.RenterNID = renterNID;
            //int memberId;

            //var parameters = new
            //{
            //    member.MemberName,
            //    member.MemberAge,
            //    member.MemberPhone,
            //    member.MemberEmail,
            //    member.MemberNID,
            //    member.MemberAddress,
            //    member.MemberProfession,
            //    member.RenterID,
            //    member.RenterNID,
            //    member.RelationWithRenter,
            //    memberId
            //};

            //await _db.ExecuteAsync("sp_AddMember", parameters, commandType: CommandType.StoredProcedure);
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
                member.RenterID,
                member.RenterNID,
                member.RelationWithRenter
            };

            await _db.ExecuteAsync("sp_UpdateMember", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            await _db.ExecuteAsync("sp_DeleteMember", new { MemberId = id }, commandType: CommandType.StoredProcedure);
        }
    }

}
