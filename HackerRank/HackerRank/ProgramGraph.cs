using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class ProgramGraph
    {

        static void Main(string[] args)
        {
            BreadthFirstSearchShortestDijkstras();
            //BreadthFirstSearchShortestReachArrays();

            Console.ReadLine();
        }

        private static void BreadthFirstSearchShortestDijkstras()
        {
            var numberOfQueries = Convert.ToInt32(Console.ReadLine());

            for (var queryIndex = 0; queryIndex < numberOfQueries; queryIndex++)
            {
                var secondString = Console.ReadLine() ?? string.Empty;
                var nodes = int.Parse(secondString.Split(' ')[0]);
                var edges = int.Parse(secondString.Split(' ')[1]);

                //var adjacency = new int[nodes][];

                var adjacency = new Dictionary<int, Dictionary<int, int>>();

                //var visited = new bool[nodes];

                var distance = new int[nodes];
                var distancePrevious = new int[nodes];

                for (var adjIndex = 0; adjIndex < nodes; adjIndex++)
                {
                    adjacency[adjIndex] = new Dictionary<int, int>();
                }

                for (var index = 0; index < edges; index++)
                {
                    var nodeString = Console.ReadLine() ?? string.Empty;
                    var node = int.Parse(nodeString.Split(' ')[0]) - 1;
                    var edge = int.Parse(nodeString.Split(' ')[1]) - 1;
                    var weight = int.Parse(nodeString.Split(' ')[2]);

                    if (!adjacency[node].ContainsKey(edge) || adjacency[node][edge] > weight)
                    {
                        adjacency[node][edge] = weight;
                        adjacency[edge][node] = weight;
                    }
                }


                var startingIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                var queue = new Queue<int>();
                queue.Enqueue(startingIndex);

                while (queue.Count != 0)
                {
                    var currentNode = queue.Dequeue();
                    foreach (var sibling in adjacency[currentNode].OrderBy(s => s.Value))
                    {
                        if (distance[sibling.Key] == 0)
                        {
                            distance[sibling.Key] = distance[currentNode] + sibling.Value;
                            queue.Enqueue(sibling.Key);
                        }
                        else
                        {
                            distance[sibling.Key] = Math.Min(distance[sibling.Key], distance[currentNode] + sibling.Value);
                        }
                    }
                    //Matrix
                    //for (var nodeIndex = 0; nodeIndex < adjacency[currentNode].Length; nodeIndex++)
                    //{
                    //     int edge = adjacency[currentNode][nodeIndex];
                    //    if (edge > 0 && distance[nodeIndex] == 0 && nodeIndex != startingIndex)
                    //    {
                    //        distance[nodeIndex] = distance[currentNode] + edge;
                    //        queue.Enqueue(nodeIndex);
                    //    }
                    //    else if (edge > 0 && nodeIndex != startingIndex)
                    //    {
                    //        distance[nodeIndex] = Math.Min(distance[nodeIndex], distance[currentNode] + edge);
                    //    }
                    //}
                }

                for (var adjIndex = 0; adjIndex < nodes; adjIndex++)
                {
                    if (distance[adjIndex] == 0)
                        distance[adjIndex] = -1;
                }

                var builder = string.Empty;
                for (var distanceIndex = 0; distanceIndex < distance.Length; distanceIndex++)
                {
                    if (distanceIndex != startingIndex)
                    {
                        builder += distance[distanceIndex] + " ";
                    }
                }

                Console.WriteLine(builder.Trim());
            }
        }

        private static void BreadthFirstSearchShortestReachArrays()
        {
            var weight = 6;
            var numberOfQueries = Convert.ToInt32(Console.ReadLine());

            for (var queryIndex = 0; queryIndex < numberOfQueries; queryIndex++)
            {
                var secondString = Console.ReadLine() ?? string.Empty;
                var nodes = int.Parse(secondString.Split(' ')[0]);
                var edges = int.Parse(secondString.Split(' ')[1]);

                var adjacency = new int[nodes][];

                var visited = new bool[nodes];
                var distance = new int[nodes];

                for (var adjIndex = 0; adjIndex < nodes; adjIndex++)
                {
                    adjacency[adjIndex] = new int[nodes];
                }

                for (var index = 0; index < edges; index++)
                {
                    var nodeString = Console.ReadLine() ?? string.Empty;
                    var node = int.Parse(nodeString.Split(' ')[0]) - 1;
                    var edge = int.Parse(nodeString.Split(' ')[1]) - 1;

                    adjacency[node][edge] = 6;
                    adjacency[edge][node] = 6;
                }


                var startingIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                var queue = new Queue<int>();
                queue.Enqueue(startingIndex);

                while (queue.Count != 0)
                {
                    var currentNode = queue.Dequeue();
                    for (var nodeIndex = 0; nodeIndex < adjacency[currentNode].Length; nodeIndex++)
                    {
                        int edge = adjacency[currentNode][nodeIndex];
                        //Edge exists
                        if (edge > 0 && !visited[nodeIndex])
                        {
                            visited[nodeIndex] = true;
                            distance[nodeIndex] = distance[currentNode] + edge;
                            queue.Enqueue(nodeIndex);
                        }
                    }
                }

                for (var adjIndex = 0; adjIndex < nodes; adjIndex++)
                {
                    if (distance[adjIndex] == 0)
                        distance[adjIndex] = -1;
                }

                var builder = string.Empty;
                for (var distanceIndex = 0; distanceIndex < distance.Length; distanceIndex++)
                {
                    if (distanceIndex != startingIndex)
                    {
                        builder += distance[distanceIndex] + " ";
                    }
                }

                Console.WriteLine(builder.Trim());
            }
        }

    }
}

