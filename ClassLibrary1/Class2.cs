using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Graph;

namespace ClassLibrary1
{
    public static class FileGraph
    {
        static int FindInd(int x, int y, Graphs graph)
        {
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (x == graph.Nodes[i].x && y == graph.Nodes[i].y)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void SaveGraph(string filename, Graphs graph)
        {
            FileStream stream = new FileStream(filename, FileMode.CreateNew);
            BinaryWriter binaryWriter = new BinaryWriter(stream);
            binaryWriter.Write(graph.Nodes.Count);
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                binaryWriter.Write(graph.Nodes[i].x);
                binaryWriter.Write(graph.Nodes[i].y);
            }
            binaryWriter.Write(graph.Edges.Count);
            for (int i = 0; i < graph.Edges.Count; i++)
            {
                binaryWriter.Write(FindInd(graph.Edges[i].first.x, graph.Edges[i].first.y, graph));
                binaryWriter.Write(FindInd(graph.Edges[i].second.x, graph.Edges[i].second.y, graph));
            }
            binaryWriter.Flush();
            binaryWriter.Close();
            stream.Close();
        }
        public static Graphs OpenGraph(string filename)
        {
            FileStream stream = new FileStream(filename, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(stream);
            Graphs graph = new Graphs();
            int n = binaryReader.ReadInt32();
            for (int i = 0; i < n; i++)
            {
                graph.AddNode(binaryReader.ReadInt32(), binaryReader.ReadInt32());
            }
            n = binaryReader.ReadInt32();
            for (int i = 0; i < n; i++)
            {
                graph.AddEdge(graph.Nodes[binaryReader.ReadInt32()], graph.Nodes[binaryReader.ReadInt32()]);
            }
            binaryReader.Close();
            stream.Close();
            return graph;
        }
    }
}
