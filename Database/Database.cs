using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Database
{
    public class Database : DbContext
    {
        public DbSet<Models.ExampleObject> Examples { get; set; }

        public DbSet<Models.Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase(databaseName: "Test1");
        }
    }
}
