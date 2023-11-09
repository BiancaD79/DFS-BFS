using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue
{
    public class Edge
    {
        public Vertex start;
        public Vertex end;

        public Edge(string data, List<Vertex> vertices)
        {
            string[] temp = data.Split(' ');
            int idx1 = int.Parse(temp[0]);
            int idx2 = int.Parse(temp[1]);
            foreach(Vertex vertex in vertices)
            {
                if (vertex.idx == idx1)
                    start = vertex;
                if (vertex.idx == idx2)
                    end = vertex;
            }
        }

        public void Draw(Graphics handler)
        {
            handler.DrawLine(Pens.Black, start.location, end.location);
        }

    }
}
