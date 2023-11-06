using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeTest.Database.Services
{
    public class ExampleService
    {
        public List<ExampleObject> GetAll()
        {
            using (Database context = new Database())
            {
                return context.Examples.ToList();
            }
        }

        public void Add(ExampleObject example)
        {
            using (Database context = new Database())
            {
                context.Examples.Add(example);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (Database context = new Database())
            {
                ExampleObject example = context.Examples.FirstOrDefault(p => p.Id == id);
                context.Examples.Remove(example);

                context.SaveChanges();
            }
        }
    }
}
