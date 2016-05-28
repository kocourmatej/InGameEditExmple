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
        public static List<GameObject> gameObjects;
        private static int idHelper = 0;
        GameObject lastObjectSelected = null;
        private int activeStep = 0;
        const int activeStepDuration = 1;
        
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

            Mesh m = new Mesh(200, 200, Color.Black, Mesh.Type.Circle, new List<vec3>() { new vec3(200, 200, 32) });
            gameObjects.Add(m);

            TargetMark tm = new TargetMark(400, 400, Color.Red, m.id);
            gameObjects.Add(tm);
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
                    m.drawSelf(m.X, m.Y, e, true);
                }
                else
                {
                    g.drawSelf(g.X, g.Y, e, true);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            timer1.Interval = 1;

            activeStep++;

            if (activeStep >= activeStepDuration)
            {
                activeStep = 0;
                foreach(GameObject go in gameObjects)
                {
                    if (go is Mesh)
                    {
                        Mesh m = (Mesh)go;
                        if (m.active == false)
                        {
                            m.active = true;
                        }
                        else if (!m.selected)
                        {
                            m.Update();
                            if (m == lastObjectSelected) { richTextBox1.Text = m.SetToEdit(); }
                        }
                      
                    }

                    if (go is TargetMark)
                    {
                        TargetMark tm = (TargetMark)go;
                        tm.Update(gameObjects);
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool setActive = true;
                foreach (GameObject go in gameObjects)
                {
                    if (go is Mesh)
                    {
                        Mesh m = (Mesh)go;
                        if (m.Collision(new vec2(e.X, e.Y))) { if (setActive) { m.selected = !m.selected; richTextBox1.Text = m.SetToEdit(); if (m.selected) { lastObjectSelected = m; } setActive = false; } }
                        else { m.selected = false; }

                    }
                }

                if (setActive) { try { Mesh m = (Mesh)lastObjectSelected; richTextBox1.Text = m.SetToEdit(); } catch { } }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (GameObject go in gameObjects)
                {
                    if (go is Mesh)
                    {
                        Mesh m = (Mesh)go;
                        if (m.selected)
                         {
                            m.X = e.X;
                            m.Y = e.Y;
                            richTextBox1.Text = m.SetToEdit();
                            m.active = false;
                         }
                    }
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch(treeView1.SelectedNode.Text)
            {
                case "Circle":
                    {
                        Mesh m = new Mesh(200, 200, Color.Red, Mesh.Type.Circle, new List<vec3>() { new vec3(200, 200, GameTime.random.Next(32,96)) });
                        gameObjects.Add(m);
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                Mesh m = (Mesh)lastObjectSelected;

                foreach (string line in richTextBox1.Lines)
                {
                    int val = Convert.ToInt32(MathHelper.digitsFromString(line));

                    switch (m.type)
                    {
                        case Mesh.Type.Circle:
                            {
                                if (i == 1) { m.X = val; }
                                if (i == 2) { m.Y = val; }
                                if (i == 3) { m.verticles[0].Z = val; }
                                if (i == 4) { m.transform.X = val; }
                                if (i == 5) { m.transform.Y = val; }
                                break;
                            }
                    }                 
                    
                    i++;
                }
            }
            catch { }
        }
    }
}
