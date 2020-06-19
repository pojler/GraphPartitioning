using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Graphs
{

	class Program
	{
		static void Main(string[] args)
		{
			Graph g = new Graph();
			Vertex v1 = new Vertex("v1");
			Vertex v2 = new Vertex("v2");
			Vertex v3 = new Vertex("v3");
			Vertex v4 = new Vertex("v4");
			v1.addEdge(v2, 30);
			v1.addEdge(v3, 20);
	
			v2.addEdge(v4, 10);
			v3.addEdge(v4, 5);
			v4.addEdge(v1, 100);
			v1.addEdge(v4, 10);
			g.addVertex(v1);
			g.addVertex(v2);
			g.addVertex(v3);
			g.addVertex(v4);
			Console.WriteLine(g.toString());
			//Algorythm a = new Algorythm();
			//a.evaluate(g);
			GreedyMCAlgorithm x = new GreedyMCAlgorithm();
			List<Graph> list = x.evaluate(g);
			Console.WriteLine("Graph1");
			Console.WriteLine(list[1].toString());
			Console.WriteLine("Graph2");
			Console.WriteLine(list[0].toString());
			GraphDatabase gd = new GraphDatabase();
			Console.WriteLine("///////////////////////////////////");
			Graph  loaded = gd.generateGraphfromGraphML("test.xml");
			Console.WriteLine(loaded.toString());
			List<Graph> list2 = x.evaluate(loaded);
			Console.WriteLine("Graph1");
			Console.WriteLine(list2[1].toString());
			Console.WriteLine("Graph2");
			Console.WriteLine(list2[0].toString());


		}
	}
}
	

