using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Tests
{

    public class Tests
    {
        string regular = @"^([A-Z]{1}[a-z]+:[0-9]{4}\s*,\s*)+$";
       
        [Test]
        public void CorrectNameAndDate()
        {
            string input_people = "Ddd:2020";
            Assert.IsTrue(Regex.IsMatch(input_people+',', regular));
        }

        [Test]
        public void CorrectNameAndInncorectDate()
        {
            string input_people = "Ddd:2020232";

            Assert.IsFalse(Regex.IsMatch(input_people + ',', regular));
        }

        [Test]
        public void IncorrectNameAndCorrectDate()
        {
            string input_people = "tdd:2020";
            Assert.IsFalse(Regex.IsMatch(input_people + ',', regular));
        }

        [Test]
        public void CorrectNamesAndDates()
        {
            string input_people = "Rdd:2020,  Rdd:2020  ";
            Assert.IsTrue(Regex.IsMatch(input_people + ',', regular));
        }

        [Test]
        public void IncorrectNamesAndCorrectDates()
        {
            string input_people = "Rdd:2020,  ddd:2020  ";
            Assert.IsFalse(Regex.IsMatch(input_people + ',', regular));
        }
    }
}