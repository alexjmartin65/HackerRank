using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void MainTwo(string[] args)
        {
            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            quickSortInPlace(_ar, 0, _ar.Length - 1);

            //QuickSortPart2();
            //QuickSortPart1();
            //InsertionSortRunningTime();
            //InsertionSortInvariantAndCorrectness();
            //InsertionSortPart2();
            //InsertionSortPart1();
            //SortingIntro();
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

        private static void quickSortInPlace(int[] _ar, int left, int right)
        {
            if (left >= right)
                return;

            var pivotIndex = paritionInPlace(_ar, left, right);
            quickSortInPlace(_ar, left, pivotIndex - 1);
            quickSortInPlace(_ar, pivotIndex, right);

        }

        private static int paritionInPlace(int[] _ar, int left, int right)
        {

            var pivot = _ar[right];
            var pivotCounter = left;
            for (var index = left; index < right - 1; index++)
            {
                if (pivot >= _ar[index])
                {
                    var currentTemp = _ar[pivotCounter];
                    _ar[pivotCounter] = _ar[index];
                    _ar[index] = currentTemp;
                    pivotCounter++;
                    //Console.WriteLine(string.Join(" ", _ar));
                }
            }

            var pivotTemp = _ar[pivotCounter];
            _ar[pivotCounter] = pivot;
            _ar[right] = pivotTemp;

            Console.WriteLine(string.Join(" ", _ar));

            return pivotCounter;
        }

        private static void QuickSortPart2()
        {
            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            quickSortPrivatePart2(_ar.ToList());
        }

        private static void quickSortPrivatePart2(List<int> ar)
        {
            var partitioned = getPartionedArrayQuickSortPart2(ar);
            Console.WriteLine(string.Join(" ", partitioned));
        }

        private static List<int> getPartionedArrayQuickSortPart2(List<int> _ar)
        {
            if (_ar.Count <= 1)
                return _ar;

            var pIndex = 0;
            var p = _ar[pIndex];
            var left = new List<int>();
            var equal = new List<int>();
            var right = new List<int>();

            for (var index = 0; index < _ar.Count; index++)
            {
                if (_ar[index] < p)
                    left.Add(_ar[index]);
                else if (_ar[index] > p)
                    right.Add(_ar[index]);
                else if (_ar[index] == p)
                    equal.Add(_ar[index]);
            }

            left = getPartionedArrayQuickSortPart2(left);

            if (left.Count > 1)
                Console.WriteLine(string.Join(" ", left));

            right = getPartionedArrayQuickSortPart2(right);

            if (right.Count > 1)
                Console.WriteLine(string.Join(" ", right));

            var combined = new List<int>();
            combined.AddRange(left);
            combined.AddRange(equal);
            combined.AddRange(right);

            return combined;
        }

        private static void QuickSortPart1()
        {
            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            var pIndex = 0;
            var p = _ar[pIndex];
            var left = new List<int>();
            var equal = new List<int>();
            var right = new List<int>();

            for (var index = 0; index < _ar.Length; index++)
            {
                if (_ar[index] < p)
                    left.Add(_ar[index]);
                else if (_ar[index] > p)
                    right.Add(_ar[index]);
                else if (_ar[index] == p)
                    equal.Add(_ar[index]);
            }

        }

        private static void InsertionSortRunningTime()
        {
            int _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            insertionSortPrivateRunningTime(_ar);
        }

        static void insertionSortPrivateRunningTime(int[] ar)
        {
            var numberOfShifts = 0;
            for (var index = 1; index < ar.Length; index++)
            {
                var lastItem = ar[index];

                for (var innerIndex = index - 1; innerIndex >= 0; innerIndex--)
                {
                    var currentItem = ar[innerIndex];
                    if (currentItem > lastItem && innerIndex + 1 < ar.Length)
                    {
                        ar[innerIndex + 1] = currentItem;
                        numberOfShifts++;
                        if (innerIndex == 0)
                        {
                            ar[innerIndex] = lastItem;
                        }
                    }
                    else if (innerIndex + 1 < ar.Length)
                    {
                        ar[innerIndex + 1] = lastItem;
                        break;
                    }
                }
            }

            Console.WriteLine(numberOfShifts);
        }

        private static void InsertionSortInvariantAndCorrectness()
        {
            Console.ReadLine();
            int[] _ar = (from s in Console.ReadLine().Split() select Convert.ToInt32(s)).ToArray();
            insertionSortInvariantAndCorrectnessPrivate(_ar);
        }

        public static void insertionSortInvariantAndCorrectnessPrivate(int[] array)
        {
            var innerIndex = 0;
            for (var index = 1; index < array.Length; index++)
            {
                var value = array[index];
                innerIndex = index - 1;

                while (innerIndex >= 0 && value < array[innerIndex])
                {
                    array[innerIndex + 1] = array[innerIndex];
                    innerIndex = innerIndex - 1;
                }

                array[innerIndex + 1] = value;

            }
            Console.WriteLine(string.Join(" ", array));
        }

        private static void InsertionSortPart2()
        {
            int _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            insertionSortPrivatePart2(_ar);
        }

        static void insertionSortPrivatePart2(int[] ar)
        {
            for (var index = 1; index < ar.Length; index++)
            {
                var lastItem = ar[index];

                for (var innerIndex = index - 1; innerIndex >= 0; innerIndex--)
                {
                    var currentItem = ar[innerIndex];
                    if (currentItem > lastItem && innerIndex + 1 < ar.Length)
                    {
                        ar[innerIndex + 1] = currentItem;
                        if (innerIndex == 0)
                        {
                            ar[innerIndex] = lastItem;
                        }
                    }
                    else if (innerIndex + 1 < ar.Length)
                    {
                        ar[innerIndex + 1] = lastItem;
                        break;
                    }
                }

                Console.WriteLine(string.Join(" ", ar));
            }
        }

        private static void InsertionSortPart1()
        {
            int _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            insertionSortPart1Private(_ar);
        }

        static void insertionSortPart1Private(int[] ar)
        {

            var lastItem = ar[ar.Length - 1];
            for (var index = ar.Length - 2; index >= 0; index--)
            {
                var currentItem = ar[index];
                if (currentItem > lastItem)
                {
                    ar[index + 1] = currentItem;
                    Console.WriteLine(string.Join(" ", ar));
                    if (index == 0)
                    {
                        ar[index] = lastItem;
                        Console.WriteLine(string.Join(" ", ar));
                    }
                }
                else
                {
                    ar[index + 1] = lastItem;
                    Console.WriteLine(string.Join(" ", ar));
                    break;
                }
            }

        }

        private static void SortingIntro()
        {
            var v = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var stringArray = Console.ReadLine().Split(' ');
            var intArray = Array.ConvertAll(stringArray, int.Parse);

            var index = Array.IndexOf(intArray, v);
            Console.WriteLine(index);
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
