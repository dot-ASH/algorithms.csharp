using System;
using System.Collections.Generic;

namespace algorithm.Kruskals
{
    class Program
    {
        public static void Main(String[] args)
        {
            int vertices = 6;
            int edges = 8;
            Graph graph = new Graph(vertices, edges);

            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 4;

            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 4;

            graph.edge[2].src = 1;
            graph.edge[2].dest = 2;
            graph.edge[2].weight = 2;

            graph.edge[3].src = 2;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 3;

            graph.edge[4].src = 2;
            graph.edge[4].dest = 5;
            graph.edge[4].weight = 2;

            graph.edge[5].src = 2;
            graph.edge[5].dest = 4;
            graph.edge[5].weight = 4;

            graph.edge[6].src = 3;
            graph.edge[6].dest = 4;
            graph.edge[6].weight = 3;

            graph.edge[7].src = 5;
            graph.edge[7].dest = 4;
            graph.edge[7].weight = 3;

            graph.KruskalMST();
        }
    }
    public class Graph
    {
        public class Edge : IComparable<Edge>
        {
            public int src, dest, weight;
            public int CompareTo(Edge? compareEdge)
            {
                if (compareEdge == null) return 1;
                return this.weight - compareEdge.weight;
            }
        }

        public class subset
        {
            public int parent, rank;
        };

        int V, E;

        public Edge[] edge;

        public Graph(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        int find(subset[] subsets, int i)
        {

            if (subsets[i].parent != i)
                subsets[i].parent
                    = find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        void Union(subset[] subsets, int x, int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);

            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }
        public void KruskalMST()
        {
            Edge[] result = new Edge[V];

            int e = 0;

            int i = 0;
            for (i = 0; i < V; ++i)
                result[i] = new Edge();
            Array.Sort(edge);

            subset[] subsets = new subset[V];
            for (i = 0; i < V; ++i)
                subsets[i] = new subset();

            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }
            i = 0;

            while (e < V - 1)
            {
                Edge next_edge = new Edge();
                next_edge = edge[i++];

                int x = find(subsets, next_edge.src);
                int y = find(subsets, next_edge.dest);

                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
            }
            Console.WriteLine("The edges:- ");

            int minimumCost = 0;
            for (i = 0; i < e; ++i)
            {

                Console.WriteLine($"{result[i].src} > {result[i].dest} = {result[i].weight}");
                minimumCost += result[i].weight;
            }

            Console.WriteLine($"Minimum Cost Spanning Tree: {minimumCost}");
        }

    }

}
