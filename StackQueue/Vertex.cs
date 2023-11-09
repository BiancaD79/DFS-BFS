using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue
{
    public class Vertex
    {
        public int idx;
        public PointF location;

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, location.X - 5, location.Y - 5, 11, 11);
        }
    }
}
