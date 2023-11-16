using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace StackQueue
{ 
    public class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        public int[,] adj;

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
        public void Load(string data)
        {
            TextReader reader = new StreamReader(data);
            int n = int.Parse(reader.ReadLine());
            adj = new int[n, n];
            for (int i = 0; i < n; i++)
            { 
                Vertex local = new Vertex();
                local.idx = i;
                vertices.Add(local);
            }
            string buffer = "";
            while ((buffer = reader.ReadLine()) != null)
            {
                int x = int.Parse(buffer.Split(' ')[0]);
                int y = int.Parse(buffer.Split(' ')[1]);
                int z = int.Parse(buffer.Split(' ')[2]);

                adj[x, y] = z;
                adj[y, x] = z;
                edges.Add(new Edge(buffer, vertices,adj));
            }

        }

        public void Draw(Graphics handler)
        {
            foreach (Edge edge in edges)
                edge.Draw(handler);
            foreach (Vertex vertex in vertices)
                vertex.Draw(handler);
        }

        public void Dispersion(PointF center, float radius)
        {
            float alpha = (float)(Math.PI * 2)/vertices.Count;
            for (int i = 0; i < vertices.Count; i++)
            {
                float x = center.X + (float)Math.Cos(i * alpha) * radius;
                float y = center.Y + (float)Math.Sin(i * alpha) * radius;
                vertices[i].location = new PointF(x, y);
            }
        }

        public List<Vertex> BFS(Vertex start)
        {
            List<Vertex> toR = new List<Vertex> ();
           
            MyQueue<Vertex> queue = new MyQueue<Vertex>();
            bool[] visited = new bool[vertices.Count];
            visited[start.idx] = true;
            queue.Push(start);
            while(!queue.IsEmpty())
            {
                Vertex t = queue.Pop();
                toR.Add(t);
                foreach(Edge edge in edges)
                {
                    if(edge.start == t || edge.end == t)
                    {
                        Vertex x;
                        if (edge.start == t)
                            x = edge.end;
                        else x = edge.start;

                        if (!visited[x.idx])
                        {
                            queue.Push(x);
                            visited[x.idx] = true; 
                        }
                    }
                }
            }
            return toR;

        }

        public List<Vertex> DFS(Vertex start)
        {
            List<Vertex> toR = new List<Vertex>();

            MyStack<Vertex> stack = new MyStack<Vertex>();
            bool[] visited = new bool[vertices.Count];
            visited[start.idx] = true;
            stack.Push(start);
            while (!stack.IsEmpty())
            {
                Vertex t = stack.Pop();
                toR.Add(t);
                foreach (Edge edge in edges)
                {
                    if (edge.start == t || edge.end == t)
                    {
                        Vertex x;
                        if (edge.start == t)
                            x = edge.end;
                        else x = edge.start;

                        if (!visited[x.idx])
                        {
                            stack.Push(x);
                            visited[x.idx] = true;
                        }
                    }
                }
            }
            return toR;
        }

        public List<Vertex> DFS_Rec(Vertex start)
        {
            //List<Vertex> toR = new List<Vertex>();

            bool[] visited = new bool[vertices.Count];
            values = new List<Vertex>();

            DFS_Rec_Utils(start,visited);

            return values;
        }

        public List<Vertex> values;
        private void DFS_Rec_Utils(Vertex start, bool[] visited)
        {
            visited[start.idx] = true;
            values.Add(start);

            foreach(Edge edge in edges)
            {
                if (edge.start == start || edge.end == start)
                {
                    Vertex newVertex;
                    if (edge.start == start)
                        newVertex = edge.end;
                    else newVertex = edge.start;

                    if (!visited[newVertex.idx])
                        DFS_Rec_Utils(newVertex,visited);
                }
            }
        }
        /// <summary>
        /// https://www.pbinfo.ro/articole/6135/algoritmul-lui-dijkstra
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public int[] DijkstraMinDistance(Vertex start)
        {
            //vectorul de distante se initializeaza cu valori foarte mari(infinit)
            int[] dist = new int[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
                dist[i] = int.MaxValue;

            MyQueue<Vertex> queue= new MyQueue<Vertex>();

            dist[start.idx] = 0;//distanta pana in nodul de start e 0, deoarece de acolo pornim
            queue.Push(start);

            while(!queue.IsEmpty())//cat timp avem noduri ce trebuiesc testate
            {
                Vertex current = queue.Pop();//extragem nodul curent din coada

                for (int j = 0; j < adj.GetLength(0); j++)//cautam conexiuni cu alte noduri
                {
                    if (adj[current.idx, j] > 0)//daca avem o conexiune cu un alt nod
                    {
                        Vertex neighbour = vertices[j];//il consideram vecin

                        //daca prin nodul curent gasim un drum mai scurt spre nodul vecin 
                        if ((dist[current.idx] + adj[current.idx, neighbour.idx]) < dist[neighbour.idx])
                        {
                            dist[neighbour.idx] = dist[current.idx] + adj[current.idx, neighbour.idx];//updatam distanta
                            queue.Push(neighbour);//adaugam nodul vecin in coada, pentru a fi vizitat ulterior
                        }
                    }
                }
                    
            }

            //daca sunt noduri in care nu se poate ajunge, le notam distantele cu -1
            for (int i = 0; i < dist.Length; i++)
                if (dist[i] == int.MaxValue)
                    dist[i] = -1;

            return dist;
        }
    }
}
