using System;
using System.Collections.Generic;
using System.Text;
using CodeTest.Database.Services;
using CodeTest.Models;

namespace CodeTest
{
    public class TestOne
    {
        private int TestCustomerId = 1234;
        private CustomerService customerService;

        /// <summary>
        /// Initialiser, no need to touch this.
        /// </summary>
        public TestOne()
        {
            ConsoleLog.LogHeader("Test 1 Begin");

            this.customerService = new();

            this.CreateCustomer();
            this.GetCustomer();
            this.UpdateCustomer();
            this.DeleteCustomer();

            ConsoleLog.LogHeader("Test 1 End");
        }

        /// <summary>
        /// Create a Customer Record and add it to the database.
        /// </summary>
        private void CreateCustomer()
        {
            ConsoleLog.LogSub("Test 1:Create Record");

            Customer customer = new()
            {
                Name = "Jonathan",
                Id = TestCustomerId,
                Address = "Manchester",
                Postcode = "M1 8OP",
                Phonenumber = 09910101
            };

            ConsoleLog.LogText("Adding customer to database ...");
            customerService.Add(customer);
            
            ConsoleLog.LogText("Getting all customers from database ...");
            List<Customer> customers = customerService.GetAll();
            ConsoleLog.LogResult("Customer created:");
            for(int i=0; i<customers.Count; i++) ConsoleLog.LogText(customers[i].Name);

            ConsoleLog.LogSub("Test 1 End:Create Record");
        }

        /// <summary>
        /// Get the Customer Record from the database.
        /// </summary>
        private void GetCustomer()
        {
            ConsoleLog.LogSub("Test 1: Get Record");

            ConsoleLog.LogText("Getting customer from database ...");
            Customer customer = customerService.Get(TestCustomerId);
            ConsoleLog.LogResult($"Customer name: {customer.Name}, Customer Id: {customer.Id}");

            ConsoleLog.LogSub("Test 1 End: Get Record");
        }

        /// <summary>
        /// Find the previously added record and alter the Name, check that the record has been updated in the database.
        /// </summary>
        private void UpdateCustomer()
        {
            ConsoleLog.LogSub("Test 1:Update Record");

            string customerNewName = "Benjamin";

            ConsoleLog.LogText($"Customer name before: {customerService.Get(TestCustomerId).Name}");
            ConsoleLog.LogText("Updating customer name ...");
            customerService.UpdateName(TestCustomerId, customerNewName);
            ConsoleLog.LogResult($"Customer name after: {customerService.Get(TestCustomerId).Name}");

            ConsoleLog.LogSub("Test 1 End:Update Record");
        }

        /// <summary>
        /// Find the previously added record and remove it, check the record has been removed from the database.
        /// </summary>
        private void DeleteCustomer()
        {
            ConsoleLog.LogSub("Test 1:Delete Record");

            ConsoleLog.LogText("Deleting customer from database ...");
            customerService.Delete(TestCustomerId);

            ConsoleLog.LogText("Getting all customers from database ...");
            List<Customer> customers = customerService.GetAll();
            ConsoleLog.LogResult($"Number of customers in database: {customers.Count}");

            ConsoleLog.LogSub("Test 1 End:Delete Record");
        }
    }
}
