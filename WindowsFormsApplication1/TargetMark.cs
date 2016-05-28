using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class TargetMark : GameObject
    {
        public int targetID;

        public TargetMark(int x, int y, Color Color, int targetID) : base(x, y, Color)
        {
            this.targetID = targetID;
        }

        public override void drawSelf(int x, int y, PaintEventArgs e, bool debug = false)
        {
            GraphicsExt.DrawCircle(e.Graphics, new Pen(Color.Red, pen.Width), X, Y, 32, GraphicsExt.FillType.Outline);

            if (debug)
            {
                e.Graphics.DrawString(objectName + " - id: " + id.ToString(), new Font(FontFamily.GenericSerif, 10), new SolidBrush(Color.Black), X, Y);
                e.Graphics.DrawString("\nTargetID: " + targetID.ToString(), new Font(FontFamily.GenericSerif, 9), new SolidBrush(Color.Black), X, Y);
            }

        }

        public void Update(List<GameObject> list)
        {
            GameObject go = list.Find(i => i.Id == targetID);

            if (go != null)
            {
                Mesh m = (Mesh)go;
                m.transform.X = X;
                m.transform.Y = Y;
            }
        }
    }
}
    

