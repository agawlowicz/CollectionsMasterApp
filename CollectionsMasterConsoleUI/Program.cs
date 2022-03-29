using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arrays
            var numbersArray = new int[50]; //integer Array of size 50
            
            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(numbersArray);

            Console.WriteLine($"First number of array: {numbersArray[0]}");
            Console.WriteLine($"Last number of array: {numbersArray[numbersArray.Length - 1]}");
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers Original:");
            NumberPrinter(numbersArray);
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers Reversed:");
            ReverseArray(numbersArray); //same as Array.Reverse(numbersArray)
            NumberPrinter(numbersArray);
            Console.WriteLine("-------------------");

            
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(numbersArray);
            NumberPrinter(numbersArray);
            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(numbersArray);
            NumberPrinter(numbersArray);
            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            var numbersList = new List<int>();

            Console.WriteLine($"Capacity before population: {numbersList.Capacity}");          
            Populater(numbersList);
            Console.WriteLine($"Capacity after population: {numbersList.Capacity}");
            Console.WriteLine("---------------------");

            //Search for input given number, make sure user input doesn't crash program using do-while loop
            bool userResponse;
            int result;
            do
            {
                Console.WriteLine("What number will you search for in the number list?");
                userResponse = int.TryParse(Console.ReadLine(), out result);

            } while (!userResponse);
            NumberChecker(numbersList, result); //method also writes to console
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            NumberPrinter(numbersList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(numbersList);
            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            numbersList.Sort();
            OddKiller(numbersList);
            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable

            var convertedToArray = numbersList.ToArray();

            //Clear the list

            numbersList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            var counter = 0;
            foreach (var item in numbers)
            {
                if (item % 3 == 0)
                {
                    numbers[counter++] = 0;
                }
            }
        }

        /*
        private static void ThreeKiller2(int[] numbers)
        {
            for(var i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
            NumberPrinter(numbers);
        } */

        private static void OddKiller(List<int> numberList) //try with just a for loop
        {
            foreach (var item in numberList)
            {
                if (item % 2 == 0)
                {
                    Console.WriteLine(item);
                }
            }
            /*
             * for(var i = numberList.Count - 1; i >= 0; i--)
             * {
             *      if(numberList[i] % 2 == 0)
             *      {
             *          numberList.Remove(numberList[i]);
             *      }
             * }
             */
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine($"{searchNumber} is present in the list.");
            }
            else
            {
                Console.WriteLine($"{searchNumber} is not present in the list.");
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();

            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(50));
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();

            for (int i = 0; i < 50; i++)
            {
                numbers[i] = rng.Next(50);
            }

        }        

        // Array.Reverse(intArray);
        private static void ReverseArray(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                var arrayCopy = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = arrayCopy;
            }
        }


        /* private static void ReverseArray2(int[] array)
        {
            var reversed = new int[array.Length];
            var counter = 0;

            for(var i = array.Length - 1; i >= 0; i--)
            {
                reversed[counter++] = array[i];
            }

            NumberPrinter(reversed);
        } */


        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
