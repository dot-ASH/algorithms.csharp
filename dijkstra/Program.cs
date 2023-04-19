using System;

namespace DijkstraAlgorithm
{
    class Program
    {
         public static void Main(string[] args)
        {
            int[,] graph =  {
                          { 0, 8, 0, 0, 0, 0, 0, 7, 0 },
                          { 4, 0, 8, 0, 0, 0, 0, 9, 0 },
                          { 0, 10, 0, 6, 0, 6, 0, 0, 4 },
                          { 0, 0, 5, 0, 9, 12, 0, 0, 0 },
                          { 0, 0, 0, 9, 0, 8, 0, 0, 0 },
                          { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                          { 0, 0, 0, 9, 0, 2, 0, 1, 6 },
                        };

            dijkstra(graph, 0, 7);
        }
        public static int minDistance(int[] distance, bool[] spt, int vCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < vCount; ++v)
            {
                if (spt[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
        public static void dijkstra(int[,] graph, int source, int vCount)
        {
            int[] distance = new int[vCount];
            bool[] spt = new bool[vCount];

            for (int i = 0; i < vCount; ++i)
            {
                distance[i] = int.MaxValue;
                spt[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < vCount - 1; ++count)
            {
                int u = minDistance(distance, spt, vCount);
                spt[u] = true;

                for (int v = 0; v < vCount; ++v)
                    if (!spt[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, vCount);
        }
             public static void Print(int[] distance, int vCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < vCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

       
    }
}