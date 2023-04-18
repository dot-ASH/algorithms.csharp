using System;

namespace algorithm.DFS
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
            Console.WriteLine("Depth First Traversal:- ");
            graph.dfs();
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

        public void dfs()
        {
            bool[] visited = new bool[vertices];
            for (int i = 0; i < vertices; ++i)
                if (visited[i] == false) visitNode(i, visited);
            Console.WriteLine();
        }

        public void visitNode(int ver, bool[] visited)
        {
            visited[ver] = true;
            Console.Write(ver + " ");
            foreach (int i in adj[ver])
            {
                if (!visited[i])
                    visitNode(i, visited);
            }

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
