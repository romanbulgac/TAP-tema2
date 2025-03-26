using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("count-students-over")]
        public int CountStudentsOver(int age)
        {
            return _linqService.CountStudentsOver(age);
        }

        [HttpGet("get-cars-by-brand")]
        public List<Car> GetCarsByBrand(string brand)
        {
            return _linqService.GetCarsByBrand(brand);
        }

        [HttpGet("models")]
        public List<string> Models()
        {
            return _linqService.Models();
        }

        [HttpGet("cars-count")]
        public int CarsCount()
        {
            return _linqService.CarsCount();
        }

        [HttpGet("filter")]
        public List<Car> Filter(int year)
        {
            return _linqService.Filter(year);
        }

        [HttpGet("join")]
        public List<string> Join()
        {
            return _linqService.Join();
        }
    }
}
