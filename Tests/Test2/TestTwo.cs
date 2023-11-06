using System;
using System.Collections.Generic;
using System.Text;
using CodeTest.Database.Services;
using CodeTest.Models;

namespace CodeTest
{
    public class TestTwo
    {
        private int TestCustomer1Id = 12345;
        private int TestCustomer2Id = 123456;
        private int TestCustomer3Id = 1234567;
        private CustomerService customerService;

        public TestTwo()
        {
            ConsoleLog.LogHeader("Test 2 Begin");
            this.customerService = new();

            this.CreateCustomers();
            this.GetFirstCustomer();
            this.UpdateSecondCustomer();
            this.RemoveThirdCustomer();
            this.RemoveAllCustomers();

            ConsoleLog.LogHeader("Test 2 End");
        }

        private void CreateCustomers()
        {
            ConsoleLog.LogSub("Test 2: Create Customers");

            Customer customer1 = new()
            {
                Name = "Customer 1",
                Id = TestCustomer1Id,
                Address = "Manchester",
                Postcode = "M1 8OP",
                Phonenumber = 09910101
            };
            Customer customer2 = new()
            {
                Name = "Customer 2",
                Id = TestCustomer2Id,
                Address = "Manchester",
                Postcode = "M1 8OP",
                Phonenumber = 09910101
            };
            Customer customer3 = new()
            {
                Name = "Customer 3",
                Id = TestCustomer3Id,
                Address = "Manchester",
                Postcode = "M1 8OP",
                Phonenumber = 09910101
            };           

            ConsoleLog.LogText("Adding customers to database ...");
            customerService.Add(customer1);
            customerService.Add(customer2);
            customerService.Add(customer3);

            ConsoleLog.LogText("Getting all customers from database ...");
            List<Customer> customers = customerService.GetAll();
            ConsoleLog.LogResult("Customers created:");
            for(int i=0; i<customers.Count; i++) ConsoleLog.LogText(customers[i].Name);

            ConsoleLog.LogSub("Test 2 End: Create Customers");
        }

        private void GetFirstCustomer()
        {
            ConsoleLog.LogSub("Test 2: Get First Customer");

            ConsoleLog.LogText("Getting customer from database ...");
            Customer customer = customerService.Get(TestCustomer1Id);
            ConsoleLog.LogResult($"Customer with name {customer.Name} was fetched");

            ConsoleLog.LogSub("Test 2 End: Get First Customer");
        }

        private void UpdateSecondCustomer()
        {
            ConsoleLog.LogSub("Test 2: Update Second Customer");

            string newCustomerName = "Customer 2 new name";

            ConsoleLog.LogText("Getting customer from database ...");
            Customer customer = customerService.Get(TestCustomer2Id);
            ConsoleLog.LogText($"Customer name before: {customer.Name}");

            ConsoleLog.LogText("Updating customer name ...");
            customerService.UpdateName(customer.Id, newCustomerName);
            
            ConsoleLog.LogText("Getting customer from database ...");
            Customer updatedCustomer = customerService.Get(TestCustomer2Id);
            ConsoleLog.LogResult($"Customer 2 name updated to: {updatedCustomer.Name}");

            ConsoleLog.LogSub("Test 2 End: Update Second Customer");
        }

        private void RemoveThirdCustomer()
        {
            ConsoleLog.LogSub("Test 2: Remove Third Customer");

            ConsoleLog.LogText("Getting customer from database ...");
            Customer customer = customerService.Get(TestCustomer3Id);
            ConsoleLog.LogText($"Customer name to be removed: {customer.Name}");

            ConsoleLog.LogText("Deleting customer from database ...");
            customerService.Delete(customer.Id);

            ConsoleLog.LogText("Getting all customers from database ...");
            List<Customer> allCustomers = customerService.GetAll();
            ConsoleLog.LogResult("Remaining customers in database:");
            for(int i=0; i<allCustomers.Count; i++) ConsoleLog.LogText($"{allCustomers[i].Name}");

            ConsoleLog.LogSub("Test 2 End: Remove Third Customer");
        }

        private void RemoveAllCustomers()
        {
            ConsoleLog.LogSub("Test 2: Remove All Customers");

            ConsoleLog.LogText("Getting all customers from database ...");
            List<Customer> allCustomers = customerService.GetAll();

            ConsoleLog.LogText("Deleting all customers from database ...");
            for(int i=0; i<allCustomers.Count; i++) customerService.Delete(allCustomers[i].Id);

            ConsoleLog.LogText("Getting all customers from database ...");
            List<Customer> allCustomersAferDelete = customerService.GetAll();
            ConsoleLog.LogResult("Remaining customers:");
            for(int i=0; i<allCustomersAferDelete.Count; i++) ConsoleLog.LogResult($"{allCustomersAferDelete[i].Name}");
            ConsoleLog.LogResult($"Count: {allCustomersAferDelete.Count}");

            ConsoleLog.LogSub("Test 2 End: Remove All Customers");
        }
    }
}
