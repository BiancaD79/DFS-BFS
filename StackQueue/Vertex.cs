using System.Drawing;

namespace StackQueue
{
    public class Vertex
    {
        public int idx;
        public PointF location;

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, location.X - 5, location.Y - 5, 11, 11);
            handler.DrawString(idx.ToString(), new Font("Arial", 20),Brushes.Red,location);
        }
    }
}
