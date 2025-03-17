using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Delegate;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        public TestDelegateController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet("intro")]
        public string Introduction(string name)
        {
            var callback = _delegateService.Hello;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("intro-condition")]
        public string IntroductionCondition(string name, bool welcome)
        {
            var callback1 = _delegateService.Hello;
            var callback2 = (string firstname, string lastname) => $"Bye, {firstname} {lastname}";

            var callback = welcome ? callback1 : callback2;

            return _delegateService.Introduction(name, callback);
        }
    }
}
