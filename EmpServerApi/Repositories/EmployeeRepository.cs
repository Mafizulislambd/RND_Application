using EmpServerApi.Interfaces;
using EmpServerApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace EmpServerApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EmployeeDB");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Employee>("spGetAllEmployees",
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new { EmployeeId = id };
                return await db.QueryFirstOrDefaultAsync<Employee>("spGetEmployeeById",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddEmployee(Employee employee)
        {
           
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                //var parameters = new
                //{
                //    FirstName = employee.FirstName,
                //    LastName = employee.LastName,
                //    Email = employee.Email,
                //    Department = employee.Department,
                //    HireDate = employee.HireDate
                //};

                //// QuerySingleAsync is used since we expect a single value returned
                //var result = await db.QuerySingleAsync<dynamic>("spAddEmployee", parameters,
                //    commandType: CommandType.StoredProcedure);

                //return (int)result.EmployeeId;
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", employee.FirstName);
                parameters.Add("@LastName", employee.LastName);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@Department", employee.Department);
                parameters.Add("@HireDate", employee.HireDate);
                parameters.Add("@EmployeeId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await db.ExecuteAsync("spAddEmployee", parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("@EmployeeId");
            }
            
        
        }

        public async Task UpdateEmployee(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Department = employee.Department,
                    HireDate = employee.HireDate
                };

                await db.ExecuteAsync("spUpdateEmployee", parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new { EmployeeId = id };
                await db.ExecuteAsync("spDeleteEmployee", parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
