using System.Runtime;
using System.Collections.Generic;
using System.Collections;

namespace LeetCode
{
    //adjacency list
    public abstract class Graph
    {
        protected int vertexCount;
        protected int edgeCount;
        protected List<List<int>> adjacency;
        //Create a graph with n vertexes
        public Graph()
        {
            this.vertexCount = vertexCount;
            this.edgeCount = 0;
            adjacency = new List<List<int>>();
        }
        public abstract int GetVertexCount();
        public abstract int GetEdgeCount();
        //Add a edge, connected from v1 to v2.
        public abstract void AddEdge(int v1, int v2);
        //get vertex v's all adjacent vertexes list.
        public abstract List<int> GetAdjacentVertex(int v);
//        //get vertex v's degree (how many edges)
//        public abstract int GetDegree(int v);
//        //get the amount of all the vertexes's degree
//        public abstract int GetMaxDegree();
//        //get the average of all the vertexes's degree
//        public abstract double GetAverateDegree();
//        //get self loops in the graph
//        public abstract int GetSelfLoopCount();
    }

    //undirected graph, represent with adjasent list.
    public class UndirectedGraph : Graph
    {
        public UndirectedGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            this.edgeCount = 0;
            adjacency = new List<List<int>>();
        }

        public override int GetVertexCount()
        {
            return vertexCount;
        }

        public override int GetEdgeCount()
        {
            return edgeCount;
        }

        public override void AddEdge(int v1, int v2)
        {
            adjacency[v1] = new List<int>();
            adjacency[v1].Add(v2);
            adjacency[v2] = new List<int>();
            adjacency[v2].Add(v1);
            edgeCount++;
        }
        public override List<int> GetAdjacentVertex(int v)
        {
            return adjacency[v];
        }
    }

    public class DirectedGraph : Graph
    {
        public DirectedGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            this.edgeCount = 0;
            adjacency = new List<List<int>>();
        }

        public override int GetVertexCount()
        {
            return vertexCount;
        }

        public override int GetEdgeCount()
        {
            return edgeCount;
        }

        public override void AddEdge(int v1, int v2)
        {
            adjacency[v1] = new List<int>();
            adjacency[v1].Add(v2);
            edgeCount++;
        }
        public override List<int> GetAdjacentVertex(int v)
        {
            return adjacency[v];
        }
    }
    
    public class DFS
    {
        private UndirectedGraph g;
        private bool[] isConnected;
        private int connectedCount;
        private int startVertex;
        public DFS(UndirectedGraph g)
        {
            this.g = g;
            isConnected = new bool[g.GetVertexCount()];
        }
        public void StartDFS(int vertex)
        {
            this.startVertex = vertex;
            Search(startVertex);
        }
        //find all the vertexes that s connected to;
        private void Search(int vertex)
        {
            isConnected[vertex] = true;
            connectedCount++;
            foreach (var v in g.GetAdjacentVertex(vertex))
            {
                if (!isConnected[v])
                {
                    Search(v);
                }
            }
        }

        //is s-v connected
        public bool IsConnected(int v)
        {
            return isConnected[v];
        }
        //count of vertextes which connected to target s
        public int ConnectedCount()
        {
            return connectedCount;
        }
    }

    public class BFS
    {
        private UndirectedGraph g;
        private bool[] isConnected;
        private int[] pathVertexes;
        private int startVertex;

        public BFS(UndirectedGraph g)
        {
            this.g = g;
            isConnected = new bool[g.GetVertexCount()];
            pathVertexes = new int[g.GetVertexCount()];
        }

        public void StartBFS(int startVertex)
        {
            this.startVertex = startVertex;
        }

        private void Search(int vertex)
        {
            Queue<int> queue = new Queue<int>();
            isConnected[vertex] = true; // start point set to true;
            queue.Enqueue(vertex);
            while (queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach (var adjV in g.GetAdjacentVertex(v))
                {
                    if (!isConnected[adjV])
                    {
                        pathVertexes[adjV] = v;
                        isConnected[adjV] = true;
                        queue.Enqueue(adjV);
                    }

                }
            }
        }
    }

    public class WeightedEdge
    {
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private int startVertex;
        private int endVertex;
        private double weight;

        public WeightedEdge(int startVertex, int endVertex, double weight)
        {
            this.startVertex = startVertex;
            this.endVertex = endVertex;
            this.weight = weight;
        }

        public int EitherEdge()
        {
            return startVertex;
        }
        public int OtherEdge(int vertex)
        {
            if (vertex == startVertex)
            {
                return endVertex;
            }
            else if (vertex == endVertex)
            {
                return startVertex;
            }

            return -1;
        }
    }

    public class WeightedGraph : Graph
    {
        List<WeightedEdge>[] adjacency;
        public WeightedGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            this.edgeCount = 0;
            adjacency = new List<WeightedEdge>[vertexCount];
        }
        public override int GetVertexCount()
        {
            return vertexCount;
        }

        public override int GetEdgeCount()
        {
            return edgeCount;
        }
        public override void AddEdge(int v1, int v2)
        {
            //adjacency[v1] = new List<WeightedEdge>();
            //adjacency[v1].Add(v2);
            //edgeCount++;
        }
        public void AddEdge(WeightedEdge edge)
        {
            int v = edge.EitherEdge();
            int w = edge.OtherEdge(v);
            adjacency[v].Add(edge);
            adjacency[w].Add(edge);
            edgeCount++;
        }

        public override List<int> GetAdjacentVertex(int v)
        {
            throw new System.NotImplementedException();
        }
    }
}