using System;
using System.Collections.Generic;
using System.Text;
namespace CodeTest
{
    public class TestThree
    {
        public TestThree()
        {
            ConsoleLog.LogHeader("Test 3 Begin");

            this.ParseString();

            ConsoleLog.LogHeader("Test 3 End");
        }

        /// <summary>
        /// This should print the required outcomes in order.
        /// </summary>
        public void ParseString()
        {
            string value = "B2et_74fr5e9d3681!";

            ConsoleLog.LogSub("Test 3: Parse String");

            // task 1
            // optimised code - regex replace is much slower
            // StringBuilder is a mutable string - does not recreate as string every time I need to append
            StringBuilder resultAlphaNumeric = new();
            // creating the string here so I dont need to iterate again - can save time if the string is long
            StringBuilder resultAlphabetical = new();

            foreach(char c in value) 
            {
                if(char.IsLetterOrDigit(c)) resultAlphaNumeric.Append(c);
                if(char.IsLetter(c)) resultAlphabetical.Append(c);

            }
            ConsoleLog.LogResult(resultAlphaNumeric.ToString());

            // task 2
            List<int> resultNumbers = new();
            StringBuilder tempNumber = new();
            foreach (char c in value)
            {
                //keep appending digits
                if (char.IsDigit(c)) tempNumber.Append(c);
                else if (tempNumber.Length != 0)
                {
                    resultNumbers.Add(int.Parse(tempNumber.ToString()));
                    tempNumber.Clear();
                }
            }
            if (tempNumber.Length > 0) resultNumbers.Add(int.Parse(tempNumber.ToString()));
            
            resultNumbers.Sort( (x,y) => x-y );
            ConsoleLog.LogResult("Numbers sorted:");
            foreach(int i in resultNumbers)
            {
                ConsoleLog.LogText($"{i}");
            }

            // task 3
            ConsoleLog.LogResult($"Remaining characters in uppercase: {resultAlphabetical.ToString().ToUpper()}");

            ConsoleLog.LogSub("Test 3 End: Parse String");
        }
    }
}