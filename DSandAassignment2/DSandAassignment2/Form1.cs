using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSandAassignment2
{
    public partial class Form1 : Form
    {
        static List<Link> links = new List<Link>();
        public Form1()
        {
            
            Data();
            InitializeComponent();
        }

        public static void Data()
        {

            links.Add(new Link("Varna", "Dobrich", 50, 60));
            links.Add(new Link("Varna", "Burgas", 110, 90));
            links.Add(new Link("Varna", "Shumen", 90, 70));
            links.Add(new Link("Dobrich", "Silistra", 90, 70));
            links.Add(new Link("Silistra", "Shumen", 110, 90));
            links.Add(new Link("Silistra", "Razgrad", 120, 100));
            links.Add(new Link("Silistra", "Veliko Tyrnovo", 230, 120));
            links.Add(new Link("Shumen", "Razgrad", 50, 60));
            links.Add(new Link("Shumen", "Tyrgowishte", 40, 60));
            links.Add(new Link("Shumen", "Sliven", 130, 90));
            links.Add(new Link("Tyrgowishte", "Razgrad", 40, 60));
            links.Add(new Link("Tyrgowishte", "Veliko Tyrnovo", 100, 80));
            links.Add(new Link("Tyrgowishte", "Sliven", 110, 90));
            links.Add(new Link("Veliko Tyrnovo", "Kazanlyk", 100, 90));
            links.Add(new Link("Veliko Tyrnovo", "Sliven", 110, 90));
            links.Add(new Link("Veliko Tyrnovo", "Razgrad", 120, 100));
            links.Add(new Link("Kazanlyk", "Sliven", 80, 70));
            links.Add(new Link("Kazanlyk", "Stara Zagora", 30, 60));
            links.Add(new Link("Stara Zagora", "Yambol", 90, 70));
            links.Add(new Link("Yambol", "Sliven", 30, 60));
            links.Add(new Link("Yambol", "Burgas", 90, 80));
            links.Add(new Link("Sliven", "Burgas", 110, 90));

        }

        public static Dictionary<string, int> GetNeighbors(string name)
        {
            Dictionary<string, int> temp = new Dictionary<string, int>();

            foreach (var link in links)
            {
                if (link.PointA == name)
                {
                    temp.Add(link.PointB, link.Distance / link.MaxSpeed);
                }
                if (link.PointB == name)
                {
                    temp.Add(link.PointA, link.Distance / link.MaxSpeed);
                }
            }
            return temp;
        }

        public static string FindPath(string start, string end)
        {
            List<string> paths = new List<string>();
            List<string> visited = new List<string>();
            string delimiter = "; ";
            paths.Add(start + delimiter);
            visited.Add(start);
            Queue<string> q = new Queue<string>();
            q.Enqueue(start);
            while (q.Count > 0)
            {
                string node = q.Dequeue();

                Dictionary<string, int> neighbors = GetNeighbors(node);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.Key == end)
                    {
                        foreach (string path in paths)
                        {
                            if (path.EndsWith(node + delimiter))
                                return path + end;
                        }
                    }
                }

                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor.Key))
                    {
                        q.Enqueue(neighbor.Key);
                        visited.Add(neighbor.Key);
                        for (int i = 0; i < paths.Count; i++)
                        {
                            if (paths[i].EndsWith(node + delimiter))
                            {
                                paths.Add(paths[i] + neighbor.Key + delimiter);
                            }
                        }
                    }
                }
            }

            return null;
        }

        void DrawLines(object sender, EventArgs e)
        {
            Graphics gr = CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Label label1 = null;
            Label label2 = null;
            List<Label> labels = new List<Label>()
            {
                BurgasNode,
                DobrichNode,
                KazanlykNode,
                RazgradNode,
                ShumenNode,
                SilistraNode,
                SlivenNode,
                StaraZagoraNode,
                TyrgowishteNode,
                VarnaNode,
                VelikoTyrnovoNode,
                YambolNode
            };


            foreach (var link in links)
            {
                foreach(Label label in labels)
                {
                    if(link.PointA == label.Text)
                    {
                        label1 = label;
                    }
                    if(link.PointB == label.Text)
                    {
                        label2 = label;
                    }
                }
                gr.DrawLine(pen, label1.Location.X, label1.Location.Y, label2.Location.X, label2.Location.Y);
            }

        }

        void FindPathButtonPress(object sender, EventArgs e)
        {
            string start = StartCity.Text;
            string end = EndCity.Text;
            string result = FindPath(start, end);

            ResultBox.Text = result;

        }

    }
}
