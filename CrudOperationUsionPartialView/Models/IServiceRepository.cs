namespace CrudOperationUsionPartialView.Models
{
    public interface IServiceRepository<in T> where T : class
    {
        public void SdbConnection();
        public int SaveData(Product data);
        public int UpdateData(Product data);
        public int DeleteData(int id);
        public Product GetProductById(int id);
        public List<Product> GetProducts();
    }
}
