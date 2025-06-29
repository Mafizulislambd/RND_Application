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

        public RenterRepos(IConfiguration config, IMemberService memberService, IDbConnection db)
        {
            //_db = new SqlConnection(config.GetConnectionString("AppConnection"));
            _db = db;
            _memberService = memberService;
        }

        public async Task<IEnumerable<RenterInfo>> GetAllAsync()
        {
            return await _db.QueryAsync<RenterInfo>("spGetAllRenters", commandType: CommandType.StoredProcedure);

            //  return await _db.QueryAsync<RenterInfo>("sp_GetAllRenters", commandType: CommandType.StoredProcedure);
        }

        public async Task<RenterInfo?> GetByIdAsync(int id)
        {
            return await _db.QueryFirstOrDefaultAsync<RenterInfo>(
            "spGetRenterById",
            new { RenterID = id },
            commandType: CommandType.StoredProcedure);

            //return await _db.QueryFirstOrDefaultAsync<RenterInfo>(
            //    "sp_GetRenterById", new { RenterID = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(RenterInfo renter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RenterName", renter.RenterName);
            parameters.Add("RenterImage", renter.RenterImage);
            parameters.Add("RenterFatherName", renter.RenterFatherName);
            parameters.Add("RenterMotherName", renter.RenterMotherName);
            parameters.Add("RenterDOB", renter.RenterDOB);
            parameters.Add("RenterMaritialStatus", renter.RenterMaritialStatus);
            parameters.Add("RenterAddress", renter.RenterAddress);
            parameters.Add("RenterProfession", renter.RenterProfession);
            parameters.Add("OfficeAddress", renter.OfficeAddress);
            parameters.Add("Religion", renter.Religion);
            parameters.Add("EducationalBackground", renter.EducationalBackground);
            parameters.Add("RenterPhone", renter.RenterPhone);
            parameters.Add("RenterEmail", renter.RenterEmail);
            parameters.Add("RenterNID", renter.RenterNID);
            parameters.Add("PassportNo", renter.PassportNo);
            parameters.Add("EmergencyContactName", renter.EmergencyContact?.contractName);
            parameters.Add("EmergencyContactRelation", renter.EmergencyContact?.Relation.ToString());
            parameters.Add("EmergencyContactAddress", renter.EmergencyContact?.Address);
            parameters.Add("EmergencyContactPhone", renter.EmergencyContact?.contractPhone);
            parameters.Add("MemberName", renter.MemberName);
            parameters.Add("MemberNID", renter.MemberNID);
            parameters.Add("MemberPhone", renter.MemberPhone);
            parameters.Add("MemberAddress", renter.MemberAddress);
            parameters.Add("MemberEmail", renter.MemberEmail);
            parameters.Add("DriverName", renter.DriverName);
            parameters.Add("DriverNID", renter.DriverNID);
            parameters.Add("DriverPhone", renter.DriverPhone);
            parameters.Add("DriverAddress", renter.DriverAddress);
            parameters.Add("TotalMember", renter.MemberInfoList.Count());
            parameters.Add("RenterID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _db.Execute("spInsertRenterInfo", parameters, commandType: CommandType.StoredProcedure);
            int newRenterId = parameters.Get<int>("RenterID");

            //await _db.ExecuteAsync("sp_AddRenter", new
            //{
            //    renter.RenterName,
            //    renter.RenterPhone,
            //    renter.RenterEmail,
            //    renter.RenterNID,
            //    renter.RenterProfession,
            //    renter.RenterAddress,
            //    renter.MemberName,
            //    renter.MemberPhone,
            //    renter.MemberEmail,
            //    renter.MemberNID,
            //    renter.MemberAddress,
            //    renter.TotalMember
            //}, commandType: CommandType.StoredProcedure);
            if (renter.MemberInfoList.Count() > 0)
            {
                //for (int i=0; i <= renter.MemberInfoList.Count(); i++)
               // {
                    foreach (var member in renter.MemberInfoList)
                    {
                      int memberId= await  _memberService.AddAsync(member, newRenterId, renter.RenterNID);
                    }
               // }
            }
            return newRenterId;
        }

        public async Task UpdateAsync(RenterInfo renter)
        {
            //await _db.ExecuteAsync("sp_UpdateRenter", new
            //{
            //    renter.RenterID,
            //    renter.RenterName,
            //    renter.RenterPhone,
            //    renter.RenterEmail,
            //    renter.RenterNID,
            //    renter.RenterProfession,
            //    renter.RenterAddress,
            //    renter.MemberName,
            //    renter.MemberPhone,
            //    renter.MemberEmail,
            //    renter.MemberNID,
            //    renter.MemberAddress,
            //    renter.TotalMember
            //}, commandType: CommandType.StoredProcedure);
            var parameters = new DynamicParameters();
            parameters.Add("RenterID", renter.RenterID);
            parameters.Add("RenterImage", renter.RenterImage);
            parameters.Add("RenterFatherName", renter.RenterFatherName);
            parameters.Add("RenterMotherName", renter.RenterMotherName);
            parameters.Add("RenterDOB", renter.RenterDOB);
            parameters.Add("RenterMaritialStatus", renter.RenterMaritialStatus);
            parameters.Add("RenterAddress", renter.RenterAddress);
            parameters.Add("RenterProfession", renter.RenterProfession);
            parameters.Add("OfficeAddress", renter.OfficeAddress);
            parameters.Add("Religion", renter.Religion);
            parameters.Add("EducationalBackground", renter.EducationalBackground);
            parameters.Add("RenterPhone", renter.RenterPhone);
            parameters.Add("RenterEmail", renter.RenterEmail);
            parameters.Add("RenterNID", renter.RenterNID);
            parameters.Add("PassportNo", renter.PassportNo);
            parameters.Add("EmergencyContactName", renter.EmergencyContact?.contractName);
            parameters.Add("EmergencyContactRelation", renter.EmergencyContact?.Relation.ToString());
            parameters.Add("EmergencyContactAddress", renter.EmergencyContact?.Address);
            parameters.Add("EmergencyContactPhone", renter.EmergencyContact?.contractPhone);
            parameters.Add("MemberName", renter.MemberName);
            parameters.Add("MemberNID", renter.MemberNID);
            parameters.Add("MemberPhone", renter.MemberPhone);
            parameters.Add("MemberAddress", renter.MemberAddress);
            parameters.Add("MemberEmail", renter.MemberEmail);
            parameters.Add("DriverName", renter.DriverName);
            parameters.Add("DriverNID", renter.DriverNID);
            parameters.Add("DriverPhone", renter.DriverPhone);
            parameters.Add("DriverAddress", renter.DriverAddress);
            parameters.Add("TotalMember", renter.TotalMember);
            // (Repeat all fields same as in Add method)
            // ...
            _db.Execute("spUpdateRenterInfo", parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task DeleteAsync(int id)
        {
            await _db.ExecuteAsync("sp_DeleteRenter", new { RenterID = id }, commandType: CommandType.StoredProcedure);
        }
    }

}
