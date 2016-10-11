using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int q = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);


            var returnArray = a;
            for (var index = 0; index < k; index++)
            {
                var returnCopy = new int[a.Length];
                returnArray.CopyTo(returnCopy, 0);

                for (var innerIndex = 0; innerIndex < a.Length; innerIndex++)
                {    
                    var indexToSearch = innerIndex - 1;
                    if (indexToSearch < 0)
                        indexToSearch += a.Length;
                    returnArray[innerIndex] = returnCopy[indexToSearch];
                }
            }

            for (int a0 = 0; a0 < q; a0++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(returnArray[m]);
            }

            //MaximumPerimeterTriangle();
            //TimeCoversion();
            //LeftRotation();

            Console.ReadLine();
        }

        private static void LeftRotation()
        {
            var firstLine = Console.ReadLine();
            var firstLineStringArray = firstLine.Split(' ');
            var firstLineIntArray = Array.ConvertAll(firstLineStringArray, int.Parse);

            var n = firstLineIntArray[0];
            var d = firstLineIntArray[1];

            var secondLine = Console.ReadLine();
            var secondLineStringArray = secondLine.Split(' ');
            var startingArray = Array.ConvertAll(secondLineStringArray, int.Parse);

            var returnArray = new int[n];
            for (var index = 0; index < startingArray.Length; index++)
            {
                var indexOfItem = index + d;
                if (indexOfItem >= startingArray.Length)
                {
                    indexOfItem = indexOfItem - startingArray.Length;
                }
                returnArray[index] = startingArray[indexOfItem];
            }


            for (var index = 0; index < returnArray.Length; index++)
            {
                Console.Write(returnArray[index]);
                if (index < returnArray.Length - 1)
                {
                    Console.Write(" ");
                }
            }
        }

        private static void MaximumPerimeterTriangle()
        {
            var n = int.Parse(Console.ReadLine());
            var stringArray = Console.ReadLine().Split(' ');
            var intArray = Array.ConvertAll(stringArray, int.Parse);

            var sorted = intArray.OrderByDescending(i => i).ToArray();
            var arrayOfThree = new int[3];
            var found = false;
            for (var index = 0; index < intArray.Length - 2; index++)
            {
                if (sorted[index] < sorted[index + 1] + sorted[index + 2])
                {
                    arrayOfThree[0] = sorted[index];
                    arrayOfThree[1] = sorted[index + 1];
                    arrayOfThree[2] = sorted[index + 2];
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine(string.Join(" ", arrayOfThree.OrderBy(i => i)));
            }
            else
                Console.WriteLine("-1");
        }

        private static void TimeCoversion()
        {
            string time = Console.ReadLine();
            var split = time.Split(':');
            var hours = int.Parse(split[0]);

            if (time.ToUpper().EndsWith("PM") && hours < 12)
                hours += 12;
            if (time.ToUpper().EndsWith("AM") && hours >= 12)
                hours -= 12;

            var hourString = hours < 10 ? $"0{hours}" : $"{hours}";

            Console.WriteLine($"{hourString}:{split[1]}:{split[2].Replace("PM", string.Empty).Replace("AM", string.Empty)}");
        }
    }
}
