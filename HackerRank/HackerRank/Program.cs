using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {


            //SockMerchant();
            //CutTheSticks();
            //AngryProfessor();
            //DivisibleSumPairs();
            //Kangaroo();
            //CirculeRotation();
            //MaximumPerimeterTriangle();
            //TimeCoversion();
            //LeftRotation();

            Console.ReadLine();
        }

        private static void SockMerchant()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] c_temp = Console.ReadLine().Split(' ');
            int[] c = Array.ConvertAll(c_temp, Int32.Parse);

            var pairedSocksIndex = new List<int>();

            for (var outerIndex = 0; outerIndex < c.Length; outerIndex++)
            {
                for (var innerIndex = outerIndex + 1; innerIndex < c.Length; innerIndex++)
                {
                    if (c[outerIndex] == c[innerIndex] && !pairedSocksIndex.Any(i => i == innerIndex || i == outerIndex))
                    {
                        pairedSocksIndex.Add(outerIndex);
                        pairedSocksIndex.Add(innerIndex);
                    }
                }
            }

            Console.WriteLine(pairedSocksIndex.Count / 2);
        }

        private static void CutTheSticks()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            var listOfInts = arr.ToList();

            while (listOfInts.Count > 0)
            {
                var smallest = listOfInts.OrderBy(i => i).First();
                var numberCut = 0;
                for (var index = 0; index < listOfInts.Count; index++)
                {
                    var value = listOfInts[index] - smallest;
                    listOfInts[index] = value;
                    numberCut++;
                }

                Console.WriteLine(numberCut);
                listOfInts.RemoveAll(i => i <= 0);
            }
        }

        private static void AngryProfessor()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);

                string[] a_temp = Console.ReadLine().Split(' ');
                int[] a = Array.ConvertAll(a_temp, Int32.Parse);

                var onTime = 0;
                foreach (var item in a)
                {
                    if (item <= 0)
                    {
                        onTime++;
                        if (onTime == k)
                            break;
                    }
                }

                if (onTime == k)
                    Console.WriteLine("NO");
                else
                    Console.WriteLine("YES");
            }
        }

        private static void DivisibleSumPairs()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            var divisible = 0;
            for (var outerIndex = 0; outerIndex < a.Length; outerIndex++)
            {
                for (var innerIndex = outerIndex + 1; innerIndex < a.Length; innerIndex++)
                {
                    if ((a[outerIndex] + a[innerIndex]) % k == 0)
                    {
                        divisible++;
                    }
                }
            }
            Console.Write(divisible);
        }

        private static void Kangaroo()
        {
            string[] tokens_x1 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(tokens_x1[0]);
            int v1 = Convert.ToInt32(tokens_x1[1]);
            int x2 = Convert.ToInt32(tokens_x1[2]);
            int v2 = Convert.ToInt32(tokens_x1[3]);

            if (x2 >= x1 && v2 >= v1)
            {
                Console.WriteLine("NO");
                return;
            }

            if ((x1 - x2) % (v2 - v1) == 0)
            {
                Console.WriteLine("YES");
                return;
            }
            else
            {
                Console.WriteLine("NO");
                return;
            }
        }

        private static void CirculeRotation()
        {
            //Issue with standing input not able to take 500 array in test case #4
            Console.SetIn(new StreamReader(Console.OpenStandardInput(100000)));
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int q = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            var returnArray = a;
            returnArray = returnArray.Reverse().ToArray();
            var firstPartial = returnArray.Take(k).Reverse().ToArray();
            var secondPartial = returnArray.Skip(k).Reverse().ToArray();
            returnArray = firstPartial.Concat(secondPartial).ToArray();
            //for (var index = 0; index < k; index++)
            //{
            //    var returnCopy = new int[a.Length];
            //    returnArray.CopyTo(returnCopy, 0);

            //    for (var innerIndex = 0; innerIndex < a.Length; innerIndex++)
            //    {    
            //        var indexToSearch = innerIndex - 1;
            //        if (indexToSearch < 0)
            //            indexToSearch += a.Length;
            //        returnArray[innerIndex] = returnCopy[indexToSearch];
            //    }
            //}

            for (int a0 = 0; a0 < q; a0++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(returnArray[m]);
            }

        }

        //private static string ReadLine()
        //{
        //    Stream inputStream = Console.OpenStandardInput(READLINE_BUFFER_SIZE);
        //    byte[] bytes = new byte[READLINE_BUFFER_SIZE];
        //    int outputLength = inputStream.Read(bytes, 0, READLINE_BUFFER_SIZE);
        //    char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
        //    return new string(chars);
        //}

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
