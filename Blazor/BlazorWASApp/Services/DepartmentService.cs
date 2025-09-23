using BlazorClassLibrary.shared.Models;
using System.Net.Http.Json;

namespace BlazorWASApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await httpClient
                .GetFromJsonAsync<IEnumerable<Department>>("https://localhost:7282/api/departments");
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await httpClient
                .GetFromJsonAsync<Department>($"https://localhost:7282/api/departments/{departmentId}");
        }
    }
}
