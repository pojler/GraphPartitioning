using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
	public class Edge
	{
		private Vertex goal;
		private double cost;
		public Edge(Vertex goal, double cost)
		{
			this.goal = goal;
			this.cost = cost;
		}
		public Vertex getGoal()
		{
			return goal;
		}
		public double getCost()
		{
			return cost;
		}

	}
	public class Vertex
	{
		private string name;
		public List<Edge> edges;
		public Vertex(string name)
		{
			this.name = name;
			edges = new List<Edge>();
		}
		public void addEdge(Vertex goal, double value)
		{
			edges.Add(new Edge(goal, value));
		}
		public string getName()
		{
			return name;
		}
		public string toString()
		{
			string ret = name + ":\n";
			foreach (Edge e in edges)
			{
				ret += "\t" + e.getGoal().getName() + " -> " + e.getCost() + "\n";
			}
			return ret;
		}


	}
	public  class Graph
	{

		public List<Vertex> structure;

		public Graph()
		{
			structure = new List<Vertex>();
		}

		private Vertex findVertexByName(string searchingname)
		{
			foreach (Vertex vertex in structure)
			{
				if (vertex.getName() == searchingname)
				{
					return vertex;
				}
			}
			return null;
		}

		public void addVertex(Vertex vertex)
		{
			structure.Add(vertex);
		}

		public void addEdge(string source, string destination, double value)
		{
			findVertexByName(source).addEdge(findVertexByName(destination), value);
		}



		public string toString()
		{
			string ret = "";
			foreach (Vertex v in structure)
			{
				ret += v.toString();
			}

			return ret;
		}
	}
}
