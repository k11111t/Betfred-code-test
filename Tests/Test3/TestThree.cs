using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

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
            // using regex to remove the non-alpha numerics
            string patternNonAlphaNumeric = @"[^a-zA-Z0-9]+";
            string resultAlphaNumeric = Regex.Replace(value, patternNonAlphaNumeric, "");
            ConsoleLog.LogResult($"String with only alphanumeric characters: {resultAlphaNumeric}");

            // task 2
            // match the numbers in the string
            string patternNumber = @"[0-9]+";
            MatchCollection matchCollection = Regex.Matches(value, patternNumber);
            List<Match> matches = matchCollection.OrderBy(x => int.Parse(x.Value)).ToList();
            ConsoleLog.LogResult($"Numbers sorted in order: ");
            for(int i=0; i<matches.Count; i++) ConsoleLog.LogText($"{matches[i].Value}");
            
            // task 3
            // replace the numbers and set the remaining chars to uppercase
            string resultNonNumeric = Regex.Replace(resultAlphaNumeric, patternNumber, "");
            ConsoleLog.LogResult($"Remaining characters in uppercase: {resultNonNumeric.ToUpper()}"); // or loop through it if needed

            ConsoleLog.LogSub("Test 3 End: Parse String");
        }
    }
}