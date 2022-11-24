using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace WebApplication1.Figures
{
    [Serializable()]
    public class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(List<Point> points) : base(points)
        {
        }

        public Circle() : base()
        {

        }
        public void FindRadius()
        {
            Radius = Math.Sqrt((Points[0].CoordinateX - Points[1].CoordinateX)
                * (Points[0].CoordinateX - Points[1].CoordinateX) +
                 (Points[0].CoordinateY - Points[1].CoordinateY)
                 * (Points[0].CoordinateY - Points[1].CoordinateY));

        }

        public override void FindArea()
        {
            FindRadius();
            Area = Math.PI * Radius * Radius;
        }

        public override void FindPerimeter()
        {
            FindRadius();
            Perimeter = 2 * Math.PI * Radius;
        }

        public override void MoveFigure(double x, double y)
        {
            Center.CoordinateX = Center.CoordinateX + x;
            Center.CoordinateY = Center.CoordinateX + y;
        }

        public override void RotateFigure(double degree)
        {
            Console.WriteLine("There is no meaning of rotating circle)))");
        }

        public override void ScaleFigure(double scale)
        {
            Radius = Radius * scale;
            FindPerimeter();
            FindArea();
        }

        public override void FindCenter()
        {

            Center = new Point(Points[0].CoordinateX, Points[0].CoordinateY);

        }
        public override string ToString()
        {
            return $"{nameof(Circle)} Radius:{Radius} Area:{Area} Perimeter:{Perimeter} Center:({Center.CoordinateX};{Center.CoordinateY})";
        }

        public override string ToFileString()
        {
            return $"{nameof(Circle)}; Points:{Points[0]};{Points[1]}; Area:{Area} Perimeter:{Perimeter} Center:{Center}";
        }
    }
}

