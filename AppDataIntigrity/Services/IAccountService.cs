namespace AppDataIntigrity.Services
{
    public interface IAccountService
    {
        Task<bool> CreateAccountAsync(int customerId, decimal initialBalance);
    }

}
