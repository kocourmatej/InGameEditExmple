using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public List<GameObject> gameObjects;
        private static int idHelper = 0;

        public static int setId()
        {
            idHelper++;
            return idHelper;
        }

        public Form1()
        {
            InitializeComponent();
            gameObjects = new List<GameObject>();

            GameObject go = new GameObject(300, 300, Color.Black);
            gameObjects.Add(go);

            int size = 32;
            Mesh m = new Mesh(200, 200, Color.Black, Mesh.Type.Circle, new List<Point>() { new Point(200, 200) }, new List<int>() { size });
            gameObjects.Add(m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(GameObject g in gameObjects)
            {

                if (g is Mesh)
                {
                    Mesh m = (Mesh)g;
                    m.drawSelf(m.X, m.Y, e);
                }
                else
                {
                    g.drawSelf(g.X, g.Y, e);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            timer1.Interval = 1;
        }
    }
}
