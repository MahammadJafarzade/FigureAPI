using System;

namespace WebApplication1.Figures
{
    [Serializable()]
    public class Triangle : Figure
    {
        [field: NonSerialized()]
        public double SideA { get; set; }
        [field: NonSerialized()]
        public double SideB { get; set; }
        [field: NonSerialized()]
        public double SideC { get; set; }


        public Triangle(List<Point> points) : base(points)
        {
        }

        public Triangle() : base()
        {

        }

        public void FindSides()
        {
            double lengthX, lengthY;
            lengthX = Points[1].CoordinateX - Points[0].CoordinateX;
            lengthY = Points[1].CoordinateY - Points[0].CoordinateY;
            SideA = Math.Sqrt(lengthX * lengthX + lengthY * lengthY);

            lengthX = Points[2].CoordinateX - Points[1].CoordinateX;
            lengthY = Points[2].CoordinateY - Points[1].CoordinateY;
            SideB = Math.Sqrt(lengthX * lengthX + lengthY * lengthY);

            lengthX = Points[2].CoordinateX - Points[0].CoordinateX;
            lengthY = Points[2].CoordinateY - Points[0].CoordinateY;
            SideC = Math.Sqrt(lengthX * lengthX + lengthY * lengthY);
        }

        public override void FindArea()
        {
            FindSides();
            double s = (SideA + SideB + SideC) / 2;
            Area = Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public override void FindCenter()
        {

            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.CoordinateX;
                sumY += p.CoordinateY;
            }
            Center = new Point(sumX / 3, sumY / 3);

        }

        public override void FindPerimeter()
        {
            FindSides();
            Perimeter = SideA + SideB + SideC;
        }

        public override void MoveFigure(double x, double y)
        {
            foreach (var point in Points)
            {
                point.CoordinateX += x;
                point.CoordinateY += y;

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
        public override string ToString()
        {
            return $"{nameof(Triangle)} Sides: {SideA}, {SideB}, {SideC} Area:{Area} Perimeter:{Perimeter} Center:({Center.CoordinateX};{Center.CoordinateY})";
        }

        public override string ToFileString()
        {
            return $"{nameof(Triangle)}; Points:{Points[0]};{Points[1]};{Points[2]}; Area:{Area} Perimeter:{Perimeter} Center:{Center}";
        }
    }
}

