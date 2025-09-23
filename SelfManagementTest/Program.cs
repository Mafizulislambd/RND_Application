using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

namespace SelfManagementTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Test());

            CloudStorageAccount storageAccount;
            CloudTableClient tableClient; // Connnect to Storage Account
            storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            // Create the Table 'Book', if it not exists
            tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Book");
            table.CreateIfNotExistsAsync();
            // Create a Book instance
            Book book = new Book()
            {
                Author = "Rami",
                BookName = "ASP.NET Core With Azure",
                Publisher = "APress"
            };
            book.BookId = 1;
            book.RowKey = book.BookId.ToString();
            book.PartitionKey = book.Publisher;
            book.CreatedDate = DateTime.UtcNow;
            book.UpdatedDate = DateTime.UtcNow;
            // Insert and execute operations
            TableOperation insertOperation = TableOperation.Insert(book);
            table.ExecuteAsync(insertOperation);
            #region Azure Storeage

            #endregion




            Console.ReadLine();
        }
    }
}