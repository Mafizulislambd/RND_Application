namespace DropDownlistPartialView.Models
{
    public class Manufacturer
    {
        public string ManCode { get; set; }
        public string ManName { get; set; }

        public static IQueryable<Manufacturer> GetManufacturers()
        {
            return new List<Manufacturer>
            {
                new Manufacturer {
                    ManCode = "AC",
                    ManName = "ACER"
                },
                new Manufacturer {
                    ManCode = "AP",
                    ManName = "APPLE"
                },
                new Manufacturer {
                    ManCode = "DE",
                    ManName = "DELL"
                },
                new Manufacturer {
                    ManCode = "SN",
                    ManName = "SONY"
                }
            }.AsQueryable();
        }
    }
    public class Category
    {
        public string ManCode { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public static IQueryable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    ManCode = "AC",
                    CategoryID = 1,
                    CategoryName = "Aspire R"
                },
                new Category {
                    ManCode = "AC",
                    CategoryID = 2,
                    CategoryName = "Aspire V3"
                },
                new Category {
                    ManCode = "AC",
                    CategoryID = 3,
                    CategoryName = "Aspire E"
                },
                new Category {
                    ManCode = "AP",
                    CategoryID = 4,
                    CategoryName = "MacBook Air"
                },
                new Category {
                    ManCode = "AP",
                    CategoryID = 5,
                    CategoryName = "MacBook Pro"
                }
                //code omitted - check download link at the bottom
            }.AsQueryable();
        }

    }
    public class Laptop
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static IQueryable<Laptop> GetProducts()
        {
            return new List<Laptop>
            {
                new Laptop {
                    Category = "Aspire R",
                    Name = "R7-571-6858",
                    Price = 999m
                },
                new Laptop {
                    Category = "Aspire V3",
                    Name = "V3-772G-9460",
                    Price = 1299m
                },
                //Code omitted - check the download link at the bottom
            }.AsQueryable();
        } 
    }
        
}
