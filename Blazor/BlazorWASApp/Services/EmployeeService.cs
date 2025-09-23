using BlazorClassLibrary.shared.Models;
using System.Net.Http.Json;

namespace BlazorWASApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Employee>>("https://localhost:7282/api/Employees");
        }
        public async Task<EmployeeDataResult> GetEmployees(int skip, int take, string orderBy)
        {
            return await httpClient.GetFromJsonAsync<EmployeeDataResult>($"https://localhost:7282/api/employees?skip={skip}&take={take}&orderBy={orderBy}");
        }
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
