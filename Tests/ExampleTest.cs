using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeTest.Tests
{
    public class ExampleTest
    {
        Database.Services.ExampleService exampleService { get; set; }
        public ExampleTest()
        {
            //Initialise the DB access service.
            this.exampleService = new Database.Services.ExampleService();

            ConsoleLog.LogHeader("Start of Examples");

            this.ExampleAdd();
            this.ExampleDelete();

            ConsoleLog.LogHeader("End of Examples");
        }


        /// <summary>
        /// Add a Record to the database and prove it exists.
        /// </summary>
        public void ExampleAdd()
        {
            ConsoleLog.LogSub("Example Start: Add Object");
            ExampleObject example = new ExampleObject { Name = "Terry" };

            exampleService.Add(example);

            ConsoleLog.LogText("Example Object added.");

            ConsoleLog.LogText($"Getting Example Object");
            List<ExampleObject> examples = exampleService.GetAll();

            for (int i = 0; i < examples.Count(); i++)
            {
                ConsoleLog.LogResult($"Found Example {examples[i].Id}, Name:{examples[i].Name}");
            }

            ConsoleLog.LogSub("Example End: Add Object");
        }

        /// <summary>
        /// Delete a record from the database and prove it has been removed.
        /// </summary>
        public void ExampleDelete()
        {
            ConsoleLog.LogSub("Example Start: Delete Object");
            List<ExampleObject> examples = exampleService.GetAll();

            ConsoleLog.LogText("Deleting Examples...");
            for (int i = 0; i < examples.Count(); i++)
            {
                exampleService.Delete(examples[i].Id);
            }


            examples = exampleService.GetAll();

            if (examples.Count() == 0)
            {
                ConsoleLog.LogResult("No Examples exist.");
            }
            else
            {
                ConsoleLog.LogText($"{examples.Count} are remaining :( ");
            }

            ConsoleLog.LogSub("Example End: Delete Object");
        }
    }
}