//20 25 25 68 86 39 22 70 36 53 91 35 88 27 30 43 54 74 41
//20 25 25 68 86 39 22 70 36 53 91 35 88 27 30 43 54 74 41

//9 8 8 8 12 11 18 8 4 1 12 9 7 11 4 10 10 4 1 7 14 7 11 12 15 10 5 11 6 9 9 11 9 7 8 14 5 13 6 8 13 8 4 10 3 5 5 12 13 1 9 11 4 9 6 7 7 8 11 6 10 7 8 10 14 9 12 8 3 5 7 15 6 10 11 5 14
//9 8 8 8 12 7 15 8 4 1 12 9 7 10 4 10 10 4 1 7 12 7 11 12 15 10 5 11 6 7 9 11 9 7 7 14 5 13 6 8 10 7 4 9 3 5 5 9 13 1 8 11 4 9 6 7 7 8 11 6 10 7 8 9 13 9 12 8 3 5 7 15 6 10 11 5 11

//154 90 186 190 178 114 123 -1 -1 123 -1 104 -1 -1 -1 207 134 123 98 155 -1 198 68 90 170 135 -1 103 145 -1 54 111 163 173 115 87 159 75 -1 94 102 -1 76 67 167 138 216 -1 172 102 212 163 103 112 -1 182 49 145 92 -1 -1 194 -1 182 -1 201 96 -1 85 121 108 161 130 100 120 -1 -1 118 215 92 156 162 163 168 71 110 -1 -1 190 217 100 105 178
//154 90 186 190 178 114 123 -1 -1 123 -1 104 -1 -1 -1 207 134 123 98 155 -1 198 68 90 170 135 -1 103 145 -1 54 111 163 173 115 87 159 75 -1 94 102 -1 76 67 167 138 216 -1 172 102 212 163 103 112 -1 182 49 145 92 -1 -1 194 -1 182 -1 201 96 -1 85 121 108 161 130 100 120 -1 -1 118 215 92 156 162 163 168 71 110 -1 -1 190 217 100 105 178

//13 30 23 33 16 9 34 47 14 20 30 19 37 47 32 42 15 16 19 41 18 21 11 24 50 15 15 50 26 26 17 27 16 35 38 29 22 34 18 21 39 14 35 27 11 23 27 27 27 22 26 18 24 27 33 28 14 26 12 27 30 10 42 10 28 28 29
//13 30 17 33 16 9 31 34 14 20 21 19 24 34 27 42 15 16 19 23 18 21 11 21 28 15 15 45 18 26 17 20 16 28 27 16 22 21 18 21 34 14 26 27 11 23 17 24 27 22 19 18 21 17 17 22 14 20 12 27 21 10 42 10 25 19 22

//3 6 8 11 7 18 10 18 4 8 3 6 12 1 2 16 1 12 13 6 9 9 11 17 11 12 12
//3 6 8 11 7 12 10 18 4 8 3 6 12 1 2 10 1 8 5 6 9 9 8 17 11 12 8

//3 4 5 3 4 5 7 4 4 7 6 4 1 4 5 5 5 4 6 6 6 8 4 6 3 5 7 6 2 6 3 3 7 5 3 6 3 2 8 4 1 6 3 4 5 6 7 7 3 7 3 5 3 6 4 8 4 4 6 4 5 7 5 4 2 2 3 8 4 7 6 5 5 4 6 3 6 5 4 4 4 2 1 3 3 3 2
//3 4 5 3 4 5 5 4 4 7 6 4 1 4 5 5 5 4 5 6 5 6 4 5 3 5 5 6 2 6 3 3 6 5 3 6 3 2 6 4 1 6 3 4 5 6 7 7 3 6 3 5 3 5 4 7 4 4 6 4 5 5 5 4 2 2 3 6 4 6 4 4 5 4 6 3 5 5 4 4 4 2 1 3 3 3 2




