using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Figures
{
    [Serializable()]
    public class Rectangle : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public Rectangle(List<Point> points) : base(points)
        {
        }
        public Rectangle() : base()
        {

        }

        public void FindSides()
        {
            SideA = Math.Abs(Points[0].CoordinateY - Points[1].CoordinateY);
            SideB = Math.Abs(Points[0].CoordinateX - Points[3].CoordinateX);
        }

        public override void FindArea()
        {
            FindSides();
            Area = SideA * SideB;
        }


        public override void FindPerimeter()
        {
            FindSides();
            Perimeter = 2 * (SideA + SideB);
        }

        public override void MoveFigure(double x, double y)
        {
            foreach (var p in Points)
            {
                p.CoordinateX += x;
                p.CoordinateY += y;
            }
        }

        public override void RotateFigure(double degree)
        {
            foreach (var p in Points)
            {
                p.CoordinateX = p.CoordinateX * Math.Cos(degree) - p.CoordinateY * Math.Sin(degree);
                p.CoordinateY = p.CoordinateY * Math.Cos(degree) + p.CoordinateX * Math.Sin(degree);
            }
        }

        public override void ScaleFigure(double scale)
        {
            foreach (var p in Points)
            {
                p.CoordinateX = Center.CoordinateX - scale * (Center.CoordinateX - p.CoordinateX);
                p.CoordinateY = Center.CoordinateY - scale * (Center.CoordinateY - p.CoordinateY);
            }
            FindPerimeter();
            FindArea();
        }

        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.CoordinateX;
                sumY += p.CoordinateY;
            }
            Center = new Point(sumX / 4, sumY / 4);
        }
        public override string ToString()
        {
            return $"{nameof(Rectangle)} Sides:{SideA},{SideB} Area:{Area} Perimeter:{Perimeter} Center:({Center.CoordinateX};{Center.CoordinateY})";
        }

        public override string ToFileString()
        {
            return $"{nameof(Rectangle)}; Points:{Points[0]};{Points[1]};{Points[2]};{Points[3]}; Area:{Area}, Perimeter:{Perimeter}, Center:{Center}";
        }

    }
}

