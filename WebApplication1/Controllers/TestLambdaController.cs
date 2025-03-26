using System.Threading.Tasks;
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

        [HttpGet("0-parameter-sb")]
        public string Hello()
        {
            return _lambdaService.HelloSB();
        }
        [HttpGet("0-parameter-exp")]
        public string Helloexp()
        {
            return _lambdaService.HelloExp();
        }

        [HttpGet("1-parameter-exp")]
        public double Sqrt(double a)
        {
            return _lambdaService.SqrtExp(a);
        }
        [HttpGet("1-parameter-sb")]
        public double SqrtSB(double a)
        {
            return _lambdaService.SqrtSB(a);
        }

        [HttpGet("2-parameter-exp")]
        public double Pow(double a, int b)
        {
            return _lambdaService.PowExp(a, b);
        }

        [HttpGet("2-parameter-sb")]
        public double PowSB(double a, int b)
        {
            return _lambdaService.PowSB(a, b);
        }


        [HttpGet("3-parameter-exp")]
        public double Sum(double a, double b, double c)
        {
            return _lambdaService.SumExp(a, b, c);
        }
        [HttpGet("3-parameter-sb")]
        public double SumSB(double a, double b, double c)
        {
            return _lambdaService.SumSB(a, b, c);
        }

        [HttpGet("sort-sb")]
        public string SortStatement(double[] values, bool ascending)
        {
            var sortedValues = _lambdaService.SortSB(values, ascending);
            return string.Join(", ", sortedValues);
        }

        [HttpGet("sort")]
        public string Sort(double[] values, bool ascending)
        {
            var sortedValues = _lambdaService.SortExp(values, ascending);
            return string.Join(", ", sortedValues);
        }

        [HttpGet("sum-tuple-sb")]
        public int SumTuple(int a, int b)
        {
            var tuple = new System.Tuple<int, int>(a, b);
            return _lambdaService.SumTupleSB(tuple);
        }
        [HttpGet("sum-tuple-exp")]
        public int SumTupleExp(int a, int b)
        {
            var tuple = new System.Tuple<int, int>(a, b);
            return _lambdaService.SumTupleExp(tuple);
        }

        [HttpGet("delay")]
        public async Task<string> Delay()
        {
            return await _lambdaService.SendMessageSB("Hello, World!");
        }
        [HttpGet("delay-exp")]
        public async Task<string> DelayExp()
        {
            return await _lambdaService.SendMessageExp("Hello, World!");
        }

        
    }
}
