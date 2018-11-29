namespace leetcode
{
    //adjacency list
    //adjacency matrix
    public abstract class Graph
    {
        //Create a graph with n vertexes
        public Graph(int n)
        {

        }
        public int VertexCount();
        public int EdgeCount();
        //Add a edge, connected from v1 to v2.
        public void AddEdge(int v1, int v2);
        //get vertex v's all adjacent vertexes list.
        public List<List<int>> GetAdjacentVertex(int v);
        //get vertex v's degree (how many edges)
        public int GetDegree(int v);
        //get the amount of all the vertexes's degree
        public int GetMaxDegree();
        //get the average of all the vertexes's degree
        public double GetAverateDegree();
        //get self loops in the graph
        public int GetSelfLoopCount();
    }

    //undirected graph, represent with adjasent list.
    public class UndirectdGraph : Graph
    {
        private int vertextCount;
        private int edgeCount;
        private List<List<int>> adjacency;
        public UndirectdGraph(int vertextCount)
        {
            this.vertextCount = vertextCount;
            this.edgeCount = 0;
            adjacency = new List<List<int>>();
        }

        public int VertexCount()
        {
            return vertextCount;
        }

        public int EdgeCount()
        {
            return edgeCount;
        }

        public void AddEdge(int v1, int v2)
        {
            adjacency[v1] = new List<int>();
            adjacency[v1].Add(v2);
            adjacency[v2] = new List<int>();
            adjacency[v2].Add(v1);
            edgeCount++;
        }
        public List<List<int>> GetAdjacentVertex(int v)
        {
            return adjacency[v];
        }


    }

    public class DFS
    {
        private UndirectdGraph g;
        private bool[] isConnected;
        private int connectedCount;
        private int startVertex;
        public DFS(UndirectdGraph g)
        {
            this.g = g;
            isConnected = new bool[g.VertexCount];
        }
        public void StartDFS(int vertex)
        {
            this.startVertex = vertex;
            Search(startVertex);
        }
        //find all the vertexes that s and to;
        public Search(int vertex)
        {
            isConnected[vertex] = true;
            connectedCount++;
            foreach (var v in g.GetAdjacentVertex(vertex))
            {
                if (!isConnected(v))
                {
                    Search(v);
                }
            }
        }

        //is s-v connected
        public bool IsConnected(int v)
        {
            return connected[v];
        }
        //count of vertextes which connected to target s
        public int ConnectedCount()
        {
            connectedCount;
        }


    }
}