using CodeTest.Tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ensure DB Created.
            Database.Database db = new Database.Database();
            db.Database.EnsureCreated();

            ExampleTest test = new ExampleTest();

            TestOne testOne = new TestOne();
            TestTwo testTwo = new TestTwo();
            TestThree testThree = new TestThree();
            TestFour testFour = new TestFour();

            Console.ReadKey();
        }
    }
}
