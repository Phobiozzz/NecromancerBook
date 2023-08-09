using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Subset
{
    public int Parent;
    public int Rank;
}

public class Graph
{
    public List<Vertex> vertices;
    public List<Edge> edges;
    public int verticesCount;
    public int edgesCount;
    public List<Edge> MST;

    public Graph(List<Triangle> triangles)
    {
        vertices = new List<Vertex>();
        edges = new List<Edge>();
        
        foreach (Triangle triangle in triangles)
        {
            if (!VerticiesPodsitionCompare(triangle.v1))
            {
                vertices.Add(triangle.v1);
            }

            if (!VerticiesPodsitionCompare(triangle.v2))
            {
                vertices.Add(triangle.v2);
            }
            if (!VerticiesPodsitionCompare(triangle.v3))
            {
                vertices.Add(triangle.v3);
            }

            edges.Add(new Edge(triangle.v1, triangle.v2));
            edges.Add(new Edge(triangle.v2, triangle.v3));
            edges.Add(new Edge(triangle.v3, triangle.v1));
            
        }
        verticesCount = vertices.Count;
        edgesCount = edges.Count;
        MST = MinimumSpanningTree(edges);
       
    }

    public void SortEdges(List<Edge> _edges)
    {
        for (int i = 0; i < _edges.Count; i++)
        {
            for (int j = 0; j < _edges.Count - i - 1; j++)
            {
                if (_edges[j].Weigth() > _edges[j + 1].Weigth())
                {
                    Edge temp = _edges[j];
                    _edges[j] = _edges[j + 1];
                    _edges[j + 1] = temp;
                }
            }
        }
    }

    public  List<Edge> MinimumSpanningTree(IEnumerable<Edge> graph)
    {
        List<Edge> ans = new List<Edge>();

        List<Edge> edgess = new List<Edge>(graph);
        SortEdges(edgess);

        HashSet<Vertex> points = new HashSet<Vertex>();
        foreach (var edge in edgess)
        {
            points.Add(edge.v1);
            points.Add(edge.v2);
        }

        Dictionary<Vertex, Vertex> parents = new Dictionary<Vertex, Vertex>();
        foreach (var point in points)
            parents[point] = point;

        Vertex UnionFind(Vertex x)
        {
            if (parents[x] != x)
                parents[x] = UnionFind(parents[x]);
            return parents[x];
        }

        foreach (var edge in edgess)
        {
            var x = UnionFind(edge.v1);
            var y = UnionFind(edge.v2);
            if (x != y)
            {
                ans.Add(edge);
                parents[x] = y;
            }
        }

        return ans;
    }


    public bool VerticiesPodsitionCompare(Vertex vertexToCompare)
    {
        bool isEqual = false;
        for (int i = 0; i < vertices.Count; i++)
        {
            if (vertexToCompare.position == vertices[i].position)
            {
                return true;
            }
          
        }
        return isEqual;
    }

}
