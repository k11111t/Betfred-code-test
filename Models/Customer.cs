using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public int Phonenumber { get; set; }
    }
}
