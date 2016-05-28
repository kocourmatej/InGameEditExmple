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
        public List<vec3> verticles;
        public Rectangle boundingBox;
        public bool selected;
        public vec3 transform;

        public Mesh(int x, int y, Color Color, Type type, List<vec3> verticles) : base(x,y,Color)
        {
            this.type = type;
            this.verticles = verticles;
            selected = false;
            objectName = Constants.meshObjectName;
            transform = new vec3(x, y, (int)verticles[0].Z);
        }

        public enum Type
        {
            Rectangle, Triangle, Circle, Polygon
        }

        public override void drawSelf(int x, int y, PaintEventArgs e, bool debug = false)
        {
            switch(type)
            {
                case Type.Circle:
                    {
                        if (!selected) { GraphicsExt.DrawCircle(e.Graphics, pen, X, Y, (float)verticles[0].Z); }
                        else { GraphicsExt.DrawCircle(e.Graphics, new Pen(Color.Green, pen.Width), X, Y, (float)verticles[0].Z, GraphicsExt.FillType.Outline); }

                        if (debug)
                        {
                            e.Graphics.DrawString(objectName + " - id: " + id.ToString(), new Font(FontFamily.GenericSerif, 10), new SolidBrush(Color.Black), (float)(X - verticles[0].Z), (float)(Y - verticles[0].Z)-16);
                            e.Graphics.DrawString("X: " + X.ToString() + "\nY: " + Y.ToString(), new Font(FontFamily.GenericSerif, 9), new SolidBrush(Color.Black), (float)(X - verticles[0].Z/2), (float)(Y - verticles[0].Z/2));
                        }
                        break;
                    }
            }
        }

        public bool Collision(vec2 point)
        {
            switch(type)
            {
                case Type.Circle:
                    {
                        if (X >= point.X - (verticles[0].Z) && X <= point.X + (verticles[0].Z) && Y >= point.Y - (verticles[0].Z) && Y <= point.Y +(verticles[0].Z))
                        {
                            return true;
                        }
                        break;
                    }
            }

            return false;
        }

        public void Update()
        {
            switch (type)
            {
                case Type.Circle:
                    {
                        if (X != transform.X && Y != transform.Y)
                        {
                            vec2 targetPoint = MathHelper.MovePointTowards(new vec2(X, Y), new vec2(transform.X, transform.Y), speed);
                            X = (int)targetPoint.X;
                            Y = (int)targetPoint.Y;
                        }
                        break;
                    }
            }

        }

        public string SetToEdit()
        {
            string text = objectName + " (ID: " + id.ToString() + ")";

            switch (type)
            {
                case Type.Circle:
                    {
                        text = text + "\nX: " + X.ToString();
                        text = text + "\nY: " + Y.ToString();
                        text = text + "\nR: " + verticles[0].Z.ToString();
                        text = text + "\ntX: " + transform.X;
                        text = text + "\ntY: " + transform.Y;
                        text = text + "\ntZ: " + transform.Z;
                        break;
                    }

            }

            return text;
        }
    }
}
