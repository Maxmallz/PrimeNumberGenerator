using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(welcomeMessage());
            Console.WriteLine("");
            Console.WriteLine("select program to run");
            Console.WriteLine("1: Prime Number Printer With Limit");
            Console.WriteLine("2. Prime Number Printer With Range");
            Console.WriteLine("3. Prime Number Checker");
            Console.Write("enter required program: ");

            int choice;
            if(!int.TryParse(Console.ReadLine(),out choice))
            {
                Console.WriteLine("invalid input - exiting application.......");
                Console.ReadLine();
                return;
            }
            if(choice != 1 && choice != 2 && choice != 3)
            {
                Console.WriteLine("invalid input - exiting application.......");
                Console.ReadLine();
                return;
            }

            switch (choice)
            {
                case 1:
                printPrimeNumbers_Helper();
                    break;
                case 2:
                    printPrimeNumbersFromRange_Helper();
                    break;
                case 3:
                    isNumberPrime_Helper();
                    break;
                default:
                    break;
            }
            Console.ReadLine();

        }
        private static void printPrimeNumbers(int count)
        {
            int i = 0;
            foreach(int number in Enumerable.Range(2, int.MaxValue - 1))
                {
                 foreach (int x in Enumerable.Range(2, number - 1))
                  {
                        if(number % x == 0) { break; }//not a prime
                        if(x == number - 1)
                        {
                            Console.WriteLine(number);
                            i++;
                            break;
                        }
                  }
                  if(i >= count) { break; }
            }
        }
        private static void printPrimeNumbersRange(int minValue, int maxValue)
        {

            if(minValue >= maxValue || minValue <= 1 || minValue == 2)
            {
                Console.WriteLine("minValue must be less than maxValue");
                Console.WriteLine("minValue cannot be 1 or less");
                Console.WriteLine("minValue must be greater than 2");
                return;
            }
            
            int count = 0;
            foreach (int number in Enumerable.Range(minValue, maxValue))
            {
                foreach (int x in Enumerable.Range(2, number - 1))
                {
                    if(number % x == 0) { break; }
                    if(x == number - 1)
                    {
                        Console.WriteLine(number);
                        count++;
                    }
                }
            }
            if(count == 0)
            {
                Console.WriteLine("no prime numbers found");
            }

        }
        private static bool isNumberPrime(int number)
        {
            bool isPrime = false;
            foreach (int divisor in Enumerable.Range(2, number - 2))
            {
                if(number % divisor == 0)
                {
                    break;
                }
                if (divisor == number - 1)
                {
                    isPrime = true;
                }
            }
            return isPrime;
        }
        private static void isNumberPrime_Helper()
        {
            Console.Write("enter number to check if it is prime: ");
            int number;
            if(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("invalid input - exiting application.......");
                Console.ReadLine();
            }
            if (isNumberPrime(number))
            {
                Console.WriteLine("Yay! {0} is a prime number....", number);
            }
            else
            {
                Console.WriteLine("Nah! {0} is a not prime number....", number);
            }
        }
        private static void printPrimeNumbers_Helper()
        {
            Console.Write("enter required number of prime numbers between 1 and 5000: ");
            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("invalid input - exiting application.......");
                Console.ReadLine();
            }

            printPrimeNumbers(number);
        }
        private static void printPrimeNumbersFromRange_Helper()
        {
            int minNum, maxNum;
            Console.WriteLine("enter the ranges to get prime numbers");
            Console.Write("what is the minimum number: ");
            int.TryParse(Console.ReadLine(), out minNum);
            Console.Write("what is the maximum number: ");
            int.TryParse(Console.ReadLine(), out maxNum);

            printPrimeNumbersRange(minNum, maxNum);
        }
        private static string welcomeMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------------Prime Number Printer-----------------");
            sb.AppendLine("Hello and welcome to this prime number application.");
            sb.AppendLine("This application was written by Irogbele Maximillian");
            sb.AppendLine("It performs 3 simple tasks regarding prime numbers.");
            sb.AppendLine("1. Prints a list of prime numbers with you our awesome user specifying the limit");
            sb.AppendLine("2. Prints a list of prime numbers within a range");
            sb.AppendLine("3. Checks if a number if prime or not");
            sb.AppendLine("Have fun.................. :)");

            return sb.ToString();

        }
    }
}