//20 25 25 68 86 39 22 70 36 53 91 35 88 27 30 43 54 74 41
//20 25 25 68 86 39 22 70 36 53 91 35 88 27 30 43 54 74 41

//9 8 8 8 12 11 18 8 4 1 13 9 7 11 4 10 10 4 1 7 12 7 11 12 15 11 5 11 6 8 9 12 9 7 7 14 5 13 6 11 14 7 4 10 3 5 5 15 17 1 8 11 4 10 6 10 7 8 11 6 10 14 8 10 14 9 12 8 3 5 7 16 6 10 11 5 14
//9 8 8 8 12 7 15 8 4 1 12 9 7 10 4 10 10 4 1 7 12 7 11 12 15 10 5 11 6 7 9 11 9 7 7 14 5 13 6 8 10 7 4 9 3 5 5 9 13 1 8 11 4 9 6 7 7 8 11 6 10 7 8 9 13 9 12 8 3 5 7 15 6 10 11 5 11

//154 90 186 190 178 114 123 -1 -1 123 -1 104 -1 -1 -1 207 134 123 98 155 -1 198 68 90 170 135 -1 103 145 -1 54 111 163 173 115 87 159 75 -1 94 102 -1 76 67 167 138 216 -1 172 102 212 163 103 112 -1 182 49 145 92 -1 -1 194 -1 182 -1 201 96 -1 85 121 108 161 130 100 120 -1 -1 118 215 92 156 162 163 168 71 110 -1 -1 190 217 100 105 178
//154 90 186 190 178 114 123 -1 -1 123 -1 104 -1 -1 -1 207 134 123 98 155 -1 198 68 90 170 135 -1 103 145 -1 54 111 163 173 115 87 159 75 -1 94 102 -1 76 67 167 138 216 -1 172 102 212 163 103 112 -1 182 49 145 92 -1 -1 194 -1 182 -1 201 96 -1 85 121 108 161 130 100 120 -1 -1 118 215 92 156 162 163 168 71 110 -1 -1 190 217 100 105 178

//13 30 23 33 16 9 40 34 14 20 30 19 24 38 32 42 15 16 24 23 20 21 11 21 28 15 15 50 26 26 41 22 16 30 45 16 22 21 18 21 39 14 35 32 11 27 27 26 31 22 28 18 23 18 17 28 19 26 12 32 21 10 42 10 29 28 24
//13 30 17 33 16 9 31 34 14 20 21 19 24 34 27 42 15 16 19 23 18 21 11 21 28 15 15 45 18 26 17 20 16 28 27 16 22 21 18 21 34 14 26 27 11 23 17 24 27 22 19 18 21 17 17 22 14 20 12 27 21 10 42 10 25 19 22

//3 6 8 11 7 18 10 18 4 8 3 6 12 1 2 16 1 12 13 6 9 9 11 17 11 12 12
//3 6 8 11 7 12 10 18 4 8 3 6 12 1 2 10 1 8 5 6 9 9 8 17 11 12 8

//3 4 5 3 4 5 5 4 4 7 6 4 1 4 5 5 5 4 6 6 5 6 4 6 3 5 7 6 2 6 3 3 7 5 3 7 3 2 6 4 1 6 3 4 5 6 7 7 3 6 3 5 3 6 4 7 4 4 6 4 5 5 5 4 2 2 3 6 4 7 4 4 5 4 6 3 6 5 4 4 4 2 1 3 3 3 2
//3 4 5 3 4 5 5 4 4 7 6 4 1 4 5 5 5 4 5 6 5 6 4 5 3 5 5 6 2 6 3 3 6 5 3 6 3 2 6 4 1 6 3 4 5 6 7 7 3 6 3 5 3 5 4 7 4 4 6 4 5 5 5 4 2 2 3 6 4 6 4 4 5 4 6 3 5 5 4 4 4 2 1 3 3 3 2







//9 8 8 8 12 7 15 8 4 1 12 10 7 12 4 10 10 4 1 7 12 7 11 12 15 10 5 11 6 8 9 11 9 7 7 14 5 13 6 8 13 7 4 10 3 5 5 11 13 1 8 11 4 9 6 7 7 8 11 6 15 7 8 9 14 9 12 8 3 5 7 15 6 10 11 5 11
//9 8 8 8 12 7 15 8 4 1 12 9  7 10 4 10 10 4 1 7 12 7 11 12 15 10 5 11 6 7 9 11 9 7 7 14 5 13 6 8 10 7 4 9  3 5 5 9  13 1 8 11 4 9 6 7 7 8 11 6 10 7 8 9 13 9 12 8 3 5 7 15 6 10 11 5 11




