using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Triangulation : MonoBehaviour
{
	public static List<Triangle> TriangulateConvexPolygon(List<Vertex> convexHullpoints)
	{
		List<Triangle> triangles = new List<Triangle>();

		for (int i = 2; i < convexHullpoints.Count; i++)
		{
			Vertex a = convexHullpoints[0];
			Vertex b = convexHullpoints[i - 1];
			Vertex c = convexHullpoints[i];

			triangles.Add(new Triangle(a, b, c));
		}

		return triangles;
	}


	public static List<Triangle> TriangulateConcavePolygon(List<Vector3> points)
	{
		//The list with triangles the method returns
		List<Triangle> triangles = new List<Triangle>();

		//If we just have three points, then we dont have to do all calculations
		if (points.Count == 3)
		{
			triangles.Add(new Triangle(points[0], points[1], points[2]));

			return triangles;
		}



		//Step 1. Store the vertices in a list and we also need to know the next and prev vertex
		List<Vertex> vertices = new List<Vertex>();

		for (int i = 0; i < points.Count; i++)
		{
			vertices.Add(new Vertex(points[i]));
		}

		//Find the next and previous vertex
		for (int i = 0; i < vertices.Count; i++)
		{
			int nextPos = Geometry.ClampListIndex(i + 1, vertices.Count);

			int prevPos = Geometry.ClampListIndex(i - 1, vertices.Count);

			vertices[i].prevVertex = vertices[prevPos];

			vertices[i].nextVertex = vertices[nextPos];
		}



		//Step 2. Find the reflex (concave) and convex vertices, and ear vertices
		for (int i = 0; i < vertices.Count; i++)
		{
			CheckIfReflexOrConvex(vertices[i]);
		}

		//Have to find the ears after we have found if the vertex is reflex or convex
		List<Vertex> earVertices = new List<Vertex>();

		for (int i = 0; i < vertices.Count; i++)
		{
			IsVertexEar(vertices[i], vertices, earVertices);
		}



		//Step 3. Triangulate!
		while (true)
		{
			//This means we have just one triangle left
			if (vertices.Count == 3)
			{
				//The final triangle
				triangles.Add(new Triangle(vertices[0], vertices[0].prevVertex, vertices[0].nextVertex));

				break;
			}

			//Make a triangle of the first ear
			Vertex earVertex = earVertices[0];

			Vertex earVertexPrev = earVertex.prevVertex;
			Vertex earVertexNext = earVertex.nextVertex;

			Triangle newTriangle = new Triangle(earVertex, earVertexPrev, earVertexNext);

			triangles.Add(newTriangle);

			//Remove the vertex from the lists
			earVertices.Remove(earVertex);

			vertices.Remove(earVertex);

			//Update the previous vertex and next vertex
			earVertexPrev.nextVertex = earVertexNext;
			earVertexNext.prevVertex = earVertexPrev;

			//...see if we have found a new ear by investigating the two vertices that was part of the ear
			CheckIfReflexOrConvex(earVertexPrev);
			CheckIfReflexOrConvex(earVertexNext);

			earVertices.Remove(earVertexPrev);
			earVertices.Remove(earVertexNext);

			IsVertexEar(earVertexPrev, vertices, earVertices);
			IsVertexEar(earVertexNext, vertices, earVertices);
		}

		//Debug.Log(triangles.Count);

		return triangles;
	}



	//Check if a vertex if reflex or convex, and add to appropriate list
	private static void CheckIfReflexOrConvex(Vertex v)
	{
		v.isReflex = false;
		v.isConvex = false;

		//This is a reflex vertex if its triangle is oriented clockwise
		Vector2 a = v.prevVertex.GetPos2D_XZ();
		Vector2 b = v.GetPos2D_XZ();
		Vector2 c = v.nextVertex.GetPos2D_XZ();

		if (Geometry.IsTriangleOrientedClockwise(a, b, c))
		{
			v.isReflex = true;
		}
		else
		{
			v.isConvex = true;
		}
	}



	//Check if a vertex is an ear
	private static void IsVertexEar(Vertex v, List<Vertex> vertices, List<Vertex> earVertices)
	{
		//A reflex vertex cant be an ear!
		if (v.isReflex)
		{
			return;
		}

		//This triangle to check point in triangle
		Vector2 a = v.prevVertex.GetPos2D_XZ();
		Vector2 b = v.GetPos2D_XZ();
		Vector2 c = v.nextVertex.GetPos2D_XZ();

		bool hasPointInside = false;

		for (int i = 0; i < vertices.Count; i++)
		{
			//We only need to check if a reflex vertex is inside of the triangle
			if (vertices[i].isReflex)
			{
				Vector2 p = vertices[i].GetPos2D_XZ();

				//This means inside and not on the hull
				if (Geometry.IsPointInTriangle(a, b, c, p))
				{
					hasPointInside = true;

					break;
				}
			}
		}

		if (!hasPointInside)
		{
			earVertices.Add(v);
		}
	}

	public static class TriangleSplittingAlgorithm
	{
		public static List<Triangle> TriangulatePoints(List<Vertex> points)
		{
			//Generate the convex hull - will also remove the points from points list which are not on the hull
			List<Vertex> pointsOnConvexHull = JarvisMarchAlgorithm.GetConvexHull(points);

			//Triangulate the convex hull
			List<Triangle> triangles = TriangulateConvexPolygon(pointsOnConvexHull);

			//Add the remaining points and split the triangles
			for (int i = 0; i < points.Count; i++)
			{
				Vertex currentPoint = points[i];

				//2d space
				Vector2 p = new Vector2(currentPoint.position.x, currentPoint.position.z);

				//Which triangle is this point in?
				for (int j = 0; j < triangles.Count; j++)
				{
					Triangle t = triangles[j];

					Vector2 p1 = new Vector2(t.v1.position.x, t.v1.position.z);
					Vector2 p2 = new Vector2(t.v2.position.x, t.v2.position.z);
					Vector2 p3 = new Vector2(t.v3.position.x, t.v3.position.z);

					if (Geometry.IsPointInTriangle(p1, p2, p3, p))
					{
						//Create 3 new triangles
						Triangle t1 = new Triangle(t.v1, t.v2, currentPoint);
						Triangle t2 = new Triangle(t.v2, t.v3, currentPoint);
						Triangle t3 = new Triangle(t.v3, t.v1, currentPoint);

						//Remove the old triangle
						triangles.Remove(t);

						//Add the new triangles
						triangles.Add(t1);
						triangles.Add(t2);
						triangles.Add(t3);

						break;
					}
				}
			}

			return triangles;
		}
	}

	public static List<Triangle> TriangulatePoints(List<Vertex> points)
	{
		List<Triangle> triangles = new List<Triangle>();

		//Sort the points along x-axis
		//OrderBy is always soring in ascending order - use OrderByDescending to get in the other order
		points = points.OrderBy(n => n.position.x).ToList();

		//The first 3 vertices are always forming a triangle
		Triangle newTriangle = new Triangle(points[0].position, points[1].position, points[2].position);

		triangles.Add(newTriangle);

		//All edges that form the triangles, so we have something to test against
		List<Edge> edges = new List<Edge>();

		edges.Add(new Edge(newTriangle.v1, newTriangle.v2));
		edges.Add(new Edge(newTriangle.v2, newTriangle.v3));
		edges.Add(new Edge(newTriangle.v3, newTriangle.v1));

		//Add the other triangles one by one
		//Starts at 3 because we have already added 0,1,2
		for (int i = 3; i < points.Count; i++)
		{
			Vector3 currentPoint = points[i].position;

			//The edges we add this loop or we will get stuck in an endless loop
			List<Edge> newEdges = new List<Edge>();

			//Is this edge visible? We only need to check if the midpoint of the edge is visible 
			for (int j = 0; j < edges.Count; j++)
			{
				Edge currentEdge = edges[j];

				Vector3 midPoint = (currentEdge.v1.position + currentEdge.v2.position) / 2f;

				Edge edgeToMidpoint = new Edge(currentPoint, midPoint);

				//Check if this line is intersecting
				bool canSeeEdge = true;

				for (int k = 0; k < edges.Count; k++)
				{
					//Dont compare the edge with itself
					if (k == j)
					{
						continue;
					}

					if (AreEdgesIntersecting(edgeToMidpoint, edges[k]))
					{
						canSeeEdge = false;

						break;
					}
				}

				//This is a valid triangle
				if (canSeeEdge)
				{
					Edge edgeToPoint1 = new Edge(currentEdge.v1, new Vertex(currentPoint));
					Edge edgeToPoint2 = new Edge(currentEdge.v2, new Vertex(currentPoint));

					newEdges.Add(edgeToPoint1);
					newEdges.Add(edgeToPoint2);

					Triangle newTri = new Triangle(edgeToPoint1.v1, edgeToPoint1.v2, edgeToPoint2.v1);

					triangles.Add(newTri);
				}
			}


			for (int j = 0; j < newEdges.Count; j++)
			{
				edges.Add(newEdges[j]);
			}
		}


		return triangles;
	}



	private static bool AreEdgesIntersecting(Edge edge1, Edge edge2)
	{
		Vector2 l1_p1 = new Vector2(edge1.v1.position.x, edge1.v1.position.z);
		Vector2 l1_p2 = new Vector2(edge1.v2.position.x, edge1.v2.position.z);

		Vector2 l2_p1 = new Vector2(edge2.v1.position.x, edge2.v1.position.z);
		Vector2 l2_p2 = new Vector2(edge2.v2.position.x, edge2.v2.position.z);

		bool isIntersecting = Geometry.AreLinesIntersecting(l1_p1, l1_p2, l2_p1, l2_p2, true);

		return isIntersecting;
		
	}
}
