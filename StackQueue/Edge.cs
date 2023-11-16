using System.Collections.Generic;
using System.Drawing;


namespace StackQueue
{
    public class Edge
    {
        public Vertex start;
        public Vertex end;
        public int weight;

        public Edge(string data, List<Vertex> vertices,int[,] adj)
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
            weight= adj[start.idx,end.idx];
        }

        public void Draw(Graphics handler)
        {
            handler.DrawLine(Pens.Black, start.location, end.location);
            PointF midPoint = new PointF((start.location.X + end.location.X) / 2, (start.location.Y + end.location.Y) / 2);
            handler.DrawString(weight.ToString(), new Font("Arial", 15), Brushes.Blue, midPoint);
        }

    }
}
