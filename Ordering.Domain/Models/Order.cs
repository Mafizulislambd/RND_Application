using Ordering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Order : EntityBase
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        //BilingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        = string.Empty;
        public decimal Price { get; set; } = 0;
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        = string.Empty;
        public string State { get; set; }
        public string ZipCode { get; set; }

        //payment
        public string CardName { get; set; }
        = string.Empty;
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string Expiration { get; set; }
        public DateTime ExpirationDate
        {
            get; set;
        }
        public int PaymentMethod { get; set; }
    }

}
