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
            BreadthFirstSearchShortestReachArrays();

            Console.ReadLine();
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
