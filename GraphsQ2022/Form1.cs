namespace GraphsQ2022
{
    using System;
    using System.Collections.Generic;



    public partial class Form1 : Form
    {
        class Graph
        {
            private Dictionary<int, List<int>> adjacencyList;
            private List<bool> visitedList = new List<bool>();
            public Graph()
            {
                adjacencyList = new Dictionary<int, List<int>>();
            }

            public void AddVertex(int vertex)
            {
                if (!adjacencyList.ContainsKey(vertex))
                {
                    adjacencyList[vertex] = new List<int>();
                    visitedList.Add(false);
                }
            }

            public void AddEdge(int fromVertex, int toVertex)
            {
                AddVertex(fromVertex);
                AddVertex(toVertex);
                adjacencyList[fromVertex].Add(toVertex);
                adjacencyList[toVertex].Add(fromVertex); // For undirected graphs
            }

            public List<int> GetAdjacentVertices(int vertex)
            {
                if (adjacencyList.ContainsKey(vertex))
                {
                    return adjacencyList[vertex];
                }
                return new List<int>();
            }

            public bool G(int V, int P)
            {
                visitedList[V] = true;
                foreach (var N in adjacencyList[V])
                {
                    if (visitedList[N] == false)
                    {
                        if (G(N,V) == true)
                        {
                            return true;
                        }
                    }
                    else if (N!=P)
                    {
                        return true;
                    }
                }

                return false;
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var graph = new Graph();
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 3);
            bool hasCycle = graph.G(0,-1);
            listBox1.Items.Add(hasCycle);
            Console.WriteLine("Adjacent vertices of vertex 1:");
            foreach (var adjVertex in graph.GetAdjacentVertices(1))
            {
                listBox1.Items.Add(adjVertex + " ");
            }
            Console.WriteLine();
        }
    }
}
