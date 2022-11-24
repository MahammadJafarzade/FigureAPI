using System;
using System.Drawing;

namespace WebApplication1.Figures
{
    [Serializable()]
    public abstract class Figure
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public List<Point> Points { get; set; }
        public Point Center { get; set; }
        public int Id { get; set; }
        public static int Counter = 0;

        public Figure(List<Point> points)
        {
            Points = points;
            FindCenter();
            FindPerimeter();
            FindArea();
            Counter = ++Counter;
            Id = Counter;
        }

        public Figure()
        {
            Points = new List<Point>();
            Area = 0;
            Center = null;
            Perimeter = 0;
            Counter = ++Counter;
            Id = Counter;
        }
        public abstract void FindArea();
        public abstract void FindPerimeter();
        public abstract void FindCenter();
        public abstract void MoveFigure(double x, double y);
        public abstract void RotateFigure(double degree);
        public abstract void ScaleFigure(double scale);
        public abstract override string ToString();
        public abstract string ToFileString();

    }
}

