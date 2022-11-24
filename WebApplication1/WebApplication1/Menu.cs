using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml;
using Newtonsoft.Json;
using WebApplication1.Figures;
using Formatting = Newtonsoft.Json.Formatting;

static public class MenuActions
{

    const string path = @"figure.json";
    static int Main(string[] args)
    {
        Menu(Initialize());
        return 0;
    }


    public static List<Figure> Initialize()
    {
        List<Figure> figurelist = new List<Figure>();
        Square sq1 = new Square(new List<Point>()
{
    new Point(0,0),
    new Point(0,5),
    new Point(5,5),
    new Point(5,0)
});
        figurelist.Add(sq1);

        Rectangle rect1 = new Rectangle(new List<Point>()
{
    new Point(0,0),
    new Point(0,10),
    new Point(10,7),
    new Point(7,0),
});
        figurelist.Add(rect1);
        Triangle trg1 = new Triangle(new List<Point>()
{
    new Point(0,0),
    new Point(3,0),
    new Point(0,4)
});
        figurelist.Add(trg1);
        Circle crc1 = new Circle(new List<Point>()
{
    new Point(0,5),
    new Point(10,5)
});
        figurelist.Add(crc1);
        return figurelist;
    }


    public static void Menu(List<Figure> figurelist)
    {
        //using var sr = new StreamReader(path);
        while (true)
        {
            Console.WriteLine("Please select one of the following number:");
            Console.WriteLine("1) Show all figures\n" +
                "2) Create a figure\n" +
                "3) Change figure\n" +
                "4) Write from file\n" +
                "5) Read from file\n" +
                "0) Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowAllFigures(figurelist);
                    break;
                case 2:
                    CreateFigure(figurelist);
                    break;
                case 3:
                    ChangeFigure(figurelist);
                    break;
                case 4:
                    SaveToFile(path, figurelist);
                    break;
                case 5:
                    var figures = ReadFromFile();
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (var f in figures) Console.WriteLine(f);
                    break;
                case 0:
                    SaveToFile(path, figurelist);
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Please enter correct input!!!");
                    break;
            }
        }

    }

    static void ShowAllFigures(List<Figure> figures)
    {
        int i = 0;
        foreach (var fig in figures)
        {
            Console.WriteLine(++i + ". " + fig);
        }
    }

    static void CreateFigure(List<Figure> figures)
    {
        Console.WriteLine("Please select one of the following figure:");
        Console.WriteLine("1)Square\n" +
            "2)Rectangle\n" +
            "3)Circle\n" +
            "4)Triangle");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                figures.Add(CreateSquare());
                break;
            case 2:
                figures.Add(CreateRectangle());
                break;
            case 3:
                figures.Add(CreateCircle());
                break;
            case 4:
                figures.Add(CreateTriangle());
                break;
            default:
                Console.WriteLine("Please enter correct input!!!");
                break;
        }
    }

    public static void ChangeFigure(List<Figure> figures)
    {
        Console.WriteLine("Write the number of figure from list");
        ShowAllFigures(figures);
        int figChoice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Change Figure:");
        Console.WriteLine("1) Move Figure:");
        Console.WriteLine("2) Rotate Figure:");
        Console.WriteLine("3) Scale Figure:");
        Console.Write("Select an option: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Please insert the coordinates:");
                double x = Convert.ToDouble(Console.ReadLine());
                double y = Convert.ToDouble(Console.ReadLine());
                figures[figChoice - 1].MoveFigure(x, y);
                break;
            case 2:
                Console.WriteLine("Please insert the angle:");
                double angle = Convert.ToDouble(Console.ReadLine());
                figures[figChoice - 1].RotateFigure(angle);
                break;
            case 3:
                Console.WriteLine("Please insert the scale:");
                double scale = Convert.ToDouble(Console.ReadLine());
                figures[figChoice - 1].ScaleFigure(scale);
                break;
            default:
                break;
        }
    }

    static Square CreateSquare()
    {
        Console.WriteLine("Please insert the coordinates of square:");
        Console.WriteLine("Coordinates of first edge:");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x3 = Convert.ToDouble(Console.ReadLine());
        double y3 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x4 = Convert.ToDouble(Console.ReadLine());
        double y4 = Convert.ToDouble(Console.ReadLine());
        Square square = new Square(new List<Point>()
    {
        new Point(x1,y1),
        new Point(x2,y2),
        new Point(x3,y3),
        new Point(x4,y4),
    });
        return square;
    }

    static Rectangle CreateRectangle()
    {
        Console.WriteLine("Please insert the coordinates of rectangle:");
        Console.WriteLine("Coordinates of first edge:");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x3 = Convert.ToDouble(Console.ReadLine());
        double y3 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x4 = Convert.ToDouble(Console.ReadLine());
        double y4 = Convert.ToDouble(Console.ReadLine());
        Rectangle rectangle = new Rectangle(new List<Point>()
    {
        new Point(x1,y1),
        new Point(x2,y2),
        new Point(x3,y3),
        new Point(x4,y4),
    });
        return rectangle;
    }

    static Circle CreateCircle()
    {
        Console.WriteLine("Please insert the coordinates of circle:");
        Console.WriteLine("Coordinates of first point:");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second point:");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());
        Circle circle = new Circle(new List<Point>()
    {
        new Point(x1,y1),
        new Point(x2,y2)
    });
        return circle;
    }

    static Triangle CreateTriangle()
    {
        Console.WriteLine("Please insert the coordinates of triangle:");
        Console.WriteLine("Coordinates of first edge:");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Coordinates of second edge:");
        double x3 = Convert.ToDouble(Console.ReadLine());
        double y3 = Convert.ToDouble(Console.ReadLine());

        Triangle triangle = new Triangle(new List<Point>()
    {
        new Point(x1,y1),
        new Point(x2,y2),
        new Point(x3,y3)
    });
        return triangle;
    }

    public static List<Figure> ReadFromFile()
    {


        Console.WriteLine("Reading saved file");
        TextReader openFileStream = new StreamReader(path);
        Newtonsoft.Json.JsonSerializer jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented });
        List<Figure> result = new List<Figure>();
        result = (List<Figure>)jsonSerializer.Deserialize(openFileStream, result.GetType());
        openFileStream.Close();

        return result;
    }

    public static void SaveToFile(string path, List<Figure> figurelist)
    {
        TextWriter textWriter = new StreamWriter(path);
        Newtonsoft.Json.JsonSerializer jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented });
        jsonSerializer.Serialize(textWriter, figurelist);
        textWriter.Close();

    }

}


