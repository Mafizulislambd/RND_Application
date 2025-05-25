using DapperApi.Models;

namespace DapperApi.Services.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
