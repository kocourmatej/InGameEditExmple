using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public int Id { get; set; }
        public Pen pen;

        public GameObject(int x, int y, Color Color)
        {
            X = x;
            Y = y;
            this.Color = Color;
            pen = new Pen(Color, 2);
            Id = Form1.setId();
        }

        public virtual void drawSelf(int x, int y, PaintEventArgs e)
        {
            List<Point> verticles = new List<Point>();
            Point point = new Point(x, y);
            Point point2 = new Point(x+100, y);
            verticles.Add(point);
            verticles.Add(point2);

            e.Graphics.DrawPolygon(pen, verticles.ToArray());
            e.Graphics.DrawRectangle(pen, new Rectangle(new Point(300, 300), new Size(32,32)));
        }
    }
}
