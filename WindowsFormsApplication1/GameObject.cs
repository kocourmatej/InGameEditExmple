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
        public readonly int startX;
        public readonly int startY;
        public int id;
        public string objectName;
        public string instanceName;
        public int speed;
        public bool active = true;

        public GameObject(int x, int y, Color Color)
        {
            X = x;
            Y = y;
            this.Color = Color;
            pen = new Pen(Color, 2);
            Id = Form1.setId();
            startX = X;
            startY = Y;
            id = GameTime.assignID();
            instanceName = GameTime.assignInstanceName();
            objectName = Constants.gameObjectName;
            speed = 1;
        }

        public virtual void drawSelf(int x, int y, PaintEventArgs e, bool debug = false)
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
