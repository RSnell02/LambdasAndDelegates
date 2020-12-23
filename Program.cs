/*
 * Project: LambdasAndDelegates
 * Filename: Program.cs
 * Author: R. Snell
 * Date: Dec. 23, 2020
 * Purpose: To demonstrate the use of lambda expressions in the example of Delegates
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{
    class Program
    {
        // Delegate for a function that receives an int and returns a bool
        public delegate bool NumberPredicate(int number);
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Create an instance of the NumberPredicate delegate type
            // using an implicit lambda expression
            NumberPredicate evenPredicate = number => number % 2 == 0;
            // Call isEven using a delegate3 variable
            Console.WriteLine($"Call isEven using a delegate variable:" +
                $" {evenPredicate(4)}");
            // Filter the even numbers using the method isEven
            List<int> evenNumbers = FilterArray(numbers, evenPredicate);
            // Display the results
            DisplayList("Use a lambda to filter even number: ", evenNumbers);

            // Date: Mar 11, 2019
            // Filter the odd numbers using the method isOdd
            List<int> oddNumbers = FilterArray(numbers, (int number) =>
                             number % 2 == 1);
            // Display the results
            DisplayList("Use a lambda to filter odd numbers: ", oddNumbers);

            // Filter numbers greater than 5 using method isOver5
            List<int> numbersOver5 = FilterArray(numbers, number =>
            { return number > 5; });
            // Display the results
            DisplayList("Use isOver5 to filter numbers over 5: ", numbersOver5);
        }   // End Main()

        // Select an array's elements that satisfy the predicate
        private static List<int> FilterArray(int[] intArray, NumberPredicate predicate)
        {
            var result = new List<int>();

            // Iterate over each element in the array
            foreach (var item in intArray)
            {
                // if element satisfy the predicate
                if (predicate(item))    // Invokes method referenced by predicate
                    result.Add(item);   // Add the item to the List
            }   // End foreach
            return result;
        }   // End FilterArray()

        // Display the elements of a List
        private static void DisplayList(string description, List<int> list)
        {
            Console.Write(description);

            // Iterate over the list
            foreach (var item in list)
                Console.Write($"{item} ");
            Console.WriteLine();
        }   // End DisplayList()
    }   // End class
}   // End namespace
