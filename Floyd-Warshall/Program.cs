using System;

namespace algorithm.FloydWarshall
{
    public class Program
    {
        readonly static int INF = 99999;
        static int vertices = 4;
        public static void Main()
        {
            int[,] matrix = { { 0, 5, INF, 10 },{ INF, 0, 3, INF },{ INF, INF, 0, 1 },{ INF, INF, INF, 0 } };

            Graph graph = new Graph(vertices, INF);

            graph.GraphPath(matrix);
            graph.printGraph(matrix);
        }
    }

    public class Graph

    {
        private int vertices;
        private int INF;

        public Graph(int v, int i)
        {
            vertices = v;
            INF = i;
        }
        public void GraphPath(int[,] graph)
        {
            int[,] matrix = new int[vertices, vertices];
            int i, j, k;

            for (i = 0; i < vertices; i++)
            {
                for (j = 0; j < vertices; j++)
                {
                    matrix[i, j] = graph[i, j];
                }
            }

            for (k = 0; k < vertices; k++)
            {
                for (i = 0; i < vertices; i++)
                {
                    for (j = 0; j < vertices; j++)
                    {
                        if (matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                        }
                    }
                }
            }

        }

        public void printGraph(int[,] matrix)
        {
            Console.WriteLine("Shortest distance between every pair:- ");
            for (int i = 0; i < vertices; ++i)
            {
                for (int j = 0; j < vertices; ++j)
                {
                    if (matrix[i, j] == INF)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write($" {matrix[i, j]}  ");
                    }
                }

                Console.WriteLine();
            }
        }

    }
}



