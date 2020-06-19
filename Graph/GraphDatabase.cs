using System;
using System.Configuration;
using System.Xml;
using System.Threading;
using System.Globalization;


namespace Graphs
{
	public class GraphDatabase
	{
		public GraphDatabase()
		{

		}

		public Graph generateGraphfromGraphML(string filename)
		{

			Graph newGraph = new Graph();
			XmlDocument xml = new XmlDocument();
			xml.Load(filename);
			XmlNodeList nodes = xml.GetElementsByTagName("node");
			XmlNodeList edges = xml.GetElementsByTagName("edge");
			int nodesIndex = 0;
			int edgesIndex = 0;
			CultureInfo culture = new CultureInfo("us");

			while (true)
			{
				if (nodes.Item(nodesIndex) == null)
				{
					break;
				}
				else
				{
					newGraph.addVertex(new Vertex(nodes.Item(nodesIndex).Attributes.GetNamedItem("id").InnerText));
					//Console.WriteLine(nodes.Item(nodesIndex).Attributes.GetNamedItem("id").InnerText);
				}
				nodesIndex++;

			}

			while (true)
			{
				if (edges.Item(edgesIndex) == null)
				{
					break;
				}
				else
				{
					newGraph.addEdge(edges.Item(edgesIndex).Attributes.GetNamedItem("source").InnerText, edges.Item(edgesIndex).Attributes.GetNamedItem("target").InnerText,
						Double.Parse(edges.Item(edgesIndex).FirstChild.InnerText, culture));
					//Console.WriteLine(edges.Item(edgesIndex).Attributes.GetNamedItem("source").InnerText + " -> " + edges.Item(edgesIndex).Attributes.GetNamedItem("target").InnerText
						//+ " at value " + edges.Item(edgesIndex).FirstChild.InnerText);
				}
				edgesIndex++;

			}
			//Console.WriteLine(newGraph.toString());

			return newGraph;
		}

	}
}