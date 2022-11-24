using System.Drawing;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using WebApplication1.Figures;
using Point = WebApplication1.Figures.Point;
using Rectangle = WebApplication1.Figures.Rectangle;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<FigureController> _logger;

        public FigureController(ILogger<FigureController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        List<Figure> figurelist = MenuActions.ReadFromFile();

        [HttpGet]
        public IEnumerable<Figure> Get()
        {
            return figurelist;
        }


        [HttpGet(("{id}"))]
        public IActionResult GetFigureID(int id)
        {
            var figure = figurelist.Find(s => s.Id == id);
            if (figure == null) return NotFound();
            return Ok(figure);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var figure = figurelist.Find(s => s.Id == id);
            if (figure == null) return NotFound();
            figurelist.Remove(figure);
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok(figure);
        }


        [HttpPost("CreateCircle/{centerX}/{centerY}/{coordinateX}/{coordinateY}")]
        public IActionResult PostCircle(double centerX, double centerY, double coordinateX, double coordinateY)
        {
            Circle crc1 = new Circle(new List<Point>()
              {
             new Point(centerX,centerY),
             new Point(coordinateX,coordinateY)
              });
            figurelist.Add(crc1);
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok();
        }

        [HttpPost("CreateTriangle/{firstCoordinateX}/{firstCoordinateY}/{secondCoordinateX}/{secondCoordinateY}/{thirdCoordinateX}/{thirdCoordinateY}")]
        public IActionResult PostTriangle(double firstCoordinateX, double firstCoordinateY, double secondCoordinateX, double secondCoordinateY, double thirdCoordinateX, double thirdCoordinateY)
        {
            Triangle triangle = new Triangle(new List<Point>()
            {
            new Point(firstCoordinateX,firstCoordinateY),
            new Point(secondCoordinateX,secondCoordinateY),
            new Point(thirdCoordinateX,thirdCoordinateY)
            });
            figurelist.Add(triangle);
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok();
        }

        [HttpPost("CreateSquare/{firstCoordinateX}/{firstCoordinateY}/{secondCoordinateX}/{secondCoordinateY}/{thirdCoordinateX}/{thirdCoordinateY}/{fourthCoordinateX}/{fourthCoordinateY}")]
        public IActionResult PostSquare(double firstCoordinateX, double firstCoordinateY, double secondCoordinateX, double secondCoordinateY, double thirdCoordinateX, double thirdCoordinateY, double fourthCoordinateX, double fourthCoordinateY)
        {
            Square sqre = new Square(new List<Point>()
            {
            new Point(firstCoordinateX,firstCoordinateY),
            new Point(secondCoordinateX,secondCoordinateY),
            new Point(thirdCoordinateX,thirdCoordinateY),
            new Point(fourthCoordinateX,fourthCoordinateY)
            });
            figurelist.Add(sqre);
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok();
        }

        [HttpPost("CreateRectangle/{firstCoordinateX}/{firstCoordinateY}/{secondCoordinateX}/{secondCoordinateY}/{thirdCoordinateX}/{thirdCoordinateY}/{fourthCoordinateX}/{fourthCoordinateY}")]
        public IActionResult PostRectangle(double firstCoordinateX, double firstCoordinateY, double secondCoordinateX, double secondCoordinateY, double thirdCoordinateX, double thirdCoordinateY, double fourthCoordinateX, double fourthCoordinateY)
        {
            Rectangle rectangle = new Rectangle(new List<Point>()
            {
            new Point(firstCoordinateX,firstCoordinateY),
            new Point(secondCoordinateX,secondCoordinateY),
            new Point(thirdCoordinateX,thirdCoordinateY),
            new Point(fourthCoordinateX,fourthCoordinateY)
            });
            figurelist.Add(rectangle);
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok();
        }


        [HttpPatch("RotateFigure/{id}")]
        public IActionResult RotateFigure(int id, double rotationDegree)
        {
            if (id == null || id == 0)
                return BadRequest();

            var figure = figurelist.Find(s => s.Id == id);
            if (figure == null)
                return NotFound();
            else
            {
                figurelist[id - 1].RotateFigure(rotationDegree);
            }
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok();
        }

        [HttpPatch("ScaleFigure/{id}")]
        public IActionResult ScaleFigure(int id, double scaleMultiplier)
        {
            if (id == null || id == 0)
                return BadRequest();

            var figure = figurelist.Find(s => s.Id == id);
            if (figure == null)
                return NotFound();
            else
            {
                figurelist[id - 1].ScaleFigure(scaleMultiplier);
            }
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok();
        }

        [HttpPatch("MoveFigure/{id}")]
        public IActionResult MoveFigure(int id, double coordinateX, double coordinateY)
        {
            if (id == null || id == 0)
                return BadRequest();

            var figure = figurelist.Find(s => s.Id == id);
            if (figure == null)
                return NotFound();
            else
            {
                figurelist[id - 1].MoveFigure(coordinateX, coordinateY);
            }
            MenuActions.SaveToFile("figure.json", figurelist);
            return Ok();
        }

    }
}