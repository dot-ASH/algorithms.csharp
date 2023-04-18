using System;

namespace algorithm.BFS
{
    class Program
    {
        public static void Main(String[] args)
        {
            Graph graph = new Graph(5);

            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(0, 3);
            graph.addEdge(1, 2);
            graph.addEdge(1, 4);
            graph.addEdge(2, 4);

            graph.printGraph();
            Console.WriteLine("Breadth first search:- ");
            graph.bfs(0);
        }
    }

    public class Graph
    {
        private int vertices;
        public List<int>[] adj;
        public Graph(int v)
        {
            vertices = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        public void bfs(int start)
        {
            bool[] visited = new bool[vertices];
            Queue<int> queue = new Queue<int>();
            for (int i = start; i < vertices; ++i)
                if (visited[i] == false)
                {
                    int[] tempNode = visitNode(i, visited);
                    foreach (var item in tempNode)
                    {
                        queue.Enqueue(item);
                    }
                }

            Console.WriteLine(string.Join(" > ", queue));
        }

        public int[] visitNode(int ver, bool[] visited)
        {
            visited[ver] = true;

            int[] tempNode = new int[adj[ver].Count + 1];
            tempNode[0] = ver;
            for (int i = 0; i <= adj[ver].Count; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    tempNode[i] = i;
                }
            }
            return tempNode;
        }

        public void printGraph()
        {

            for (int i = 0; i < vertices; i++)
            {
                Console.Write($"{i} > " + string.Join(",", adj[i]) + "\n");
            }

        }


    }
}
