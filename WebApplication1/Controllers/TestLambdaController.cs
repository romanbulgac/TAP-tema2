using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Lambda;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public TestLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("split-number")]
        public string SplitNumber(int value)
        {
            var tupleValue = _lambdaService.SplitNumber(value);
            return $"{tupleValue.Item1} / {tupleValue.Item2} / {tupleValue.Item3}";
        }

        [HttpGet("try-parse-number")]
        public string TryParseNumber(string value)
        {
            return _lambdaService.TryParseNumber(value) ? "Number" : "Not number";
        }

        [HttpGet("lower-case-delayed")]
        public string ToLowerCaseDelayed(string value)
        {
            var result = _lambdaService.ToLowerCaseDelayed(value).Result;
            return result;
        }
    }
}
