using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using CodeTest.Models;

namespace CodeTest
{
    public class TestFour
    {
        public TestFour()
        {
            ConsoleLog.LogHeader("Test 4 Begin");            
            this.ConvertJson();

            ConsoleLog.LogHeader("Test 4 End");
        }

        /// <summary>
        /// Convert the Json string into a C# object (typeof ExampleObject) then print the name from the converted object.
        /// </summary>
        public void ConvertJson()
        {
            ConsoleLog.LogSub("Test 4: Convert Json");

            string jsonText;

            #region Json loading
            // Load the embedded Json file in as a string.
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Tests\Test4\TestFourJson.txt");
            jsonText = System.IO.File.ReadAllText(path);
            #endregion

            //task 2
            //load jsonText into json document, use it to iterate through the elements of the document
            List<ExampleObject> exampleObjects = new();
            JsonDocument jsonDocument = JsonDocument.Parse(jsonText);

            foreach (JsonElement e in jsonDocument.RootElement.EnumerateArray())
            { 
                if(e.ValueKind != JsonValueKind.Null)
                {
                    int id = e.GetProperty("Id").GetInt32();
                    string name = e.GetProperty("Name").GetString();
                    int searchReference = e.GetProperty("SearchReference").GetInt32();
                    ExampleObject exampleObject = new()
                    {
                        Id = id,
                        Name = name,
                        SearchReference = searchReference
                    };
                    exampleObjects.Add(exampleObject);
                }
            }
            
            // print the count of the list
            ConsoleLog.LogResult($"list count: {exampleObjects.Count}");

            //task 3
            // return all objects with search reference of 1
            ConsoleLog.LogResult("Objects with search reference equal to 1:");
            foreach(ExampleObject e in exampleObjects)
            {
                if(e.SearchReference == 1) ConsoleLog.LogText($"{e.Name}");
            }

            ConsoleLog.LogSub("Test 4 End: Convert Json");            
        }
    }
}
