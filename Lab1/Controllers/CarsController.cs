using Lab1.Filters;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lab1.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly int _counter;
        private readonly ILogger _logger;
        private List<Car> Cars = new List<Car>();
        public CarsController(ILogger<CarsController> logger, int counter)
        {
            _logger = logger;
            _counter = counter;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            return Cars;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();
            return car;
        }
        [HttpPost]
        public ActionResult AddCar(Car car)
        {
            car.Id = Cars.Count + 1;
            car.Type = "Gas";
            Cars.Add(car);
            return CreatedAtAction(actionName: nameof(GetById), routeValues: new { id = car.Id },
            new { Message = "Car has been added successfully" });
        }

        [HttpPost]
        [ValidateCarType]
        [Route("New")]
        public ActionResult AddCar_Modern(Car car)
        {
            car.Id = Cars.Count + 1;
            Cars.Add(car);
            return CreatedAtAction(actionName: nameof(GetById), routeValues: new { id = car.Id },
            new { Message = "Car has been added successfully" });
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditCar(Car carParam,int id) 
        {
            if(carParam.Id != id)
                return BadRequest();
            var car =Cars.FirstOrDefault(c => c.Id == id);
            if(car == null)
                return NotFound();
            car.Model = carParam.Model;
            car.ProductionDate = carParam.ProductionDate;
            car.Type=carParam.Type;
            return NoContent();
        }
        [HttpDelete]
        public ActionResult DeleteCar(int id)
        {
            _logger.LogCritical("Delete Car");
            var car = Cars.FirstOrDefault(c=>c.Id == id);
            if (car == null)
                return NotFound();
            Cars.Remove(car);
            return NoContent();

        }
        [HttpGet]
        [Route("Count")]
        public ActionResult<int> GetCountOfRequests()
        {
            return _counter;
        }
    }
}
