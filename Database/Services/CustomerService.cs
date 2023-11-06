using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeTest.Database.Services
{
    public class CustomerService
    {
        public List<Customer> GetAll()
        {
            using (Database context = new Database())
            {
                return context.Customers.ToList();
            }
        }

        public void Add(Customer customer)
        {
            using (Database context = new Database())
            {
                Customer foundCustomer = context.Customers.FirstOrDefault(p => p.Id == customer.Id);
                if(foundCustomer == null)
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (Database context = new Database())
            {
                Customer customer = context.Customers.FirstOrDefault(p => p.Id == id);
                if(customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        }

        public Customer Get(int id)
        {
            using (Database context = new Database())
            {
                Customer customer = context.Customers.FirstOrDefault(p => p.Id == id);
                return customer;
            }
        }

        public void UpdateName(int id, string newName)
        {
            using (Database context = new Database())
            {
                Customer customer = context.Customers.FirstOrDefault(p => p.Id == id);
                if(customer != null)
                {
                    customer.Name = newName;
                    context.Customers.Update(customer);

                    context.SaveChanges();
                }
            }
        }

        
    }
}
