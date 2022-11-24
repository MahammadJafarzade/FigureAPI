using System;
using System.Reflection.Metadata;

namespace WebApplication1.Figures
{
    [Serializable()]
    public class Square : Figure
    {
        public double Side;

        public Square(List<Point> points) : base(points)
        {
        }

        public Square() : base()
        {

        }

        public void FindSide()
        {
            Side = Math.Abs(Points[0].CoordinateY - Points[1].CoordinateY);

        }

        public override void FindArea()
        {
            FindSide();
            Area = Side * Side;
        }

        public override void FindPerimeter()
        {
            FindSide();
            Perimeter = 4 * Side;
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
            return $"{nameof(Square)} Side:{Side} Area:{Area} Perimeter:{Perimeter} Center:({Center.CoordinateX};{Center.CoordinateY})";
        }

        public override string ToFileString()
        {
            return $"{nameof(Square)}; Points:{Points[0]};{Points[1]};{Points[2]};{Points[3]}; Area:{Area} Perimeter:{Perimeter} Center:{Center}";
        }
    }
}

