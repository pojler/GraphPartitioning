using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
	class Algorythm
	{
		public List<Graph> evaluate(Graph x)
		{
			List<Vertex> vertexlist = new List<Vertex>();
			List<Graph> returnList = new List<Graph>();
			int iterator = x.structure.Count;;
			iterator = iterator/2;


			Graph first = new Graph();

			for (int i = 0; i<iterator; i++)
			{
				first.addVertex(x.structure[i]);
			}

			//Console.WriteLine(first.toString());

			foreach(Vertex vertex in first.structure)
			{
				List<Edge> newedges = new List<Edge>();
				foreach (Edge edge in vertex.edges)
				{
					
					if (first.structure.Contains(edge.getGoal()))
					{
						newedges.Add(edge);
					}

				}
				vertex.edges = newedges;
			}
			Console.WriteLine();
			Console.WriteLine(first.toString());

			Graph second = new Graph();
			for (int i = iterator; i< x.structure.Count; i++)
			{
				second.addVertex(x.structure[i]);
			}

			foreach (Vertex vertex in second.structure)
			{
				List<Edge> newedges = new List<Edge>();
				foreach (Edge edge in vertex.edges)
				{

					if (second.structure.Contains(edge.getGoal()))
					{
						newedges.Add(edge);
					}

				}
				vertex.edges = newedges;
			}
			Console.WriteLine();
			Console.WriteLine(second.toString());

			return returnList;
		}
	}
}
