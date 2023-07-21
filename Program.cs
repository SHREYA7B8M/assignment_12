using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextProcessingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input text/para:");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            Console.WriteLine($"\nWord Count of text/para: {wordCount}");

            List<string> emailValidation = ExtractEmailAddresses(inputText);
            Console.WriteLine("\nEmail Address Count: " +emailValidation.Count);
            Console.WriteLine("Email Address(es):");
            foreach (var email in emailValidation)
            {
                Console.WriteLine(email);
            }

            List<string> mobileNumberExtraction = ExtractMobileNumbers(inputText);
            Console.WriteLine("\n Mobile Numbers Count: "+mobileNumberExtraction.Count);
            Console.WriteLine("\nMobile Number(s):");
            foreach (var mobNum in mobileNumberExtraction)
            {
                Console.WriteLine(mobNum);
            }

           Console.WriteLine("\nInput any custom regular expression:");  //custom regular expression \b[a-z]+\b
            string customRegexPattern = Console.ReadLine();
            List<string> customRegex = PerformCustomRegexSearch(inputText, customRegexPattern);
            Console.WriteLine("\nCustom Regex Match:");
            foreach (var custom in customRegex)
            {
                Console.WriteLine(custom);
            }
        }

       static int CountWords(string input)
        {
            return input.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        static List<string> ExtractEmailAddresses(string input)
        {
            var emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            var matches = Regex.Matches(input, emailPattern);
            return matches.Cast<Match>().Select(match => match.Value).ToList();
        }

        static List<string> ExtractMobileNumbers(string input)
        {
            var mobilePattern = @"\b\d{10}\b";
            var matches = Regex.Matches(input, mobilePattern);
            return matches.Cast<Match>().Select(match => match.Value).ToList();
        }

       static List<string> PerformCustomRegexSearch(string input, string regexPattern)
        {
            var matches = Regex.Matches(input, regexPattern);
            return matches.Cast<Match>().Select(match => match.Value).ToList();
        }
    }
}

//custom regex match:
//\b\d{2}-\d{2}-\d{4}\b   date match(dd-mm-yyyy)
//\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b  email
//\b\d{10}\b  mobile no
// \b[a-z]+\b match to lowercase words

