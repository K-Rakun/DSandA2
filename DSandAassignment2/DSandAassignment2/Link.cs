using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAassignment2
{
    public class Link
    {
        public string PointA { get; set; }
        public string PointB { get; set; }
        public int Distance { get; set; }
        public int MaxSpeed { get; set; }

        public Link(string a, string b, int distance, int speed)
        {
            PointA = a;
            PointB = b;
            Distance = distance;
            MaxSpeed = speed;
        }
    }
}
