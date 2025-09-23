using BlazorClassLibrary.shared.Models;

namespace BlazorWASApp.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartment(int departmentId);
    }
}
