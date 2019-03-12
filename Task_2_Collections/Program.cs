using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string regular_for_input = @"^[A-Z]{1}[a-z]+[:]{1}[1-5]{1}$";
            string regular_for_surname = @"^[A-Z]{1}[a-z]+$";
            string regular_for_mark = @"^[1-5]{1}$";
            string input;
            var flaf = true;
            Console.WriteLine("Please enter students and their marks: (enter 'stop' to finish): ");
            while (flaf)
            {
                try
                {
                    input = Console.ReadLine();
                    if (input == "stop")
                    {
                        flaf = false;
                        break;
                    }
                    if (Regex.IsMatch(input, regular_for_input))
                    {
                        AddSurnameAndMarkToDictionary(dictionary, input);
                    }
                    else if (input != "stop")
                    {
                        Console.WriteLine("Input has wrong format! Desired format: 'Surname:Mark'" +
                            "\nMark should be a number from 1 to 5." +
                            "\nSurname must begin with a capital letter.");
                    }
                }
                catch (System.ArgumentException ex)
                {
                    Console.WriteLine("This name already exists. The key must be unique!");
                }
            }

           do
            {
                Console.WriteLine("Please enter surnaame to see student's mark or a mark to see all students with it:" +
                                       " \nOr enter 'exit' to exit: ");
                input = Console.ReadLine();
                if (Regex.IsMatch(input, regular_for_surname))
                {
                    PrintSurnameAndMark(dictionary, input);
                }
                else if (Regex.IsMatch(input, regular_for_mark))
                {
                    PrintAllSurname(dictionary, input);
                }
                else if (input != "exit")
                {
                    Console.WriteLine("input has wrong format!");
                }
            }
            while (input != "exit");
            Console.ReadKey();
        }


        public static void AddSurnameAndMarkToDictionary(Dictionary<string, int> dictionary, string input)
        {
            string[] words = input.Split(new char[] { ':' });
            string surname = words[0];
            int mark = int.Parse(words[1]);
            dictionary.Add(surname, mark);

        }

        public static void PrintSurnameAndMark(Dictionary<string, int> dictionary, string input)
        {
            if (dictionary.ContainsKey(input))
            {
                int mark = dictionary[input];
                Console.WriteLine($"Student {input}  received a {mark}");
            }
            else if (input != "exit")
            {
                Console.WriteLine($"There are no students with {input} surname");
            }

        }

        public static void PrintAllSurname(Dictionary<string, int> dictionary, string input)
        {
            if (dictionary.ContainsValue(Int32.Parse(input)))
            {
                Console.WriteLine($"Student with {input} mark");
                var surname = dictionary.Where(a => a.Value == (Int32.Parse(input))).Select(t => t.Key);
                foreach (var s in surname)
                    Console.WriteLine(s);
            }
            else if (input != "exit")
            {
                Console.WriteLine($"There are no students with {input} mark");
            }
        }
    }
}