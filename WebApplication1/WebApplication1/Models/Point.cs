using System;

namespace WebApplication1.Figures
{
    [Serializable()]
    public class Point
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }

        public Point(double coordinateX, double coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public override string ToString()
        {
            return "(" + CoordinateX + ", " + CoordinateY + ")";
        }
    }
}
