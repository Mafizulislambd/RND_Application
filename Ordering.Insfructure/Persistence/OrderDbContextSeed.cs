using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Insfructure.Persistence
{
    public class OrderDbContextSeed
    {
        public static async Task Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order { 
            Id=1
            ,UserName="faisalcse@gmail.com"
            ,FirstName="md"
            ,LastName="Sumon"
            ,EmailAddress="Sumon123@gmail.com"
            ,Address="Dhaka"
            ,TotalPrice=100,
            City="dhaka"
            ,CVV="123"
            ,CardNumber="123"
            ,CreatedBy="Sumon",
            CreatedDate=new DateTime(),
            UpdateDate=new DateTime(),
            UpdatedBy="sss",
            Expiration= "01012025"
            ,PhoneNumber="123"
            
            ,PostalCode="123",
            Region="Dhaka"
            ,Country="123"
            ,ZipCode="123"
            ,State="123"
            
            });
        }
    }
}
