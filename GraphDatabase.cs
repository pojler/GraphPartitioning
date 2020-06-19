using System;
using System.Configuration;
using System.Xml;

public class GraphDatabase
{
	public GraphDatabase()
	{

	}
	
	public void bullshityreadfilemethode(string filename)
	{

		XmlTextReader reader = new XmlTextReader(filename);
		Console.Write(reader.Name);

	}

}
