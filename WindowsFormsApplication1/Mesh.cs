using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Mesh : GameObject
    {
        public Type type { get; set; }
        public List<Point> verticles;
        public List<int> dots; 

        public Mesh(int x, int y, Color Color, Type type, List<Point> verticles, List<int> dots) : base(x,y,Color)
        {
            this.type = type;
            verticles = new List<Point>();
            this.verticles = verticles;
            this.dots = dots;
        }

        public enum Type
        {
            Rectangle, Triangle, Circle, Polygon
        }

        public override void drawSelf(int x, int y, PaintEventArgs e)
        {
            switch(type)
            {
                case Type.Circle:
                    {
                        GraphicsExt.DrawCircle(e.Graphics, pen, verticles[0].X, verticles[0].Y, dots[0]);
                        break;
                    }
            }
        }

    }
}
