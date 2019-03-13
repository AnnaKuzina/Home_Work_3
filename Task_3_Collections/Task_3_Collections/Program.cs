using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> people = new Dictionary<string, List<string>>();
            people.Add("TV21", new List<string> { "Ternov:1991", "Kyliuk:1999", "Skofenko:1997" });
            Group(people);
            Console.ReadKey();
        }

        public static void Group(Dictionary<string, List<string>> people)
        {
            string input_group;
            while (true)
            {
                Console.WriteLine("Please enter group code. Enter 'exit' to exit: ");
                input_group = Console.ReadLine();
                if (people.ContainsKey(input_group))
                {
                    PrintList(people, input_group);
                }
                else if (input_group != "exit")
                {
                    Console.WriteLine($"There are no group with {input_group} code. Do you want to add it? (y/n)");
                    string input_yes_or_not = Console.ReadLine();
                    if (Regex.IsMatch(input_yes_or_not, @"^[Nn]$"))
                    {
                        continue;
                    }
                    else if (Regex.IsMatch(input_yes_or_not, @"^[Yy]$"))
                    {
                        AddGroup(people, input_group);
                    }
                    else
                    {
                        Console.WriteLine("Input has wrong format!");
                    }
                }
                else
                {
                    break;
                }
            }
        }
        public static void PrintList(Dictionary<string, List<string>> people, string input)
        {
            people.TryGetValue(input, out List<string> Value);
            Console.WriteLine($"{string.Join(" ", Value)}");
        }
       
        public static void AddGroup(Dictionary<string, List<string>> people, string input_group)
        {
            string input_people;
            while (true)
            {
                Console.WriteLine("Please enter students in format 'Surname1:YearOfBirth1, Surname2:YearOfBirth2'");
                input_people = Console.ReadLine() + ',';
                if (Regex.IsMatch(input_people, @"^([A-Z]{1}[a-z]+:[0-9]{4}\s*,\s*)+$"))
                {
                    AddPeopleTolist(people, input_group, input_people);
                    Console.WriteLine($"Group {input_group} is added!");
                    break;
                }
                else
                {
                    continue;
                }
            }

        }

        public static void AddPeopleTolist(Dictionary<string, List<string>> people, string input_group, string input_surname)
        {
            var list_add_people_with_space = input_surname.Replace(" ", "");
            string[] list_add_people = list_add_people_with_space.Split(new char[] { ',' });
            List<string> list_of_people = new List<string>();
            foreach (string s in list_add_people)
                list_of_people.Add(s);
            people.Add(input_group, list_of_people);
        }
    }
}
