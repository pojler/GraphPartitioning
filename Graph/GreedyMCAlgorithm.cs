using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
	class GreedyMCAlgorithm
	{
		public GreedyMCAlgorithm()
		{

		}

		public List<Graph> evaluate(Graph x)
		{
			List <Graph> graphlist = new List<Graph>();
			Graph localcopy = x;
			Graph d = new Graph();
			double maxcutcost = 0, cutcost = 0, negativecost = 0;
			Vertex cutted = null;
			bool Flag = true;

			while (Flag)
			{
				cutted = null;
				Flag = false;
				foreach(Vertex vertex in localcopy.structure)
				{
					foreach(Edge edge in vertex.edges)
					{
						cutcost += edge.getCost();
					}
					foreach(Vertex v in d.structure)
					{
						foreach(Edge e in v.edges)
						{
							if(e.getGoal() == vertex)
							{

								negativecost += e.getCost();
							
							}
						}
					}
					if(cutcost - negativecost >= maxcutcost)
					{
						cutted = vertex;
						maxcutcost = cutcost;
						Flag = true;
					}
					negativecost = 0;
					cutcost = 0;
				}
				if(cutted != null)
				{
					d.addVertex(cutted);
					localcopy.structure.Remove(cutted);
				}
			
				maxcutcost = 0;
				

			}
			
			foreach (Vertex vertex in localcopy.structure)
			{

				List<Edge> newedges = new List<Edge>();

				foreach (Edge edge in vertex.edges)
				{
					if (localcopy.structure.Contains(edge.getGoal()))
					{
						newedges.Add(edge);
					}
				}
				vertex.edges = newedges;
			}
			foreach (Vertex vertex in d.structure)
			{

				List<Edge> newedges = new List<Edge>();

				foreach (Edge edge in vertex.edges)
				{
					if (d.structure.Contains(edge.getGoal()))
					{
						newedges.Add(edge);
					}
				}
				vertex.edges = newedges;
			}

			graphlist.Add(localcopy);
			graphlist.Add(d);
			return graphlist;
		}

	}
}
