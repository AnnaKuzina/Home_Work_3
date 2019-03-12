using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string input;
            Console.WriteLine("Please enter int items to the list (enter 'stop' to finish): ");
            do
            {
                input = Console.ReadLine();
                if (Int32.TryParse(input, out int number))
                {
                    numbers.Add(int.Parse(input));
                }
                else if (input != "stop")
                {
                    Console.WriteLine("Entered value is not an int. Please enter a number:");
                }
            }
            while (input != "stop");

            Program p = new Program();
            Console.WriteLine("Your list is:");
            p.WriteList(numbers);
            Console.WriteLine("\nYour sorted descending list is:");
            p.SortedDescendingList(numbers);
            Console.WriteLine("\nYour short list is:");
            p.DeleteList(numbers);
            Console.ReadKey();
        }

        public void WriteList(List<int> numbers)
        {
            foreach (int o in numbers)
            {
                Console.Write(o + " ");
            }
        }

        public void SortedDescendingList(List<int> numbers)
        {
            numbers.Sort();
            numbers.Reverse();
            WriteList(numbers);
        }

        public void DeleteList(List<int> numbers)
        {
            if (numbers.Count > 2)
            {
                numbers.RemoveRange(1, numbers.Count - 2);
                WriteList(numbers);
            }
            else
            {
                Console.WriteLine("Entered list has less than 2 items");
            }
        }
    }
}
